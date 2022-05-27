using System;
using System.Drawing;
using System.Threading.Tasks;
using AutoIt;
using PxgBot.Helpers;

namespace PxgBot.Classes.Actions
{
    public static class Fishing
    {
        public static Point FishingPosition { get; set; }
        public static bool Enabled = false;
        public static void StartFishing()
        {
            while (Enabled)
            {
                AutoItX.Sleep(3000);
                if (Pokemon.Reviving == false)
                {
                    if (Character.IsFishing)
                    {
                        if (Settings.Debug) { Settings.DebugText += "\n Player is already fishing!"; }
                    }

                    if (Enabled)
                    {
                        InputHandler.MouseMove(FishingPosition.X, FishingPosition.Y);
                        AutoItX.Sleep(50);
                        InputHandler.SendKeys(new string[] { "{CTRLDOWN}", "{z}", "{CTRLUP}" }, 50);
                    }
                    else break;
                    AutoItX.Sleep(1000);
                    if (Character.IsFishing)
                    {
                        AutoItX.Sleep(20000);
                        if (Pokemon.Reviving == false)
                        {
                            if (Enabled)
                                InputHandler.SendKeys(new string[] { "{CTRLDOWN}", "{z}", "{CTRLUP}" }, 50);
                            else break;
                        }
                    }
                }
            }
        }
    }
}
