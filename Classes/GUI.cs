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
        /// Player center rect = [7,5]
        public static Point PokeballPosition { get; set; }



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
                InputHandler.SendKeys(new string[] { "{CTRLDOWN}", "{b}", "{CTRLUP}" }, 50);
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

            if (battleIcon == null)
            {
                Console.WriteLine("Battle Icon not found");
                return;
            }
            int[] battleListEnd = ImageSearcher.UseImageSearch("Screen\\BattleBottomRight.png", x: battleIcon[0], y: battleIcon[1], tolerance: 15);

            if (battleListEnd == null)
            {
                battleListEnd = ImageSearcher.UseImageSearch("Screen\\BattleBottomRightWhite.png", x: battleIcon[0], y: battleIcon[1], tolerance: 15);
            }

            if (battleListEnd == null)
            {
                Console.WriteLine("Battle list end not found: " + battleIcon[0] + ", " + battleIcon[1] + ", " + GUI.WindowRect.Width + ", " + GUI.WindowRect.Height);
                return;
            }


            int startX = battleIcon[0];
            int startY = battleIcon[1] + 40;
            int endX = battleListEnd[0];
            int endY = battleListEnd[1];

            BattleRect = new Rectangle(startX, startY, endX - startX, endY - startY + 15);
            //Console.WriteLine("Battle borders set: " + startX + ", " + startY + ", " + endX + ", " + endY);
        }

        public static void SetScreenBorders()
        {
            int[] topLeft = ImageSearcher.UseImageSearch("Screen\\ScreenTopLeftBorder.png", transparency: "0xFFFFFF");
            int[] bottomRight = ImageSearcher.UseImageSearch("Screen\\ScreenBottomRightBorder.png", transparency: "0xFFFFFF");
            Image screenBottom = Image.FromFile("Images\\Screen\\ScreenBottomRightBorder.png");

            if (topLeft == null || bottomRight == null)
            {
                Console.WriteLine("Screen borders not set");
                return;
            }

            ScreenRect = new Rectangle(topLeft[0], topLeft[1], (bottomRight[0] + screenBottom.Width) - topLeft[0], (bottomRight[1] + screenBottom.Height) - topLeft[1]);
            //Console.WriteLine("Screen borders set");
        }

        public static void SetScreenGrid()
        {
            ScreenGrid = new Rectangle[15, 11];
            sqmWidth = ScreenRect.Width / 15;
            sqmHeight = ScreenRect.Height / 11;

            double height = ScreenRect.Y;
            for (int y = 0; y < 11; y++)
            {
                double width = ScreenRect.X;
                for (int x = 0; x < 15; x++)
                {
                    Rectangle rec = new Rectangle(Convert.ToInt32(width), Convert.ToInt32(height), Convert.ToInt32(sqmWidth), Convert.ToInt32(sqmHeight));
                    ScreenGrid[x, y] = rec;
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
                //Console.WriteLine("Window Rect found");
                outRect.X += 10;
                outRect.Y += 10;
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
