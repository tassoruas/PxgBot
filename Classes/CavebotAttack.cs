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
        public static bool Enabled { get; set; }
        public static List<string> MonstersToAttack = new List<string>();

        public async static void Start()
        {
            try
            {
                while (true)
                {
                    if (Enabled && Character.X != 0 && Character.HP > 0)
                    {
                        if (await Character.isAttacking == false && Pokemon.Reviving == false)
                        {
                            foreach (string monster in MonstersToAttack)
                            {
                                if (await Character.isAttacking) AutoItX.Sleep(1000);
                                if (Enabled == false) break;
                                Point res = FindMonster(monster);
                                if (res.IsEmpty == false)
                                {
                                    /// Found monster, so will attack it and break the foreach loop
                                    //Console.WriteLine("Monster '" + monster + "' found");
                                    if (Settings.Debug) { Settings.DebugText += "\n Monster '" + monster + "' found"; }
                                    if (await Character.isAttacking) break;
                                    AutoItX.Sleep(100);
                                    bool clickResult = await ClickMonster(res);
                                    AutoItX.Sleep(150);
                                    if (clickResult) break;
                                }
                                //if (Settings.Debug) { Settings.DebugText += "\n Monster '" + monster + "' NOT found"; }
                                //Console.WriteLine("Monster '" + monster + "' NOT found");
                                AutoItX.Sleep(100);

                            }
                        }
                        AutoItX.Sleep(50);
                    }
                    else
                    {
                        AutoItX.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cavebot Attack: Start: " + ex.Message);
                if (Settings.Debug) { Settings.DebugText += "\n Cavebot Attack: Start: " + ex.Message; }
                return;
            }
        }

        public static Point FindMonster(string monsterName)
        {
            try
            {
                int[] res = ImageHandler.UseImageSearch("Monsters\\" + monsterName + ".png", GUI.BattleRect.X, GUI.BattleRect.Y, tolerance: 5);
                if (res != null)
                {
                    /// Find where of the BattleList the monster is:
                    int x = res[0];
                    int y = (int)(res[1] + GUI.BattleRect.Height * 0.01);

                    return new Point(x, y);
                }
                return new Point();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cavebot Attack: FindMonster: " + ex.Message);
                if (Settings.Debug) { Settings.DebugText += "\n Cavebot Attack: FindMonster: " + ex.Message; }
                return new Point();
            }
        }

        private async static Task<bool> ClickMonster(Point monsterRect)
        {
            try
            {
                if (await Character.isAttacking == false)
                {
                    InputHandler.MouseClick("left", monsterRect.X + 20, monsterRect.Y + 5, keepPosition: true);
                    AutoItX.MouseMove(GUI.ScreenGrid[7, 5].X, GUI.ScreenGrid[7, 5].Y, 3);
                    if (await Character.isAttacking) return true;
                    else return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cavebot Attack: AttackMonster: " + ex.Message);
                if (Settings.Debug) { Settings.DebugText += "\n Cavebot Attack: AttackMonster: " + ex.Message; }
                return false;
            }
        }

        public static async void StartSpells()
        {
            while (true)
            {
                if (Enabled && await Character.isAttacking)
                {
                    foreach (PokemonSpell spell in Pokemon.PokemonSpells)
                    {
                        //if (Settings.Debug) { Settings.DebugText += "\n Spell: " + spell.Enabled + ", " + spell.Available; }
                        if (spell.Available && spell.Enabled)
                        {
                            /// Here we need to check if it's attacking again
                            /// because isAttacking state may change during the foreach loop
                            if (await Character.isAttacking == false) break;

                            spell.UseSpell();
                            spell.Available = false;
                            new Task(async () =>
                            {
                                await Task.Delay(spell.Cooldown * 1000);
                                spell.Available = true;
                            }).Start();
                            AutoItX.Sleep(1000);
                        }
                    }
                }
                else
                {
                    AutoItX.Sleep(1000);
                }
            }
        }
    }
}
