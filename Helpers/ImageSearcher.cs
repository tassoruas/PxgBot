using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PxgBot.Helpers
{
    static class ImageSearcher
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
        public static int[] UseImageSearch(string imgName, int x = 0, int y = 0, int width = 1920, int height = 1080, int tolerance = 10, string transparency = "0xFF0000")
        {
            string imgPath = Application.StartupPath + "\\Images\\" + imgName;
            if (System.IO.File.Exists(imgPath) == false)
            {
                Console.WriteLine("Image '" + imgName + "' does not exist on path +" + imgPath);
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
            // TODO: get pxg position and search only in its position/size
            Bitmap bmp = new Bitmap(1920, 1080);
            using (Graphics graphics = Graphics.FromImage(bmp as Image))
            {
                graphics.CopyFromScreen(0, 0, 0, 0, bmp.Size);
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
    }
}
