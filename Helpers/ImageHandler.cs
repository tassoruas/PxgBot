using PxgBot.Classes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PxgBot.Helpers
{
    public static class ImageHandler
    {
        [DllImport("ImageSearch.dll")]
        private static extern IntPtr ImageSearch(int x, int y, int right, int bottom, [MarshalAs(UnmanagedType.LPStr)]string imagePath);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        /// <summary>
        /// Function that calls ImageSearch.
        /// ImageSearch runs searching for the picture in your screen
        /// </summary>
        /// <param name="imgPath">File path</param>
        /// <param name="tolerance">0 to 255</param>
        /// <returns></returns>
        public static int[] UseImageSearch(string imgName, int x = 0, int y = 0, int width = 0, int height = 0, int tolerance = 10, string transparency = "0xFF0000")
        {
            if (x == 0) x = GUI.WindowRect.X;
            if (y == 0) y = GUI.WindowRect.Y;
            if (width == 0) width = GUI.WindowRect.Width + (10 - GUI.WindowRect.Width % 10);
            if (height == 0) height = GUI.WindowRect.Height + (10 - GUI.WindowRect.Height % 10);

            string imgPath = Application.StartupPath + "\\Images\\" + imgName;
            if (System.IO.File.Exists(imgPath) == false)
            {
                if (Settings.Debug) { Settings.DebugText += "\n Error: Image '" + imgName + "' does not exist on path +" + imgPath; }
                Console.WriteLine("Error: Image '" + imgName + "' does not exist on path +" + imgPath);
                return null;
            }

            if (transparency != "" && transparency != null)
            {
                imgPath = "*Trans" + transparency + " " + imgPath;
            }

            if (tolerance > 0 && tolerance < 256)
            {
                imgPath = "*" + tolerance + " " + imgPath;
            }

            IntPtr result = ImageSearch(x, y, width, height, imgPath);
            string res = Marshal.PtrToStringAnsi(result);

            if (res[0] == '0') return null;

            string[] data = res.Split('|');

            int resX; int resY;
            int.TryParse(data[1], out resX);
            int.TryParse(data[2], out resY);

            return new int[] { resX, resY };
        }

        public static string Tesseract(string imgName)
        {
            string imgPath = Application.StartupPath + "\\Images\\" + imgName;
            Process proc = new Process();
            ProcessStartInfo start = new ProcessStartInfo
            {
                FileName = "tesseract",
                Arguments = imgPath + " stdout -l eng",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            proc.StartInfo = start;

            proc.Start();

            string output = "";
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                if (line == "" || line == " " || line == "\n" || line.Length < 4) { }
                else output += line + '\n';
            }

            proc.Dispose();
            return output;
        }

        public static Bitmap GetPxgScreenshoot()
        {
            Bitmap bmp = new Bitmap(GUI.WindowRect.Width, GUI.WindowRect.Height);
            using (Graphics graphics = Graphics.FromImage(bmp as Image))
            {
                graphics.CopyFromScreen(GUI.WindowRect.X, GUI.WindowRect.Y, 0, 0, new Size(GUI.WindowRect.Width, GUI.WindowRect.Height));
            }
            return bmp;
        }

        /// <summary>
        /// PXG printscreen with cropped area
        /// </summary>
        /// <param name="cropRect"></param>
        /// <returns></returns>
        public static Bitmap GetPxgScreenshoot(Rectangle cropRect)
        {
            Bitmap bmp = GetPxgScreenshoot();
            Bitmap output = new Bitmap(cropRect.Width, cropRect.Height);
            using (Graphics g = Graphics.FromImage(output))
            {
                g.DrawImage(bmp, new Rectangle(0, 0, cropRect.Width, cropRect.Height), cropRect, GraphicsUnit.Pixel);
            }
            return output;
        }

        public static Rectangle FindObjectSQM(string imagePath)
        {

            var res = UseImageSearch(imagePath, GUI.ScreenRect.X, GUI.ScreenRect.Y, GUI.ScreenRect.Width, GUI.ScreenRect.Height, tolerance: 10);
            if (res != null)
            {
                /// Find where of the screen Doduo is:
                int x = res[0];
                int y = (int)(res[1] + GUI.ScreenRect.Height * 0.08);

                int posOnMatrixI = (int)Math.Floor((y - GUI.ScreenRect.Y) / GUI.sqmHeight);
                int posOnMatrixJ = (int)Math.Floor((x - GUI.ScreenRect.X) / GUI.sqmWidth);

                Console.WriteLine("Pos: " + posOnMatrixI + "," + posOnMatrixJ);
                Rectangle monsterPos = GUI.ScreenGrid[posOnMatrixI, posOnMatrixJ];
                return monsterPos;
            }
            else
            {
                Console.WriteLine("Not Found");
                return new Rectangle();
            }
        }
    }
}
