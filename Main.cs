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
using System.Linq;

namespace PxgBot
{
    public partial class Main : Form
    {
        MouseHook mouseHook;
        KeyboardHook keyboardHook;
        TreeNode lastNode;

        public Main()
        {
            try
            {
                InitializeComponent();

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

                /// Create an "instance" of Cavebot and CavebotAttack and start InputHandler loop
                Task.Run(() => Cavebot.Start());
                Task.Run(() => CavebotAttack.Start());
                Task.Run(() => CavebotAttack.StartSpells());

                this.Location = new Point(GUI.WindowRect.X + 10, GUI.WindowRect.Y + 160);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Main constructor: " + ex.Message);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Size = new Size(116, 397);
        }


        private async void tmrUpdateInfo_Tick(object sender, EventArgs e)
        {
            ///
            /// This timer runs in a 350ms interval
            /// 
            try
            {
                bool isAttacking = await Character.isAttacking;
                lblCavebotIndex.Text = Cavebot.Index.ToString();

                lblPokeHP.Text = Pokemon.HP.ToString();

                if (Pokemon.HasPokemonSet && Pokemon.AutoRevive && Pokemon.HP <= Pokemon.AutoReviveHP &&
                    Pokemon.AutoReviveHP < Pokemon.AutoReviveHP && Pokemon.Reviving == false &&
                    Character.HP > 0 && Pokemon.ReviveCooldown == false)
                {
                    Pokemon.Revive();
                    if (Pokemon.isOutside() == false) Pokemon.PutOut();
                }

                if (Pokemon.HasPokemonSet && Pokemon.AutoRevive && Pokemon.MaxHP > Pokemon.AutoReviveOutOfBattleHP &&
                    Pokemon.Reviving == false && isAttacking == false && Pokemon.HP < Pokemon.AutoReviveOutOfBattleHP)
                {
                    Pokemon.Revive(true);
                    if (Pokemon.isOutside() == false) Pokemon.PutOut();
                }

                if (Pokemon.HP > 0 && Pokemon.HP > Pokemon.AutoReviveHP &&
                    (isAttacking || CavebotAttack.Enabled) && Pokemon.isOutside() == false)
                {
                    Pokemon.PutOut();
                }

                lblCharHP.Text = Character.HP.ToString();
                lblPosX.Text = Character.X.ToString();
                lblPosY.Text = Character.Y.ToString();
                lblPosZ.Text = Character.Z.ToString();
                lblDestinX.Text = Character.DestinX.ToString();
                lblDestinY.Text = Character.DestinY.ToString();

                bool isFishing = await Fishing.isFishing();
                lblIsFishing.Text = isFishing.ToString();
                lblIsAttacking.Text = isAttacking.ToString();

                if (GUI.isPxgActive())
                {
                    if (chbHotkeys.Checked == true)
                    {
                        if (keyboardHook.IsStarted == false) keyboardHook.Start();
                    }
                }
                else
                {
                    if (chbHotkeys.Checked == true)
                    {
                        if (keyboardHook.IsStarted == true) keyboardHook.Stop();
                    }
                }

                txtDebug.Text = Settings.DebugText;
                txtDebug.SelectionStart = txtDebug.Text.Length;
                txtDebug.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: tmrUpdateInfo: " + ex.Message);
            }
        }
        private void tmrUpdateGUI_Tick(object sender, EventArgs e)
        {
            try
            {
                if (GUI.isPxgActive())
                    UpdateGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: tmrUpdateGUI: " + ex.Message);
            }
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
                        GUI.GetWindowRect();

                        /// 
                        GUI.OpenBattleList();

                        // Set Game Screen Rect
                        GUI.GetScreenBorders();

                        /// Set BattleList Rect
                        GUI.GetBattleBorders();

                        /// Update Pokeball position
                        Pokemon.isOutside();

                        /// Set Screen Grid => Squares on screen to see SQMs
                        GUI.GetScreenGrid();

                        /// Set Chat Rect
                        GUI.GetChatBorders();
                    });
                    //this.Size = new Size(GUI.WindowRect.Width, GUI.WindowRect.Height);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateGUI error: " + ex.Message);
                if (Settings.Debug) { Settings.DebugText += "\n UpdateGUI error: " + ex.Message; }
            }
        }

        private void tmrFood_Tick(object sender, EventArgs e)
        {
            if (Pokemon.Reviving == false)
            {
                if ((string)cmbFoodHotkey.SelectedItem != "Disabled")
                    Task.Run(() => Pokemon.EatFood());
                AutoItX.Sleep(2000);
                InputHandler.SendKeys(new string[] { "!love" }, 10);
            }
        }

        private void chbAlarms_CheckedChanged(object sender, EventArgs e)
        {
            tmrAlarms.Enabled = chbAlarms.Checked;
        }

        private void tmrAlarms_Tick(object sender, EventArgs e)
        {
            // TODO: Implement alarm sounds
        }

        private void tmrTest_Tick(object sender, EventArgs e)
        {
            /// This timer runs in 1000ms interval
            /// Just for testing purposes. It wont be enabled on release

            /// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            /// !!!!!! GUI.DrawOnScreen only works on Main Monitor !!!!!!
            /// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            //GUI.DrawOnScreen(GUI.ScreenRect);

            if (GUI.ChatRect.IsEmpty == false)
                GUI.DrawOnScreen(GUI.ChatRect);

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
        }

        private void chbCavebot_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cavebot.Script.Count == 0 && Cavebot.Enabled == false)
                {
                    chbCavebot.Checked = false;
                    MessageBox.Show("No script loaded!");
                    return;
                }
                if (GUI.ScreenGrid != null)
                {
                    Cavebot.Enabled = chbCavebot.Checked;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("chbCavebot error: " + ex.Message);
            }
        }

        private void chbAttacker_CheckedChanged(object sender, EventArgs e)
        {
            CavebotAttack.Enabled = chbAttacker.Checked;
            if (CavebotAttack.Enabled)
            {
                if (Pokemon.isOutside() == false)
                {
                    Pokemon.PutOut();
                }
            }
        }

        private void btnStartCavebot_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cavebot.Script.Count == 0 && Cavebot.Enabled == false)
                {
                    MessageBox.Show("No script loaded!");
                    return;
                }
                if (GUI.ScreenGrid != null)
                {
                    Cavebot.Enabled = !Cavebot.Enabled;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnStartCavebot error: " + ex.Message);
            }
        }

        private void btnCavebotAttack_Click(object sender, EventArgs e)
        {
            CavebotAttack.Enabled = !CavebotAttack.Enabled;
            if (!CavebotAttack.Enabled)
            {
                if (Pokemon.isOutside() == false)
                {
                    Pokemon.PutOut();
                }
            }
        }

        #region General Settings Screen

        private void chbAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = chbAlwaysOnTop.Checked;
        }

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


                    try { chbAlarms.Checked = playerSettings.Alarms.enabled; } catch (Exception) { }
                    try { chbHotkeys.Checked = playerSettings.Hotkeys.enabled; } catch (Exception) { }
                    try { Hotkeys.ReviveHotkey = playerSettings.Hotkeys.ReviveHotkey; } catch (Exception) { }
                    txtReviveHotkey.Text = Hotkeys.ReviveHotkey;
                    try { Hotkeys.PauseCavebotHotkey = playerSettings.Hotkeys.PauseCavebotHotkey; } catch (Exception) { }
                    txtPauseCavebotHotkey.Text = Hotkeys.PauseCavebotHotkey;
                    try { Hotkeys.PauseAttackerHotkey = playerSettings.Hotkeys.PauseAttackerHotkey; } catch (Exception) { }
                    txtPauseAttackerHotkey.Text = Hotkeys.PauseAttackerHotkey;
                    try { chbDebug.Checked = playerSettings.Debug; } catch (Exception) { }
                    try { chbAutoRevive.Checked = playerSettings.Revive.enabled; } catch (Exception) { }
                    try { txtHpToRevive.Value = playerSettings.Revive.AutoReviveHP; } catch (Exception) { }
                    try { txtHpToReviveOutOfBattle.Value = playerSettings.Revive.AutoReviveOutOfBattleHP; } catch (Exception) { }
                    try { cmbReviveHotkey.SelectedItem = playerSettings.Revive.ReviveItemHotkey.ToString().Replace("{", "").Replace("}", ""); } catch (Exception) { }
                    try { cmbFoodHotkey.SelectedItem = playerSettings.Food.FoodHotkey.ToString().Replace("{", "").Replace("}", ""); } catch (Exception) { }


                    try
                    {
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
                    catch (Exception) { }

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

                playerSettings.Alarms.enabled = chbAlarms.Checked;

                JArray monstersToAttack = new JArray();
                foreach (var monster in listMonstersToAttack.Items)
                {
                    monstersToAttack.Add(monster.ToString());
                }

                playerSettings.MonstersToAttack = monstersToAttack;


                playerSettings.Revive = new JObject();
                playerSettings.Revive.enabled = chbAutoRevive.Checked;
                playerSettings.Revive.AutoReviveHP = (int)txtHpToRevive.Value;
                playerSettings.Revive.AutoReviveOutOfBattleHP = (int)txtHpToReviveOutOfBattle.Value;
                playerSettings.Revive.ReviveItemHotkey = "{" + cmbReviveHotkey.SelectedItem + "}";

                playerSettings.Food = new JObject();
                playerSettings.Food.FoodHotkey = "{" + cmbFoodHotkey.SelectedItem + "}";

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
            try
            {
                SavePlayerSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: btnSaveSettings: " + ex.Message);
            }
        }
        #endregion

        #region Cavebot Screen
        private void btnAddWaypoint_Click(object sender, EventArgs e)
        {
            try
            {
                bool lastTopMost = this.TopMost;
                this.TopMost = false;
                string node = "";
                if (CavebotTree.SelectedNode != null)
                {
                    lastNode = CavebotTree.SelectedNode;
                    node = CavebotTree.SelectedNode.ToString();
                }
                else
                {
                    if (lastNode != null)
                    {
                        node = lastNode.ToString();
                    }
                }
                FrmWaypoint frmWaypoint = new FrmWaypoint(false, node);
                frmWaypoint.ShowDialog();
                UpdateCavebotTree();
                this.TopMost = lastTopMost;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: btnAddWaypoint: " + ex.Message);
            }
        }

        private void btnEditWaypoint_Click(object sender, EventArgs e)
        {
            try
            {
                if (CavebotTree.SelectedNode != null)
                {
                    lastNode = CavebotTree.SelectedNode;
                    bool lastTopMost = this.TopMost;
                    this.TopMost = false;
                    FrmWaypoint frmWaypoint = new FrmWaypoint(true, CavebotTree.SelectedNode.ToString());
                    frmWaypoint.ShowDialog();
                    UpdateCavebotTree();
                    this.TopMost = lastTopMost;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: btnEditWaypoint: " + ex.Message);
            }
        }

        private void btnAddWaypointFast_Click(object sender, EventArgs e)
        {
            try
            {
                CavebotAction cavebotAction = new CavebotAction(Cavebot.Script.Count, new PXG.Position(Character.X, Character.Y, Character.Z), ActionTypes.Walk);
                Cavebot.Script.Add(cavebotAction);
                AddTreeNode(cavebotAction);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: btnAddWaypoint: " + ex.Message);
            }
        }

        private void btnDeleteWaypoint_Click(object sender, EventArgs e)
        {
            try
            {
                if (CavebotTree.SelectedNode != null)
                {
                    string[] values = CavebotTree.SelectedNode.ToString().Replace("TreeNode:", "").Split(';');
                    int ID = int.Parse(values[0].Split(':')[0].Replace(" ", "").Replace(">", ""));
                    string[] pos = values[0].Split('<')[1].Replace(">", "").Split(',');
                    PXG.Position position = new PXG.Position(int.Parse(pos[0]), int.Parse(pos[1]), int.Parse(pos[2]));
                    ActionTypes actionTypes = (ActionTypes)Enum.Parse(typeof(ActionTypes), values[1]);
                    CavebotAction cbAction = Cavebot.Script.FindLast(x => x.ID == ID && x.Position.X == int.Parse(pos[0]) && x.Position.Y == int.Parse(pos[1]) && x.Position.Z == int.Parse(pos[2]) && x.Action == actionTypes);
                    Cavebot.Script.Remove(cbAction);
                    UpdateCavebotTree();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: btnDeleteWaypoint: " + ex.Message);
            }
        }


        private void btnClearScript_Click(object sender, EventArgs e)
        {
            if (Cavebot.Enabled)
            {
                MessageBox.Show("You need to stop Cavebot first!");
                return;
            }

            Cavebot.Script.Clear();
            UpdateCavebotTree();
        }

        private void UpdateCavebotTree()
        {
            try
            {
                CavebotTree.Nodes.Clear();
                Cavebot.Script = Cavebot.Script.OrderBy(x => x.ID).ToList();
                foreach (CavebotAction cbAction in Cavebot.Script)
                {
                    AddTreeNode(cbAction);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: UpdateCavebotTree: " + ex.Message);
            }
        }

        private void AddTreeNode(CavebotAction cbAction)
        {
            try
            {
                string name = "";
                if (cbAction.Name != "")
                    name = "'" + cbAction.Name + "' ";

                string position = "<" + cbAction.Position.X + "," + cbAction.Position.Y + "," + cbAction.Position.Z + ">";
                TreeNode node = new TreeNode(cbAction.ID + ": " + name + position + "; " + cbAction.Action);
                CavebotTree.Nodes.Add(node);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: AddTreeNode: " + ex.Message);
            }
        }

        private void CavebotTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

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

                            string name = "";
                            try { name = waypoint["name"]; }
                            catch (Exception) { name = ""; }

                            string[] position = waypoint["position"].Split(',');
                            ActionTypes action = Enum.Parse(typeof(ActionTypes), waypoint["action"]);
                            CavebotAction cavebotAction = new CavebotAction(Cavebot.Script.Count, new PXG.Position(int.Parse(position[0]), int.Parse(position[1]), int.Parse(position[2])), action, name);
                            Cavebot.Script.Add(cavebotAction);
                        }

                        Cavebot.Index = 0;

                        UpdateCavebotTree();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: btnOpenScript: " + ex.Message);
            }
        }

        private void btnSaveScript_Click(object sender, EventArgs e)
        {
            try
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
                            ("{|name|:|" + action.Name + "|," + "|position|:|" + action.Position.X + ", " + action.Position.Y + ", " + action.Position.Z + "|, " +
                            "|action|:|" + action.Action.ToString() + "|}").Replace('|', '"'));
                    }
                    string name = sfd.FileName;
                    File.WriteAllText(name, "[" + script.ToString() + "]");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: btnSaveScript: " + ex.Message);
            }


        }

        #endregion

        #region Pokemon Settings Screen

        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                pnlSettings.Visible = !pnlSettings.Visible;
                if (pnlSettings.Visible)
                {
                    this.Size = new Size(455, 537);
                }
                else
                {
                    this.Size = new Size(116, 397);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: btnSettings: " + ex.Message);
            }
        }

        private void chbAutoRevive_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.AutoRevive = chbAutoRevive.Checked;
        }

        private void txtHpToRevive_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.AutoReviveHP = Convert.ToInt16(txtHpToRevive.Value);
        }

        private void txtHpToReviveOutOfBattle_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.AutoReviveOutOfBattleHP = Convert.ToInt16(txtHpToReviveOutOfBattle.Value);
        }

        private void cmbReviveHotkey_SelectedValueChanged(object sender, EventArgs e)
        {
            Pokemon.AutoReviveHotkey = "{" + cmbReviveHotkey.SelectedItem + "}";
        }

        private void cmbFoodHotkey_SelectedValueChanged(object sender, EventArgs e)
        {
            Pokemon.FoodHotkey = "{" + cmbFoodHotkey.SelectedItem + "}";
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

        private void chbFishing_CheckedChanged(object sender, EventArgs e)
        {
            Fishing.Enabled = chbFishing.Checked;

            if (Fishing.Enabled)
            {
                if (Fishing.FishingPosition.IsEmpty)
                {
                    chbFishing.Checked = false;
                    MessageBox.Show("Fishing position is not set!", "Error");
                    return;
                }
                Task.Run(() => Fishing.StartFishing());
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
