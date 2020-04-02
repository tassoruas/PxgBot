using System;
using System.Threading.Tasks;
using AutoIt;
using PxgBot.Helpers;

namespace PxgBot.Classes.Actions
{
    public static class Walk
    {
        public async static Task<bool> WalkTo(PXG.Position destinPosition, bool use = false)
        {
            try
            {
                while (await Character.isAttacking)
                {
                    AutoItX.Sleep(500);
                }

                if (destinPosition.Z != Character.Z)
                {
                    Console.WriteLine("Not on the same floor");
                    AutoItX.Sleep(100);
                    return false;
                }

                PXG.Position lastPosition = new PXG.Position(Character.X, Character.Y, Character.Z);

                int destX = 7;
                destX += destinPosition.X - Character.X;

                int destY = 5;
                destY += destinPosition.Y - Character.Y;

                if (Settings.Debug) Console.WriteLine("Clicked: " + destX + ", " + destY);

                AutoItX.Sleep(100);
                if (Cavebot.Enabled == false) return true;
                if (use == false) InputHandler.MouseClick("left", GUI.ScreenGrid[destX, destY].X + (GUI.ScreenGrid[destX, destY].Width / 2), GUI.ScreenGrid[destX, destY].Y + (GUI.ScreenGrid[destX, destY].Height / 2), speed: 2);
                else InputHandler.MouseClick("right", GUI.ScreenGrid[destX, destY].X + (GUI.ScreenGrid[destX, destY].Width / 2), GUI.ScreenGrid[destX, destY].Y + (GUI.ScreenGrid[destX, destY].Height / 2), speed: 2);

                AutoItX.Sleep(100);
                int counter = 0;
                while (Character.DestinX != -1 || Character.DestinY != -1 || Character.X != lastPosition.X || Character.Y != lastPosition.Y || Character.Z != lastPosition.Z || await Character.isAttacking)
                {
                    counter++;
                    while (await Character.isAttacking)
                    {
                        AutoItX.Sleep(500);
                    }
                    if (Cavebot.Enabled == false) return true;
                    lastPosition = new PXG.Position(Character.X, Character.Y, Character.Z);
                    AutoItX.Sleep(50);
                    if (counter > 50) break;
                }

                if (Character.X != destinPosition.X || Character.Y != destinPosition.Y || Character.Z != destinPosition.Z)
                    return false;

                if (Settings.Debug) Console.WriteLine("End walking");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Walk error: " + ex.Message);
                return true;
            }
        }
    }
}
