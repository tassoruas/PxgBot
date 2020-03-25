using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PxgBot.Helpers;

namespace PxgBot.Classes
{
    static class GUI
    {
        public static Rectangle BattlePos { get; set; }


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

        public static string GetBattleList()
        {
            Bitmap print = ImageSearcher.GetPxgScreenshoot();
            Bitmap output = new Bitmap(BattlePos.Width, BattlePos.Height);
            using (Graphics g = Graphics.FromImage(output))
            {
                g.DrawImage(print, new Rectangle(0, 0, BattlePos.Width, BattlePos.Height), BattlePos, GraphicsUnit.Pixel);
            }
            Bitmap resizedImage = new Bitmap(output, new Size(output.Width * 3, Convert.ToInt32(output.Height * 1.5)));
            Random rnd = new Random();
            int newNumber = rnd.Next(0, 999999);
            resizedImage.Save("resized" + newNumber + ".bmp");

            string resizedText = ImageSearcher.Tesseract("resized" + newNumber + ".bmp");
            resizedText = Regex.Replace(resizedText, @"[^0-9a-zA-Z:,\n]+", "");
            resizedImage.Dispose();
            System.IO.File.Delete("resized" + newNumber + ".bmp");

            return resizedText;
        }

        public static bool FishAvailable(Rectangle rect)
        {
            Bitmap fishing = ImageSearcher.GetPxgScreenshoot();
            ImageSearcher.UseImageSearch("", 10);
            return false;
        }
    }
}
