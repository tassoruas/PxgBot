using System;
using System.Threading.Tasks;
using AutoIt;
using PxgBot.Helpers;

namespace PxgBot.Classes.Actions
{
    public static class Walk
    {
        public async static Task<bool> WalkTo(PXG.Position position)
        {
            while (await Character.isAttacking)
            {
                AutoItX.Sleep(500);
            }
            // TODO
            int counter = 0;
            while (Character.DestinX == -1 || Character.DestinY == -1 || Character.PosX == Character.DestinX || Character.PosY == Character.DestinY)
            {
                if (counter > 4) InputHandler.SendKeys(new string[] { "{RIGHT}" }, 100);
                int rndX = new Random().Next(3, 8);
                int rndY = new Random().Next(4, 10);
                AutoItX.MouseClick("left", GUI.ScreenGrid[rndX, rndY].X + (GUI.ScreenGrid[rndX, rndY].Width / 2), GUI.ScreenGrid[rndX, rndY].Y + (GUI.ScreenGrid[rndX, rndY].Height / 2), 3);
                AutoItX.Sleep(100);
                Character.SetDestinPosition(position.X, position.Y);
                counter++;
                AutoItX.Sleep(50);
            }
            return true;
        }
    }
}
