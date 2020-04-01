using AutoIt;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PxgBot.Helpers
{
    public static class InputHandler
    {

        [DllImport("user32.dll")]
        static extern bool BlockInput(bool fBlockIt);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string ClassName, string WindowName);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void MouseClick(string button, int x, int y, int numClicks = 1, int speed = -1)
        {
            Point oldMousePosition = Cursor.Position;
            AutoItX.MouseClick(button, x, y, numClicks, speed);
            Cursor.Position = oldMousePosition;
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
