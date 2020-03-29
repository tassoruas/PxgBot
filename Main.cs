using System;
using System.Windows.Forms;
using PxgBot.Helpers;
using PxgBot.Classes;
using System.Drawing;
using AutoIt;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PxgBot
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            /// This turns the Form transparent
            this.TransparencyKey = BackColor;

            /// Activate PXG screen
            AutoItX.WinActivate(Addresses.PxgClientName);

            /// Find PXG Handle
            Addresses.RegisterHandle();
            /// Start reading from memory
            MemoryManager.StartMemoryManager(Addresses.PxgPointerAddress, Addresses.PxgProcessName);

            /// This sets all the rectangles of the screens
            UpdateGUI();

            /// Init Pokemon settings
            Pokemon.Init();

            /// This loads all the available monsters to the ListBoxes on settings screen
            LoadAvailableMonsters();

            /// This loads the Player settings in settings.json
            LoadPlayerSettings();

            ///
            /// Tests \/
            ///

            //CavebotAction cavebotAction1 = new CavebotAction(null, ActionTypes.Fishing, new string[] { "894", "741" }, () => Pokemon.HP > 1000);
            CavebotAction cavebotAction1 = new CavebotAction(new PXG.Position(4081, 3452, 5), ActionTypes.Walk);
            CavebotAction cavebotAction2 = new CavebotAction(new PXG.Position(4085, 3434, 5), ActionTypes.Walk);
            Cavebot.CavebotScript.Add(cavebotAction1);
            Cavebot.CavebotScript.Add(cavebotAction2);
        }

        private async void tmrUpdateInfo_Tick(object sender, EventArgs e)
        {
            ///
            /// This timer runs in a 500ms interval
            /// 

            lblPokeHP.Text = Pokemon.HP.ToString();

            if (Pokemon.AutoRevive && Pokemon.HP <= Pokemon.AutoReviveHP && Pokemon.Reviving == false && Character.HP > 0) Pokemon.Revive();

            lblCharHP.Text = Character.HP.ToString();
            lblPosX.Text = Character.PosX.ToString();
            lblPosY.Text = Character.PosY.ToString();
            lblPosZ.Text = Character.PosZ.ToString();
            lblDestinX.Text = Character.DestinX.ToString();
            lblDestinY.Text = Character.DestinY.ToString();

            bool isFishing = await Classes.Actions.Fishing.isFishing();
            lblIsFishing.Text = isFishing.ToString();
            bool isAttacking = await Character.isAttacking;
            lblIsAttacking.Text = isAttacking.ToString();

            if (GUI.isPxgActive())
                this.Show();
            else
                this.Hide();

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
                await Task.Run(() =>
                {
                    GUI.OpenBattleList();

                    // Set Game Screen Rect
                    GUI.SetScreenBorders();

                    /// Set BattleList Rect
                    GUI.SetBattleBorders();

                    /// Set the PXG Client window size to WindowRect
                    GUI.SetWindowRect();

                    /// Set Screen Grid => Squares on screen to see SQMs
                    GUI.SetScreenGrid();

                    /// Set window size
                });
                this.Location = new Point(GUI.WindowRect.X, GUI.WindowRect.Y);
                this.Size = new Size(GUI.WindowRect.Width, GUI.WindowRect.Height);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tmrTest_Tick(object sender, EventArgs e)
        {
            /// This timer runs in 2500ms interval
            /// Just for testing purposes. It wont be enabled on release

            //GUI.DrawOnScreen(GUI.ScreenRect);
            //GUI.DrawOnScreen(GUI.BattleRect);

            /// Show all SQMs
            //for (int i = 0; i < 11; i++)
            //{
            //    {
            //        for (int j = 0; j < 15; j++)
            //        {
            //            GUI.DrawOnScreen(GUI.ScreenGrid[i, j]);
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
            if (Cavebot.Enabled)
            {
                Cavebot.Stop();
            }
            else
            {
                Cavebot.Start();
            }
            btnStartCavebot.Text = "Cavebot: " + (Cavebot.Enabled ? "Running" : "Stopped");
        }

        private void btnCavebotAttack_Click(object sender, EventArgs e)
        {
            if (CavebotAttack.isEnabled())
            {
                CavebotAttack.Stop();
            }
            else
            {
                if (Pokemon.isOutside() == false)
                {
                    Pokemon.PutInOrOut();
                }
                CavebotAttack.Start();
            }
            btnCavebotAttack.Text = "Attacker: " + (CavebotAttack.isEnabled() ? "Running" : "Stopped");
        }

        #region Settings Screen

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
                            Console.WriteLine("Error: Monster '" + monster + "' image not available");
                        }
                    }
                    UpdateMonstersToAttack();

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

        #region Pokemon Settings Screen
        /// 
        /// 
        ///

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

    }
}
