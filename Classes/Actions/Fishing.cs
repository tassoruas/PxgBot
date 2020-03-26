using PxgBot.Helpers;
using System.Drawing;
using AutoIt;
using System.Threading.Tasks;

namespace PxgBot.Classes.Actions
{
    public static class Fishing
    {
        public async static Task<bool> StartFishing(int x, int y)
        {
            AutoItX.WinActivate(Addresses.PxgHandle);
            AutoItX.Sleep(100);
            AutoItX.Send("{CTRLDOWN}");
            AutoItX.Sleep(100);
            AutoItX.Send("{z}");
            AutoItX.Sleep(100);
            AutoItX.Send("{CTRLUP}");
            AutoItX.Sleep(100);
            System.Console.WriteLine("send");
            AutoItX.MouseClick("left", x, y);
            bool fish = await Task.Run(() => WaitFish());
            AutoItX.WinActivate(Addresses.PxgHandle);
            AutoItX.Sleep(100);
            AutoItX.Send("{CTRLDOWN}");
            AutoItX.Sleep(100);
            AutoItX.Send("{z}");
            AutoItX.Sleep(100);
            AutoItX.Send("{CTRLUP}");
            AutoItX.Sleep(100);
            return fish;
        }
        public static bool WaitFish()
        {
            int counter = 0;
            while (FishReady() == false && counter < 30)
            {
                AutoItX.Sleep(1000);
                counter++;
            }

            if (counter == 30)
                return false;
            else
                return true;

        }

        public static bool FishReady()
        {
            if (ImageSearcher.UseImageSearch("FishReady1.png", 20) != null)
            {
                System.Console.WriteLine("Found on 1");
                return true;
            }
            if (ImageSearcher.UseImageSearch("FishReady2.png", 20) != null)
            {
                System.Console.WriteLine("Found on 2");
                return true;
            }
            if (ImageSearcher.UseImageSearch("FishReady3.png", 20) != null)
            {
                System.Console.WriteLine("Found on 3");
                return true;
            }
            if (ImageSearcher.UseImageSearch("FishReady4.png", 20) != null)
            {
                System.Console.WriteLine("Found on 4");
                return true;
            }
            if (ImageSearcher.UseImageSearch("FishReady5.png", 20) != null)
            {
                System.Console.WriteLine("Found on 5");
                return true;
            }
            if (ImageSearcher.UseImageSearch("FishReady6.png", 20) != null)
            {
                System.Console.WriteLine("Found on 6");
                return true;
            }
            if (ImageSearcher.UseImageSearch("FishReady7.png", 20) != null)
            {
                System.Console.WriteLine("Found on 7");
                return true;
            }

            return false;

        }
    }
}
