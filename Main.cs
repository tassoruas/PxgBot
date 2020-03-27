using System;
using System.Windows.Forms;
using PxgBot.Helpers;
using PxgBot.Classes;
using System.Drawing;
using AutoIt;
using System.Threading.Tasks;

namespace PxgBot
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            AutoItX.WinActivate(Addresses.PxgClientName);

            /// Find PXG Handle
            Addresses.RegisterHandle();
            /// Start reading from memory
            MemoryManager.StartMemoryManager(Addresses.PxgPointerAddress, Addresses.PxgProcessName);

            GUI.OpenBattleList();

            // Set Screen Rect
            GUI.SetScreenBorders();

            /// Set BattleList Rect
            GUI.SetBattleBorders();

            /// Set Screen Grid => Squares on screen to see SQMs;
            GUI.SetScreenGrid();
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
            //input.Click(963, 498, Addresses.PxgProcessName);
        }
        private void tmrUpdateGUI_Tick(object sender, EventArgs e)
        {
            // Set Screen Rect
            GUI.SetScreenBorders();

            /// Set BattleList Rect
            GUI.SetBattleBorders();
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

            GUI.DrawOnScreen(GUI.ScreenRect);
            GUI.DrawOnScreen(GUI.BattleRect);
            var res = ImageSearcher.UseImageSearch("Monsters\\Doduo.png", GUI.ScreenRect.X, GUI.ScreenRect.Y, GUI.ScreenRect.Width, GUI.ScreenRect.Height, tolerance: 10);
            if (res != null)
            {
                Console.WriteLine("Found");

                /// Find where of the screen Doduo is:
                int x = res[0];
                int y = (int)(res[1] + GUI.ScreenRect.Height * 0.08);

                int posOnMatrixI = (int)Math.Floor((y - GUI.ScreenRect.Y) / GUI.sqmHeight);
                int posOnMatrixJ = (int)Math.Floor((x - GUI.ScreenRect.X) / GUI.sqmWidth);

                Rectangle monsterPos = GUI.ScreenGrid[posOnMatrixI, posOnMatrixJ];
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        private void btnGetBattleList_Click(object sender, EventArgs e)
        {
            txtTests.Text = GUI.GetBattleList();
        }

        private void btnStartCavebot_Click(object sender, EventArgs e)
        {
            Cavebot.Start();
            btnStopCavebot.Visible = !btnStopCavebot.Visible;
        }
        private void btnStopCavebot_Click(object sender, EventArgs e)
        {
            Cavebot.Stop();
            btnStartCavebot.Visible = !btnStartCavebot.Visible;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            MemoryManager.WriteOnMemory((int)Addresses.Offsets.DestinX, 4072);
            MemoryManager.WriteOnMemory((int)Addresses.Offsets.DestinY, 3491);
        }
    }
}
