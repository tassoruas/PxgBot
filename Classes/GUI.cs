using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PxgBot.Helpers;

namespace PxgBot.Classes
{
    static class GUI
    {
        public static Rectangle BattleRect { get; set; }


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
    }
}
