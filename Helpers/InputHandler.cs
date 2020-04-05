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

        public static List<Input> InputQueue;

        public static void Start()
        {
            InputQueue = new List<Input>();
            while (true)
            {
                if (InputQueue.Count > 0)
                {
                    if (InputQueue.Count > 1)
                    {
                        InputQueue = InputQueue.OrderByDescending(x => x.Priority).ToList();
                    }
                    Input first = InputQueue.First();
                    if (first.DelayBetweenKeys != 0)
                    {
                        InternalSendKeys(first);
                    }
                    else
                    {
                        InternalMouseClick(first);
                    }
                    InputQueue.Remove(first);
                }
                else
                {
                    AutoItX.Sleep(100);
                }
            }
        }

        public static void MouseClick(int priority, string button, int x, int y, int speed = -1, bool keepPosition = false)
        {
            Input input = new Input(priority, button, new Point(x, y), speed, keepPosition);
            InputQueue.Add(input);
        }

        private static void InternalMouseClick(Input input)
        {
            AutoItX.WinActivate(Addresses.PxgHandle);
            Point oldMousePosition = Cursor.Position;
            Console.WriteLine("Clicked on: " + input.Button + ", " + input.Point.X + ", " + input.Point.Y);
            AutoItX.MouseMove(input.Point.X, input.Point.Y, input.Speed);
            AutoItX.MouseDown(input.Button);
            AutoItX.Sleep(15);
            AutoItX.MouseUp(input.Button);
            if (input.KeepPosition) AutoItX.MouseMove(oldMousePosition.X, oldMousePosition.Y, input.Speed);
        }

        public static void SendKeys(int priority, string[] Keys, int DelayBetweenKeys = 100)
        {
            Input input = new Input(priority, Keys, DelayBetweenKeys);
            InputQueue.Add(input);
        }

        private static void InternalSendKeys(Input input)
        {
            AutoItX.WinActivate(Addresses.PxgHandle);
            foreach (string key in input.Keys)
            {
                if (Settings.Debug) { Settings.DebugText += "\n Key send: " + key; }
                AutoItX.Send(key);
                AutoItX.Sleep(input.DelayBetweenKeys);
            }
        }

        public static void BlockUserInput(bool value)
        {
            BlockInput(value);
        }
    }

    public class Input
    {
        public int Priority { get; set; }
        public string Button { get; set; }
        public Point Point { get; set; }
        public int Speed { get; set; }
        public bool KeepPosition { get; set; }
        public string[] Keys { get; set; }
        public int DelayBetweenKeys { get; set; }
        public bool Keyboard { get; set; }
        public Input(int priority, string button, Point point, int speed, bool keepPosition)
        {
            Priority = priority;
            Button = button;
            Point = point;
            Speed = speed;
            KeepPosition = keepPosition;
        }

        public Input(int priority, string[] keys, int delayBetweenKeys = 100)
        {
            Priority = priority;
            Keys = keys;
            DelayBetweenKeys = delayBetweenKeys;
        }
    }
}
