using AutoIt;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PxgBot.Helpers
{
    public static class InputHandler
    {

        [DllImport("user32.dll")]
        static extern bool BlockInput(bool fBlockIt);

        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string ClassName, string WindowName);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }

        public async static void Click(int posX, int posY, string processName)
        {
            Process process = Process.GetProcessesByName(processName).ToList().FirstOrDefault();
            SetForegroundWindow(process.MainWindowHandle);

            Point oldMousePosition = Cursor.Position;
            Cursor.Position = new Point(posX, posY);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            await Task.Run(() => Task.Delay(1));
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
            //Cursor.Position = oldMousePosition;
        }

        public static void SendKeys(string[] Keys, int DelayBetweenKeys = 100)
        {
            AutoItX.WinActivate(Addresses.PxgHandle);
            AutoItX.Sleep(100);
            foreach (string key in Keys)
            {
                //Console.WriteLine("Key send: " + key);
                AutoItX.WinActivate(Addresses.PxgHandle);
                AutoItX.Send(key);
                AutoItX.Sleep(DelayBetweenKeys);
            }
        }

        public static void BlockUserInput(bool value)
        {
            BlockInput(value);
        }
    }
}
