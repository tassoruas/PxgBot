using System;
using System.Threading.Tasks;
using AutoIt;
using PxgBot.Helpers;

namespace PxgBot.Classes.Actions
{
    public static class Fishing
    {
        public async static Task<bool> StartFishing(int x, int y)
        {
            if (await isFishing())
            {
                Console.WriteLine("Player is already fishing!");
                return false;
            }

            InputHandler.SendKeys(new string[] { "{CTRLDOWN}", "{z}", "{CTRLUP}" }, 100);
            Console.WriteLine("Started fishing");
            AutoItX.Sleep(300);
            AutoItX.MouseClick("left", x, y);
            AutoItX.Sleep(20000);
            InputHandler.SendKeys(new string[] { "{CTRLDOWN}", "{z}", "{CTRLUP}" }, 100);
            return true;
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
