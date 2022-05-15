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
        public async static void StartFishing()
        {
            while (Enabled)
            {
                AutoItX.Sleep(3000);
                if (Pokemon.Reviving == false)
                {
                    if (await isFishing())
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
                    if (await isFishing())
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

        public static async Task<bool> isFishing()
        {
            bool result = await Task.Run(() =>
            {
                if (ImageHandler.UseImageSearch("isFishing.png", tolerance: 5) == null)
                    return false;
                else
                    return true;
            });

            return result;
        }
    }
}
