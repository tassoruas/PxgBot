using System;
using System.Threading.Tasks;
using AutoIt;
using PxgBot.Helpers;

namespace PxgBot.Classes.Actions
{
    public static class Walk
    {
        public async static Task<bool> WalkTo(PXG.Position destinPosition, string button)
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

                AutoItX.Sleep(30);

                if (Cavebot.Enabled == false) return true;
                if (Pokemon.Reviving) return true;
                while (await Character.isAttacking)
                {
                    AutoItX.Sleep(500);
                }
                if (Pokemon.HP == 0 || (Pokemon.AutoRevive && Pokemon.HP < Pokemon.AutoReviveHP)) return true;

                InputHandler.MouseClick(button, GUI.ScreenGrid[destX, destY].X + (GUI.ScreenGrid[destX, destY].Width / 2), GUI.ScreenGrid[destX, destY].Y + (GUI.ScreenGrid[destX, destY].Height / 2));
                AutoItX.Sleep(500);
                int counter = 0;
                while (true)
                {
                    counter++;
                    while (await Character.isAttacking)
                    {
                        AutoItX.Sleep(500);
                    }
                    if (Cavebot.Enabled == false) return true;
                    AutoItX.Sleep(200);
                    lastPosition = new PXG.Position(Character.X, Character.Y, Character.Z);
                    AutoItX.Sleep(50);
                    if (Character.X == destinPosition.X && Character.Y == destinPosition.Y && Character.Z == destinPosition.Z)
                    {
                        return true;
                    }
                    if (counter > 20)
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Walk error: " + ex.Message);
                return true;
            }
        }
    }
}
