using System;
using System.Windows.Forms;
using PxgBot.Helpers;
using PxgBot.Classes;
using System.Drawing;
using AutoIt;
using System.IO;

namespace PxgBot
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            this.TransparencyKey = BackColor;

            AutoItX.WinActivate(Addresses.PxgClientName);

            /// Find PXG Handle
            Addresses.RegisterHandle();
            /// Start reading from memory
            MemoryManager.StartMemoryManager(Addresses.PxgPointerAddress, Addresses.PxgProcessName);

            UpdateGUI();

            Character.ReviveHotkey = "{F10}";

            Pokemon.AddSpell("{F1}", 0, false);
            Pokemon.AddSpell("{F2}", 0, false);
            Pokemon.AddSpell("{F3}", 0, false);
            Pokemon.AddSpell("{F3}", 0, false);
            Pokemon.AddSpell("{F4}", 0, false);
            Pokemon.AddSpell("{F5}", 0, false);
            Pokemon.AddSpell("{F6}", 0, false);
            Pokemon.AddSpell("{F7}", 0, false);
            Pokemon.AddSpell("{F8}", 0, false);
            Pokemon.AddSpell("{F9}", 0, false);

            //CavebotAction cavebotAction1 = new CavebotAction(null, ActionTypes.Fishing, new string[] { "894", "741" }, () => Pokemon.HP > 1000);
            CavebotAction cavebotAction1 = new CavebotAction(new PXG.Position(4081, 3452, 5), ActionTypes.Walk);
            CavebotAction cavebotAction2 = new CavebotAction(new PXG.Position(4085, 3434, 5), ActionTypes.Walk);
            Cavebot.CavebotScript.Add(cavebotAction1);
            Cavebot.CavebotScript.Add(cavebotAction2);

            LoadAvailableMonsters();
        }

        private async void tmrUpdateInfo_Tick(object sender, EventArgs e)
        {
            ///
            /// This timer runs in a 500ms interval
            /// 
            lblPokeHP.Text = Pokemon.HP.ToString();

            if (Pokemon.HP < 1200 && Pokemon.Reviving == false && Character.HP != 0) Pokemon.Revive();

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

            if (AutoItX.WinActive(Addresses.PxgClientName) == 1 || AutoItX.WinActive(title: this.Text) == 1)
            {
                this.Show();
            }
            else
            {
                this.Hide();
            }
        }
        private void tmrUpdateGUI_Tick(object sender, EventArgs e)
        {
            UpdateGUI();
        }

        private void UpdateGUI()
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
            this.Location = new Point(GUI.WindowRect.X, GUI.WindowRect.Y);
            this.Size = new Size(GUI.WindowRect.Width, GUI.WindowRect.Height);
        }

        private void tmrTest_Tick(object sender, EventArgs e)
        {
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
                CavebotAttack.Start();
            }
            btnCavebotAttack.Text = "Attacker: " + (CavebotAttack.isEnabled() ? "Running" : "Stopped");
        }


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
            Pokemon.HpToRevive = Convert.ToInt16(txtHpToRevive.Value);
        }

        private void cmbReviveHotkey_SelectedValueChanged(object sender, EventArgs e)
        {
            Character.ReviveHotkey = "{" + cmbReviveHotkey.SelectedValue + "}";
        }

        private void chbSpellF1_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F1").Enabled = chbSpellF1.Checked;
            txtCooldownF1.Enabled = chbSpellF1.Checked;
        }

        private void txtCooldownF1_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F1").Cooldown = Convert.ToInt16(txtCooldownF1.Value);
        }

        private void chbSpellF2_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F2").Enabled = chbSpellF2.Checked;
            txtCooldownF2.Enabled = chbSpellF2.Checked;
        }

        private void txtCooldownF2_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F2").Cooldown = Convert.ToInt16(txtCooldownF2.Value);
        }

        private void chbSpellF3_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F3").Enabled = chbSpellF3.Checked;
            txtCooldownF3.Enabled = chbSpellF3.Checked;
        }
        private void txtCooldownF3_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F3").Cooldown = Convert.ToInt16(txtCooldownF3.Value);
        }

        private void chbSpellF4_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F4").Enabled = chbSpellF4.Checked;
            txtCooldownF4.Enabled = chbSpellF4.Checked;
        }

        private void txtCooldownF4_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F4").Cooldown = Convert.ToInt16(txtCooldownF4.Value);
        }

        private void chbSpellF5_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F5").Enabled = chbSpellF5.Checked;
            txtCooldownF5.Enabled = chbSpellF5.Checked;
        }
        private void txtCooldownF5_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F5").Cooldown = Convert.ToInt16(txtCooldownF5.Value);
        }

        private void chbSpellF6_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F6").Enabled = chbSpellF6.Checked;
            txtCooldownF6.Enabled = chbSpellF6.Checked;
        }
        private void txtCooldownF6_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F6").Cooldown = Convert.ToInt16(txtCooldownF6.Value);
        }

        private void chbSpellF7_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F7").Enabled = chbSpellF7.Checked;
            txtCooldownF7.Enabled = chbSpellF7.Checked;
        }
        private void txtCooldownF7_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F7").Cooldown = Convert.ToInt16(txtCooldownF7.Value);
        }

        private void chbSpellF8_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F8").Enabled = chbSpellF8.Checked;
            txtCooldownF8.Enabled = chbSpellF8.Checked;
        }
        private void txtCooldownF8_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F8").Cooldown = Convert.ToInt16(txtCooldownF8.Value);
        }

        private void chbSpellF9_CheckedChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F9").Enabled = chbSpellF9.Checked;
            txtCooldownF9.Enabled = chbSpellF9.Checked;
        }

        private void txtCooldownF9_ValueChanged(object sender, EventArgs e)
        {
            Pokemon.PokemonSpells.Find(x => x.SpellHotkey == "F9").Cooldown = Convert.ToInt16(txtCooldownF9.Value);
        }

        #endregion

        #region Attacker Settings Screen

        private void LoadAvailableMonsters()
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

        private void btnAddMonsterAttack_Click(object sender, EventArgs e)
        {
            listMonstersToAttack.Items.Add(listAvailableMonsters.SelectedItem);
            listAvailableMonsters.Items.Remove(listAvailableMonsters.SelectedItem);
            UpdateMonstersToAttack();
        }
        private void btnRemoveMonsterAttack_Click(object sender, EventArgs e)
        {
            listAvailableMonsters.Items.Add(listMonstersToAttack.SelectedItem);
            listMonstersToAttack.Items.Remove(listMonstersToAttack.SelectedItem);
            UpdateMonstersToAttack();
        }

        private void UpdateMonstersToAttack()
        {
            CavebotAttack.MonstersToAttack.Clear();
            foreach (var monster in listMonstersToAttack.Items)
            {
                Console.WriteLine("monster: " + monster.ToString());
                CavebotAttack.MonstersToAttack.Add(monster.ToString());
            }
        }

        #endregion

    }
}
