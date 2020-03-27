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

            Pokemon.AddSpell("F1", 10);
            Pokemon.AddSpell("F2", 15);
            Pokemon.AddSpell("F3", 20);


            CavebotAttack.MonstersToAttack.Add("Pidgey");

            //CavebotAction cavebotAction1 = new CavebotAction(null, ActionTypes.Fishing, new string[] { "894", "741" }, () => Pokemon.HP > 1000);
            //CavebotAction cavebotAction1 = new CavebotAction(new PXG.Position(4081, 3452, 5), ActionTypes.Walk);
            //CavebotAction cavebotAction2 = new CavebotAction(new PXG.Position(4085, 3434, 5), ActionTypes.Walk);
            //Cavebot.CavebotScript = new CavebotAction[] { cavebotAction1, cavebotAction2 };
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

            //    int posOnMatrixI = (int)Math.Floor((y - GUI.ScreenRect.Y) / GUI.sqmHeight);
            //    int posOnMatrixJ = (int)Math.Floor((x - GUI.ScreenRect.X) / GUI.sqmWidth);

            //    Rectangle monsterPos = GUI.ScreenGrid[posOnMatrixI, posOnMatrixJ];
            //    Console.WriteLine("Pos: " + posOnMatrixI + "," + posOnMatrixJ);
            //}
            //else
            //{
            //    Console.WriteLine("Not Found");
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
            btnCavebotAttack.Text = "Attacker: " + CavebotAttack.isEnabled();
        }
    }
}
