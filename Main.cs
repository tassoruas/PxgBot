using System;
using System.Windows.Forms;
using PxgBot.Helpers;
using PxgBot.Classes;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PxgBot
{
    public partial class Main : Form
    {
        MemoryManager memoryManager;
        InputHandler input = new InputHandler();

        public Main()
        {
            InitializeComponent();
            Addresses.RegisterHandle();
            memoryManager = new MemoryManager(Addresses.PxgPointerAddress, Addresses.PxgProcessName);
            GUI.BattlePos = new Rectangle(1750, 341, 144, 242);



            ///
            /// Tests
            ///
            int[] imgSearchResult = ImageSearcher.UseImageSearch("ImageSearchTest.png", 10);
            if (imgSearchResult != null)
                Console.WriteLine("imgSearchResult: " + imgSearchResult[0] + ", " + imgSearchResult[1]);
            else
                Console.WriteLine("Image not found");

            ImageSearcher.Tesseract("TesseractTest.png");

            Bitmap bmp = ImageSearcher.GetPxgScreenshoot();
            Graphics g = Graphics.FromImage(bmp as Image);
            g.DrawRectangle(Pens.Red, new Rectangle(new Point(1750, 321), new Size(46, 10)));
            bmp.Save("hello.bmp");

        }

        private void tmrUpdateInfo_Tick(object sender, EventArgs e)
        {
            Pokemon.HP = memoryManager.ReadDouble((int)Addresses.Offsets.PokeHP, 8);
            Character.HP = memoryManager.ReadDouble((int)Addresses.Offsets.CharHP, 8);
            Character.PosX = memoryManager.ReadInt((int)Addresses.Offsets.PosX, 8);
            Character.PosY = memoryManager.ReadInt((int)Addresses.Offsets.PosY, 8);
            Character.PosZ = memoryManager.ReadInt((int)Addresses.Offsets.PosZ, 8);
            //input.Click(963, 498, Addresses.PxgProcessName);
        }

        private async void tmrTest_Tick(object sender, EventArgs e)
        {
            GUI.DrawOnScreen(GUI.BattlePos);
            string result = await Task.Run(() => GUI.GetBattleList());
        }
    }
}
