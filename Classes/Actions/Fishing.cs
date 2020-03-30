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
        public static bool Enabled { get; set; }
        public async static void StartFishing()
        {
            while (Enabled)
            {
                AutoItX.Sleep(2000);
                if (Pokemon.Reviving == false)
                {
                    if (await isFishing())
                    {
                        Console.WriteLine("Player is already fishing!");
                    }

                    if (Enabled)
                        InputHandler.SendKeys(new string[] { "{CTRLDOWN}", "{z}", "{CTRLUP}" }, 50);
                    else break;
                    //Console.WriteLine("Started fishing");
                    AutoItX.Sleep(100);
                    if (Enabled)
                        AutoItX.MouseClick("left", FishingPosition.X, FishingPosition.Y, speed: 3);
                    else break;
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

        public static async Task<bool> isFishing()
        {
            bool result = await Task.Run(() =>
            {
                if (ImageSearcher.UseImageSearch("isFishing.png", tolerance: 5) == null)
                    return false;
                else
                    return true;
            });

            return result;
        }
    }
}
