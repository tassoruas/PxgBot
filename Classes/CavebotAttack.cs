using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using PxgBot.Helpers;
using AutoIt;

namespace PxgBot.Classes
{
    public static class CavebotAttack
    {
        static bool Enabled { get; set; }
        public static List<string> MonstersToAttack = new List<string>();

        public static bool isEnabled()
        {
            return Enabled;
        }

        public async static void Start()
        {
            try
            {
                Enabled = true;
                while (Enabled)
                {
                    if (await Character.isAttacking == false)
                    {
                        foreach (string monster in MonstersToAttack)
                        {
                            Rectangle res = FindMonster(monster);
                            if (res.IsEmpty == false)
                            {
                                //Console.WriteLine("Monster '" + monster + "' found");
                                AttackMonster(res);
                                break;
                            }
                            //Console.WriteLine("Monster '" + monster + "' NOT found");
                        }
                        AutoItX.Sleep(350);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cavebot Attack: Start: " + ex.Message);
                return;
            }
        }
        public static void Stop()
        {
            Enabled = false;
        }
        public static Rectangle FindMonster(string monsterName)
        {
            try
            {
                int[] res = ImageSearcher.UseImageSearch("Monsters\\" + monsterName + ".png", GUI.ScreenRect.X, GUI.ScreenRect.Y, GUI.ScreenRect.Width, GUI.ScreenRect.Height, tolerance: 10);
                if (res != null)
                {
                    /// Find where of the screen the monster is:
                    int x = res[0];
                    int y = (int)(res[1] + GUI.ScreenRect.Height * 0.08);

                    int posOnMatrixI = (int)Math.Floor((y - GUI.ScreenRect.Y) / GUI.sqmHeight);
                    int posOnMatrixJ = (int)Math.Floor((x - GUI.ScreenRect.X) / GUI.sqmWidth);

                    Rectangle monsterPos = GUI.ScreenGrid[posOnMatrixI, posOnMatrixJ];
                    return monsterPos;
                }
                return new Rectangle();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cavebot Attack: FindMonster: " + ex.Message);
                return new Rectangle();
            }
        }

        private async static void AttackMonster(Rectangle monsterRect)
        {
            try
            {


                if (await Character.isAttacking == false)
                {
                    AutoItX.MouseClick("right", monsterRect.X + (monsterRect.Width / 2), monsterRect.Y + (monsterRect.Height / 3), speed: 3);
                }
                else
                {
                    while (await Character.isAttacking)
                    {
                        foreach (PokemonSpell spell in Pokemon.PokemonSpells)
                        {
                            //Console.WriteLine("CavebotAttack: Available: " + spell.Available);
                            if (spell.Available)
                            {
                                spell.Execute();
                                spell.Available = false;
                                new Task(async () =>
                                {
                                    await Task.Delay(spell.Cooldown * 1000);
                                    spell.Available = true;
                                }).Start();
                                //Console.WriteLine("Spell used");
                                AutoItX.Sleep(2000);
                            }
                        }
                        AutoItX.Sleep(200);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cavebot Attack: AttackMonster: " + ex.Message);
                return;
            }
        }
    }
}
