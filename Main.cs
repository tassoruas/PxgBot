using System;
using System.Windows.Forms;
using PxgBot.Helpers;
using PxgBot.Classes;
using System.Drawing;
using AutoIt;

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

            CavebotAttack.Start();
        }

        private async void tmrUpdateInfo_Tick(object sender, EventArgs e)
        {
            ///
            /// This timer runs in a 500ms interval
            /// 
            lblPokeHP.Text = Pokemon.HP.ToString();
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
        }

        private void btnGetBattleList_Click(object sender, EventArgs e)
        {
            txtTests.Text = GUI.GetBattleList();
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
            btnStartCavebot.Text = "Cavebot: " + Cavebot.Enabled;
        }
        private void btnStopCavebot_Click(object sender, EventArgs e)
        {
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            MemoryManager.WriteOnMemory((int)Addresses.Offsets.DestinX, 4072);
            MemoryManager.WriteOnMemory((int)Addresses.Offsets.DestinY, 3491);
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
            btnCavebotAttack.Text = "Cavebot Attacking: " + Cavebot.Enabled;
        }
    }
}
