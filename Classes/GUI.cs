using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AutoIt;
using PxgBot.Helpers;

namespace PxgBot.Classes
{
    static class GUI
    {
        public static Rectangle WindowRect { get; set; }
        public static Rectangle ScreenRect { get; set; }
        public static Rectangle BattleRect { get; set; }
        public static Rectangle PokemonRect { get; set; }
        public static double sqmWidth { get; set; }
        public static double sqmHeight { get; set; }
        public static Rectangle[,] ScreenGrid { get; set; }
        public static Point PokeballPosition { get; set; }
        /// Player center rect = [5,7]



        [DllImport("User32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rectangle WindowRect);
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);

        public static void DrawOnScreen(Rectangle rect)
        {
            IntPtr desktop = GetDC(IntPtr.Zero);
            using (Graphics g = Graphics.FromHdc(desktop))
            {
                g.DrawRectangle(Pens.Red, rect);
            }
            ReleaseDC(IntPtr.Zero, desktop);
        }

        public static void OpenBattleList()
        {
            if (ImageSearcher.UseImageSearch("Battle.png", tolerance: 20) == null)
            {
                InputHandler.SendKeys(new string[] { "{CTRLDOWN}", "{b}", "{CTRLUP}" }, 100);
            }
        }

        public static string GetBattleList()
        {
            try
            {
                DrawOnScreen(BattleRect);
                Bitmap print = ImageSearcher.GetPxgScreenshoot(BattleRect);
                Bitmap resizedImage1 = new Bitmap(print, new Size(print.Width * 3, Convert.ToInt32(print.Height * 1.5)));
                Bitmap resizedImage2 = new Bitmap(print, new Size(print.Width * 8, print.Height * 5));
                Random rnd = new Random();
                int newNumber = rnd.Next(0, 999999);
                resizedImage1.Save("resized1" + newNumber + ".bmp");
                resizedImage2.Save("resized2" + newNumber + ".bmp");

                string resizedText1 = ImageSearcher.Tesseract("resized1" + newNumber + ".bmp");
                string resizedText2 = ImageSearcher.Tesseract("resized2" + newNumber + ".bmp");
                resizedText1 = Regex.Replace(resizedText1, @"[^0-9a-zA-Z:,\n]+", "");
                resizedText2 = Regex.Replace(resizedText2, @"[^0-9a-zA-Z:,\n]+", "");
                print.Dispose();
                resizedImage1.Dispose();
                resizedImage2.Dispose();
                System.IO.File.Delete("resized1" + newNumber + ".bmp");
                System.IO.File.Delete("resized2" + newNumber + ".bmp");

                return resizedText1 + '\n' + resizedText2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("GUI: GetBattleList: " + ex.Message);
                return "error";
            }
        }

        public static void SetBattleBorders()
        {
            OpenBattleList();
            int[] battleIcon = ImageSearcher.UseImageSearch("Battle.png", tolerance: 20);

            if (battleIcon == null) return;
            int[] battleListEnd = ImageSearcher.UseImageSearch("Screen\\BattleBottomRight.png", battleIcon[0], battleIcon[1], tolerance: 10);

            if (battleListEnd == null)
            {
                battleListEnd = ImageSearcher.UseImageSearch("Screen\\BattleBottomRightWhite.png", battleIcon[0], battleIcon[1], tolerance: 10);
            }
            if (battleListEnd == null) return;

            BattleRect = new Rectangle(battleIcon[0], battleIcon[1], battleListEnd[0] - battleIcon[0], battleListEnd[1] - battleIcon[1] + 15);
        }

        public static void SetScreenBorders()
        {
            int[] topLeft = ImageSearcher.UseImageSearch("Screen\\ScreenTopLeftBorder.png", transparency: "0xFFFFFF");
            int[] bottomRight = ImageSearcher.UseImageSearch("Screen\\ScreenBottomRightBorder.png", transparency: "0xFFFFFF");
            Image screenBottom = Image.FromFile("Images\\Screen\\ScreenBottomRightBorder.png");

            if (topLeft == null || bottomRight == null) return;

            ScreenRect = new Rectangle(topLeft[0], topLeft[1], (bottomRight[0] + screenBottom.Width) - topLeft[0], (bottomRight[1] + screenBottom.Height) - topLeft[1]);
        }

        public static void SetPokemonBorders()
        {
            int[] battleIcon = ImageSearcher.UseImageSearch("Battle.png", tolerance: 20);

            if (battleIcon == null) return;
            int[] battleListEnd = ImageSearcher.UseImageSearch("Screen\\BattleBottomRight.png", battleIcon[0], battleIcon[1], tolerance: 10);

            if (battleListEnd == null)
            {
                battleListEnd = ImageSearcher.UseImageSearch("Screen\\BattleBottomRightWhite.png", battleIcon[0], battleIcon[1], tolerance: 10);
            }
            if (battleListEnd == null) return;

            BattleRect = new Rectangle(battleIcon[0], battleIcon[1], battleListEnd[0] - battleIcon[0], battleListEnd[1] - battleIcon[1] + 15);
        }

        public static void SetScreenGrid()
        {
            ScreenGrid = new Rectangle[11, 15];
            sqmWidth = ScreenRect.Width / 15;
            sqmHeight = ScreenRect.Height / 11;

            double height = ScreenRect.Y;
            for (int i = 0; i < 11; i++)
            {
                double width = ScreenRect.X;
                for (int j = 0; j < 15; j++)
                {
                    Rectangle rec = new Rectangle(Convert.ToInt32(width), Convert.ToInt32(height), Convert.ToInt32(sqmWidth), Convert.ToInt32(sqmHeight));
                    ScreenGrid[i, j] = rec;
                    width += sqmWidth;
                }
                height += sqmHeight;
            }
        }

        public static void SetWindowRect()
        {
            Rectangle outRect = new Rectangle();
            bool windowFound = GetWindowRect(Addresses.PxgHandle, ref outRect);
            if (windowFound)
            {
                WindowRect = outRect;
            }
            else
            {
                Console.WriteLine("SetWindowRect: Window not found");
            }
        }

        public static bool isPxgActive()
        {
            return AutoItX.WinActive(Addresses.PxgClientName) == 1 || AutoItX.WinActive(title: "PXG Bot") == 1;
        }
    }
}
