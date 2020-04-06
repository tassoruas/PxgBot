using AutoIt;
using PxgBot.Classes;
using System;
using System.Collections.Generic;
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
        private static extern IntPtr FindWindow(string ClassName, string WindowName);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void MouseClick(string button, int x, int y, int speed = -1, bool keepPosition = false)
        {
            AutoItX.WinActivate(Addresses.PxgHandle);
            Point oldMousePosition = Cursor.Position;
            AutoItX.MouseMove(x, y, speed);
            AutoItX.MouseDown(button);
            AutoItX.Sleep(15);
            AutoItX.MouseUp(button);
            if (keepPosition) AutoItX.MouseMove(oldMousePosition.X, oldMousePosition.Y, speed);
        }

        public static void SendKeys(string[] Keys, int DelayBetweenKeys = 100)
        {
            AutoItX.WinActivate(Addresses.PxgHandle);
            foreach (string key in Keys)
            {
                if (Settings.Debug) { Settings.DebugText += "\n Key send: " + key; }
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
