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

        /// <summary>
        /// Function that calls ImageSearch
        /// </summary>
        /// <param name="imgPath">File path</param>
        /// <param name="tolerance">0 to 255</param>
        /// <returns></returns>
        public static int[] UseImageSearch(string imgName, int tolerance)
        {
            string imgPath = Application.StartupPath + "\\Images\\" + imgName;

            imgPath = "*" + tolerance + " " + imgPath;

            IntPtr result = ImageSearch(0, 0, 3840, 1080, imgPath);
            string res = Marshal.PtrToStringAnsi(result);

            Console.WriteLine("res: " + res);

            if (res[0] == '0') return null;

            string[] data = res.Split('|');

            int x; int y;
            int.TryParse(data[1], out x);
            int.TryParse(data[2], out y);

            return new int[] { x, y };
        }

        public static string Tesseract(string imgName)
        {
            Console.WriteLine("img name: " + imgName);
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
                string line = proc.StandardOutput.ReadLine() + '\n';
                if (line == "" || line == " " || line == "\n") { }
                else output += line;
            }

            proc.Dispose();
            return output;
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);
        public static Bitmap GetPxgScreenshoot()
        {
            Bitmap bmp = new Bitmap(1920, 1080);
            using (Graphics graphics = Graphics.FromImage(bmp as Image))
            {
                graphics.CopyFromScreen(0, 0, 0, 0, bmp.Size);
            }
            return bmp;
        }
    }
}
