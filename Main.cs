using System;
using System.Windows.Forms;
using System.Drawing;
using AutoIt;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PxgBot.Helpers;
using PxgBot.Classes;
using PxgBot.Classes.Actions;
using PxgBot.Forms;
using System.Web.Script.Serialization;

namespace PxgBot
{
    public partial class Main : Form
    {
        MouseHook mouseHook;
        KeyboardHook keyboardHook;

        public Main()
        {
            InitializeComponent();

            /// This turns the Form transparent
            this.TransparencyKey = BackColor;

            /// Activate PXG screen
            AutoItX.WinActivate(Addresses.PxgClientName);

            /// Find PXG Handle
            Addresses.RegisterHandle();

            /// This sets all the rectangles of the screens
            UpdateGUI();

            /// Start reading from memory
            MemoryManager.StartMemoryManager(Addresses.PxgPointerAddress, Addresses.PxgProcessName);

            /// Init Pokemon settings
            Pokemon.Init();

            /// This loads all the available monsters to the ListBoxes on settings screen
            LoadAvailableMonsters();

            /// This loads the Player settings in settings.json
            LoadPlayerSettings();

            /// Cavebot placeholder actions
            //Cavebot.TestInit();

            /// This is used populate Cavebot Tree
            UpdateCavebotTree();


            /// Create an "instance" of Cavebot and CavebotAttack
            Task.Run(() => Cavebot.Start());
            Task.Run(() => CavebotAttack.Start());
        }


        private async void tmrUpdateInfo_Tick(object sender, EventArgs e)
        {
            ///
            /// This timer runs in a 350ms interval
            /// 

            lblPokeHP.Text = Pokemon.HP.ToString();

            if (Pokemon.HasPokemonSet && Pokemon.AutoRevive &&
                Pokemon.HP <= Pokemon.AutoReviveHP &&
                Pokemon.Reviving == false && Character.HP > 0)
            {
                Pokemon.Revive();
            }

            if (Pokemon.HasPokemonSet && Pokemon.HP > 0 && await Character.isAttacking && Pokemon.isOutside() == false)
            {
                Pokemon.PutInOrOut();
            }

            lblCharHP.Text = Character.HP.ToString();
            lblPosX.Text = Character.X.ToString();
            lblPosY.Text = Character.Y.ToString();
            lblPosZ.Text = Character.Z.ToString();
            lblDestinX.Text = Character.DestinX.ToString();
            lblDestinY.Text = Character.DestinY.ToString();

            bool isFishing = await Classes.Actions.Fishing.isFishing();
            lblIsFishing.Text = isFishing.ToString();
            bool isAttacking = await Character.isAttacking;
            lblIsAttacking.Text = isAttacking.ToString();

            if (GUI.isPxgActive())
            {
                this.Show();
                if (chbHotkeys.Checked == true)
                {
                    keyboardHook.Start();
                }
            }
            else
            {
                if (chbHotkeys.Checked == true)
                {
                    keyboardHook.Stop();
                }
                this.Hide();
            }

            if (Cavebot.Enabled) btnStartCavebot.Text = "Cavebot: Running";
            else btnStartCavebot.Text = "Cavebot: Stopped";

            if (CavebotAttack.Enabled) btnCavebotAttack.Text = "Attacker: Running";
            else btnCavebotAttack.Text = "Attacker: Stopped";

            txtDebug.Text = Settings.DebugText;

        }
        private void tmrUpdateGUI_Tick(object sender, EventArgs e)
        {
            if (GUI.isPxgActive())
                UpdateGUI();
        }

        private async void UpdateGUI()
        {
            try
            {
                if (Pokemon.Reviving == false)
                {
                    await Task.Run(() =>
                    {
                        /// Set the PXG Client window size to WindowRect
                        GUI.SetWindowRect();

                        ///
                        GUI.OpenBattleList();

                        // Set Game Screen Rect
                        GUI.SetScreenBorders();


                        /// Set BattleList Rect
                        GUI.SetBattleBorders();

                        /// Update Pokeball position
                        Pokemon.isOutside();

                        /// Set Screen Grid => Squares on screen to see SQMs
                        GUI.SetScreenGrid(); // Not using for anything right now
                    });

                    this.Location = new Point(GUI.WindowRect.X, GUI.WindowRect.Y);
                    this.Size = new Size(GUI.WindowRect.Width, GUI.WindowRect.Height);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateGUI error: " + ex.Message);
                if (Settings.Debug) { Settings.DebugText += "\n UpdateGUI error: " + ex.Message; }
            }
        }

        private void tmrTest_Tick(object sender, EventArgs e)
        {
            /// This timer runs in 2500ms interval
            /// Just for testing purposes. It wont be enabled on release

            /// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            /// !!!!!! GUI.DrawOnScreen only works on Main Monitor !!!!!!
            /// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //GUI.DrawOnScreen(GUI.ScreenRect);
            //GUI.DrawOnScreen(GUI.BattleRect);

            /// Show all SQMs
            //Console.WriteLine("GUI: " + GUI.ScreenGrid);
            //if (GUI.ScreenGrid != null)
            //{
            //    for (int x = 0; x < 15; x++)
            //    {
            //        {
            //            for (int y = 0; y < 11; y++)
            //            {
            //                GUI.DrawOnScreen(GUI.ScreenGrid[x, y]);
            //            }
            //        }
            //    }
            //}

            //var res = ImageSearcher.UseImageSearch("Monsters\\Doduo.png", GUI.ScreenRect.X, GUI.ScreenRect.Y, GUI.ScreenRect.Width, GUI.ScreenRect.Height, tolerance: 10);
            //if (res != null)
            //{
            //    /// Find where of the screen Doduo is:
            //    int x = res[0];
            //    int y = (int)(res[1] + GUI.ScreenRect.Height * 0.08);
            //
            //    int posOnMatrixI = (int)Math.Floor((y - GUI.ScreenRect.Y) / GUI.sqmHeight);
            //    int posOnMatrixJ = (int)Math.Floor((x - GUI.ScreenRect.X) / GUI.sqmWidth);
            //
            //    Rectangle monsterPos = GUI.ScreenGrid[posOnMatrixI, posOnMatrixJ];
            //    Console.WriteLine("Pos: " + posOnMatrixI + "," + posOnMatrixJ);
            //}
            //else
            //{
            //    Console.WriteLine("Not Found");
            //}
        }

        private void btnStartCavebot_Click(object sender, EventArgs e)
        {
            if (GUI.ScreenGrid != null)
            {
                Cavebot.Enabled = !Cavebot.Enabled;
            }
        }

        private void btnCavebotAttack_Click(object sender, EventArgs e)
        {
            CavebotAttack.Enabled = !CavebotAttack.Enabled;
            if (!CavebotAttack.Enabled)
            {
                if (Pokemon.isOutside() == false)
                {
                    Pokemon.PutInOrOut();
                }
            }
        }

        #region General Settings Screen

        private void LoadPlayerSettings()
        {
            try
            {
                if (File.Exists("settings.json"))
                {
                    string json = File.ReadAllText("settings.json");
                    dynamic playerSettings = JArray.Parse(json)[0];
                    JArray monstersToAttack = playerSettings.MonstersToAttack;
                    foreach (JToken monster in monstersToAttack)
                    {
                        if (File.Exists("Images\\Monsters\\" + monster + ".png"))
                        {
                            listAvailableMonsters.Items.Remove(monster.ToString());
                            listMonstersToAttack.Items.Add(monster.ToString());
                        }
                        else
                        {
                            if (Settings.Debug) { Settings.DebugText += "\n Error: Monster '" + monster + "' image not available"; }
                        }
                    }
                    UpdateMonstersToAttack();

                    chbHotkeys.Checked = playerSettings.Hotkeys.enabled;
                    Hotkeys.ReviveHotkey = playerSettings.Hotkeys.ReviveHotkey;
                    txtReviveHotkey.Text = Hotkeys.ReviveHotkey;
                    Hotkeys.PauseCavebotHotkey = playerSettings.Hotkeys.PauseCavebotHotkey;
                    txtPauseCavebotHotkey.Text = Hotkeys.PauseCavebotHotkey;
                    Hotkeys.PauseAttackerHotkey = playerSettings.Hotkeys.PauseAttackerHotkey;
                    txtPauseAttackerHotkey.Text = Hotkeys.PauseAttackerHotkey;

                    chbDebug.Checked = playerSettings.Debug;

                    chbAutoRevive.Checked = playerSettings.Revive.enabled;
                    txtHpToRevive.Value = playerSettings.Revive.AutoReviveHP;
                    cmbReviveHotkey.SelectedItem = playerSettings.Revive.ReviveItemHotkey.ToString().Replace("{", "").Replace("}", "");

                    chbSpellF1.Checked = playerSettings.Spells.F1.enabled;
                    chbSpellF2.Checked = playerSettings.Spells.F2.enabled;
                    chbSpellF3.Checked = playerSettings.Spells.F3.enabled;
                    chbSpellF4.Checked = playerSettings.Spells.F4.enabled;
                    chbSpellF5.Checked = playerSettings.Spells.F5.enabled;
                    chbSpellF6.Checked = playerSettings.Spells.F6.enabled;
                    chbSpellF7.Checked = playerSettings.Spells.F7.enabled;
                    chbSpellF8.Checked = playerSettings.Spells.F8.enabled;
                    chbSpellF9.Checked = playerSettings.Spells.F9.enabled;

                    txtCooldownF1.Value = playerSettings.Spells.F1.cooldown;
                    txtCooldownF2.Value = playerSettings.Spells.F2.cooldown;
                    txtCooldownF3.Value = playerSettings.Spells.F3.cooldown;
                    txtCooldownF4.Value = playerSettings.Spells.F4.cooldown;
                    txtCooldownF5.Value = playerSettings.Spells.F5.cooldown;
                    txtCooldownF6.Value = playerSettings.Spells.F6.cooldown;
                    txtCooldownF7.Value = playerSettings.Spells.F7.cooldown;
                    txtCooldownF8.Value = playerSettings.Spells.F8.cooldown;
                    txtCooldownF9.Value = playerSettings.Spells.F9.cooldown;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading settings: " + ex.Message);
            }
        }

        private void SavePlayerSettings()
        {
            try
            {
                dynamic playerSettings = new JObject();

                playerSettings.Debug = new JObject();
                playerSettings.Debug = chbDebug.Checked;

                playerSettings.Hotkeys = new JObject();
                playerSettings.Hotkeys.enabled = chbHotkeys.Checked;
                playerSettings.Hotkeys.ReviveHotkey = Hotkeys.ReviveHotkey;
                playerSettings.Hotkeys.PauseCavebotHotkey = Hotkeys.PauseCavebotHotkey;
                playerSettings.Hotkeys.PauseAttackerHotkey = Hotkeys.PauseAttackerHotkey;

                JArray monstersToAttack = new JArray();
                foreach (var monster in listMonstersToAttack.Items)
                {
                    monstersToAttack.Add(monster.ToString());
                }

                playerSettings.MonstersToAttack = monstersToAttack;


                playerSettings.Revive = new JObject();
                playerSettings.Revive.enabled = chbAutoRevive.Checked;
                playerSettings.Revive.AutoReviveHP = (int)txtHpToRevive.Value;
                playerSettings.Revive.ReviveItemHotkey = "{" + cmbReviveHotkey.SelectedItem + "}";

                playerSettings.Spells = new JObject();
                playerSettings.Spells.F1 = new JObject();
                playerSettings.Spells.F2 = new JObject();
                playerSettings.Spells.F3 = new JObject();
                playerSettings.Spells.F4 = new JObject();
                playerSettings.Spells.F5 = new JObject();
                playerSettings.Spells.F6 = new JObject();
                playerSettings.Spells.F7 = new JObject();
                playerSettings.Spells.F8 = new JObject();
                playerSettings.Spells.F9 = new JObject();
                playerSettings.Spells.F1.enabled = chbSpellF1.Checked;
                playerSettings.Spells.F2.enabled = chbSpellF2.Checked;
                playerSettings.Spells.F3.enabled = chbSpellF3.Checked;
                playerSettings.Spells.F4.enabled = chbSpellF4.Checked;
                playerSettings.Spells.F5.enabled = chbSpellF5.Checked;
                playerSettings.Spells.F6.enabled = chbSpellF6.Checked;
                playerSettings.Spells.F7.enabled = chbSpellF7.Checked;
                playerSettings.Spells.F8.enabled = chbSpellF8.Checked;
                playerSettings.Spells.F9.enabled = chbSpellF9.Checked;

                playerSettings.Spells.F1.cooldown = (int)txtCooldownF1.Value;
                playerSettings.Spells.F2.cooldown = (int)txtCooldownF2.Value;
                playerSettings.Spells.F3.cooldown = (int)txtCooldownF3.Value;
                playerSettings.Spells.F4.cooldown = (int)txtCooldownF4.Value;
                playerSettings.Spells.F5.cooldown = (int)txtCooldownF5.Value;
                playerSettings.Spells.F6.cooldown = (int)txtCooldownF6.Value;
                playerSettings.Spells.F7.cooldown = (int)txtCooldownF7.Value;
                playerSettings.Spells.F8.cooldown = (int)txtCooldownF8.Value;
                playerSettings.Spells.F9.cooldown = (int)txtCooldownF9.Value;

                File.WriteAllText("settings.json", "[" + playerSettings.ToString() + "]");
                MessageBox.Show("Settings saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving settings: " + ex.Message);
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            SavePlayerSettings();
        }
        #endregion

        #region Cavebot Screen
        private void btnAddWaypoint_Click(object sender, EventArgs e)
        {
            FrmWaypoint frmWaypoint = new FrmWaypoint();
            frmWaypoint.ShowDialog();
            UpdateCavebotTree();
            Console.WriteLine("Updated");
        }

        private void btnEditWaypoint_Click(object sender, EventArgs e)
        {
            FrmWaypoint frmWaypoint = new FrmWaypoint(CavebotTree.SelectedNode.ToString());
            frmWaypoint.ShowDialog();
            UpdateCavebotTree();
            Console.WriteLine("Updated");
        }

        private void btnAddWaypointFast_Click(object sender, EventArgs e)
        {
            CavebotAction cavebotAction = new CavebotAction(new PXG.Position(Character.X, Character.Y, Character.Z), ActionTypes.Walk);
            Cavebot.Script.Add(cavebotAction);
            AddTreeNode(cavebotAction);
        }

        private void btnDeleteWaypoint_Click(object sender, EventArgs e)
        {
            string[] selectedNode = CavebotTree.SelectedNode.Text.Replace(" ", "").Split(';');
            string[] pos = selectedNode[0].Replace("<", "").Replace(">", "").Split(',');
            string action = selectedNode[1];
            Console.WriteLine("data: " + pos[0] + ", " + pos[1] + ", " + pos[2] + ", " + action);
            CavebotAction cbAction = Cavebot.Script.FindLast(x => x.Position.X == int.Parse(pos[0]) && x.Position.Y == int.Parse(pos[1]) && x.Position.Z == int.Parse(pos[2]) && x.Action == (ActionTypes)Enum.Parse(typeof(ActionTypes), action));
            Cavebot.Script.Remove(cbAction);
            UpdateCavebotTree();
        }

        private void UpdateCavebotTree()
        {
            CavebotTree.Nodes.Clear();
            foreach (CavebotAction cbAction in Cavebot.Script)
            {
                AddTreeNode(cbAction);
            }
        }

        private void AddTreeNode(CavebotAction cbAction)
        {
            string position = "<" + cbAction.Position.X + "," + cbAction.Position.Y + "," + cbAction.Position.Z + ">";
            TreeNode node = new TreeNode(position + "; " + cbAction.Action);
            CavebotTree.Nodes.Add(node);
        }

        private void btnOpenScript_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "JSON Files (*.json)|*.json";
                ofd.FilterIndex = 0;
                ofd.DefaultExt = "json";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (!String.Equals(Path.GetExtension(ofd.FileName), ".json", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("The type of the selected file is not supported by this application. You must select an JSON file.", "Invalid File Type",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        string fullPath = ofd.FileName;
                        Console.WriteLine("Path: " + fullPath);
                        string json = File.ReadAllText(fullPath);
                        dynamic script = JArray.Parse(json)[0];
                        JArray waypoints = script.Waypoints;
                        JavaScriptSerializer jss = new JavaScriptSerializer();

                        Cavebot.Script.Clear();
                        for (int i = 0; i < waypoints.Count; i++)
                        {
                            var waypoint = jss.Deserialize<dynamic>(waypoints[i].ToString());
                            string[] position = waypoint["position"].Split(',');
                            ActionTypes action = Enum.Parse(typeof(ActionTypes), waypoint["action"]);
                            CavebotAction cavebotAction = new CavebotAction(new PXG.Position(int.Parse(position[0]), int.Parse(position[1]), int.Parse(position[2])), action);
                            Cavebot.Script.Add(cavebotAction);
                        }

                        UpdateCavebotTree();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: btnOpenScript: " + ex.Message);
            }
        }

        private void btnSaveScript_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JSON Files (*.json)|*.json";
            sfd.FilterIndex = 0;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                dynamic script = new JObject();

                script.Waypoints = new JArray();
                foreach (CavebotAction action in Cavebot.Script)
                {
                    script.Waypoints.Add(
                        ("{|position|:|" + action.Position.X + ", " + action.Position.Y + ", " + action.Position.Z + "|, " +
                        "|action|:|" + action.Action.ToString() + "|}").Replace('|', '"'));
                }
                string name = sfd.FileName;
                File.WriteAllText(name, "[" + script.ToString() + "]");
            }


        }

        #endregion

        #region Pokemon Settings Screen

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = !pnlSettings.Visible;
        }

        private void chbAutoRevive_CheckedChanged(object sender, EventArgs e)
        {
            txtHpToRevive.Enabled = chbAutoRevive.Checked;
            Pokemon.AutoRevive = chbAutoRevive.Checked;
        }

        private void txtHpToRevive_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.AutoReviveHP = Convert.ToInt16(txtHpToRevive.Value);
        }

        private void cmbReviveHotkey_SelectedValueChanged(object sender, EventArgs e)
        {
            Pokemon.AutoReviveHotkey = "{" + cmbReviveHotkey.SelectedItem + "}";
        }

        private void chbSpellF1_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F1}").Enabled = chbSpellF1.Checked;
            txtCooldownF1.Enabled = chbSpellF1.Checked;
        }


        private void chbSpellF2_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F2}").Enabled = chbSpellF2.Checked;
            txtCooldownF2.Enabled = chbSpellF2.Checked;
        }


        private void chbSpellF3_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F3}").Enabled = chbSpellF3.Checked;
            txtCooldownF3.Enabled = chbSpellF3.Checked;
        }

        private void chbSpellF4_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F4}").Enabled = chbSpellF4.Checked;
            txtCooldownF4.Enabled = chbSpellF4.Checked;
        }

        private void chbSpellF5_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F5}").Enabled = chbSpellF5.Checked;
            txtCooldownF5.Enabled = chbSpellF5.Checked;
        }
        private void chbSpellF6_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F6}").Enabled = chbSpellF6.Checked;
            txtCooldownF6.Enabled = chbSpellF6.Checked;
        }

        private void chbSpellF7_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F7}").Enabled = chbSpellF7.Checked;
            txtCooldownF7.Enabled = chbSpellF7.Checked;
        }

        private void chbSpellF8_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F8}").Enabled = chbSpellF8.Checked;
            txtCooldownF8.Enabled = chbSpellF8.Checked;
        }

        private void chbSpellF9_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F9}").Enabled = chbSpellF9.Checked;
            txtCooldownF9.Enabled = chbSpellF9.Checked;
        }
        private void txtCooldownF1_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F1}").Cooldown = Convert.ToInt16(txtCooldownF1.Value);
        }
        private void txtCooldownF2_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F2}").Cooldown = Convert.ToInt16(txtCooldownF2.Value);
        }
        private void txtCooldownF3_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F3}").Cooldown = Convert.ToInt16(txtCooldownF3.Value);
        }
        private void txtCooldownF4_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F4}").Cooldown = Convert.ToInt16(txtCooldownF4.Value);
        }

        private void txtCooldownF5_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F5}").Cooldown = Convert.ToInt16(txtCooldownF5.Value);
        }

        private void txtCooldownF6_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F6}").Cooldown = Convert.ToInt16(txtCooldownF6.Value);
        }

        private void txtCooldownF7_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F7}").Cooldown = Convert.ToInt16(txtCooldownF7.Value);
        }

        private void txtCooldownF8_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F8}").Cooldown = Convert.ToInt16(txtCooldownF8.Value);
        }

        private void txtCooldownF9_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "{F9}").Cooldown = Convert.ToInt16(txtCooldownF9.Value);
        }


        #endregion

        #region Attacker Settings Screen

        private void LoadAvailableMonsters()
        {
            try
            {
                string[] monsters = Directory.GetFiles("Images\\Monsters");
                for (int i = 0; i < monsters.Length; i++)
                {
                    monsters[i] = monsters[i].Replace("Images\\Monsters\\", "").Replace(".png", "");
                }
                foreach (string monster in monsters)
                {
                    listAvailableMonsters.Items.Add(monster);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while loading available monsters: " + ex.Message);
                if (Settings.Debug) { Settings.DebugText += "\n Error while loading available monsters: " + ex.Message; }
            }
        }

        private void btnAddMonsterAttack_Click(object sender, EventArgs e)
        {
            if (listAvailableMonsters.SelectedItem != null)
            {
                listMonstersToAttack.Items.Add(listAvailableMonsters.SelectedItem);
                listAvailableMonsters.Items.Remove(listAvailableMonsters.SelectedItem);
                UpdateMonstersToAttack();
            }
        }
        private void btnRemoveMonsterAttack_Click(object sender, EventArgs e)
        {
            if (listMonstersToAttack.SelectedItem != null)
            {
                listAvailableMonsters.Items.Add(listMonstersToAttack.SelectedItem);
                listMonstersToAttack.Items.Remove(listMonstersToAttack.SelectedItem);
                UpdateMonstersToAttack();
            }
        }

        private void UpdateMonstersToAttack()
        {
            CavebotAttack.MonstersToAttack.Clear();
            foreach (var monster in listMonstersToAttack.Items)
            {
                CavebotAttack.MonstersToAttack.Add(monster.ToString());
            }
        }

        #endregion

        #region Fishing Settings

        private void btnSetFishingPosition_Click(object sender, EventArgs e)
        {
            if (btnSetFishingPosition.Text == "Clear Fishing Position")
            {
                Fishing.FishingPosition = new Point();
                btnSetFishingPosition.Text = "Set Fishing Position";
                return;
            }
            mouseHook = new MouseHook();
            mouseHook.Start();
            mouseHook.MouseUp += new MouseEventHandler(RegisterClick);
            btnSettings.PerformClick();
        }

        private void RegisterClick(object sender, MouseEventArgs e)
        {
            Fishing.FishingPosition = new Point(e.X, e.Y);
            btnSetFishingPosition.Text = "Clear Fishing Position";
            mouseHook.Stop();
            mouseHook.MouseUp -= new MouseEventHandler(RegisterClick);
            btnSettings.PerformClick();
        }

        private void btnFishing_Click(object sender, EventArgs e)
        {
            if (Fishing.Enabled)
            {
                btnFishing.Text = "Fishing: Stopped";
                Fishing.Enabled = false;
            }
            else
            {
                btnFishing.Text = "Fishing: Running";
                Task.Run(() => Fishing.StartFishing());
                Fishing.Enabled = true;
            }
        }
        #endregion

        #region Hotkeys Settings
        private void chbHotkeys_CheckedChanged(object sender, EventArgs e)
        {
            Hotkeys.Enabled = chbHotkeys.Checked;
            if (chbHotkeys.Checked)
            {
                keyboardHook = new KeyboardHook();
                keyboardHook.KeyDown += new KeyEventHandler(Hotkeys.KeyPress);
            }
        }

        private void txtReviveHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            txtReviveHotkey.Text = e.KeyData.ToString();
            Hotkeys.ReviveHotkey = e.KeyData.ToString();
        }

        private void txtPauseCavebotHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            txtPauseCavebotHotkey.Text = e.KeyData.ToString();
            Hotkeys.PauseCavebotHotkey = e.KeyData.ToString();
        }

        private void txtPauseAttackerHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            txtPauseAttackerHotkey.Text = e.KeyData.ToString();
            Hotkeys.PauseAttackerHotkey = e.KeyData.ToString();
        }

        #endregion

        #region Debug Settings
        private void chbDebug_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Debug = chbDebug.Checked;
        }
        #endregion
    }
}
