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
        public static List<string> MonstersToAttack { get; set; }

        public static bool isEnabled()
        {
            return Enabled;
        }

        public async static void Start()
        {
            MonstersToAttack = new List<string>();
            MonstersToAttack.Add("Pidgey");
            Enabled = true;
            while (Enabled)
            {
                if (await Character.isAttacking == false)
                {
                    foreach (string monster in MonstersToAttack)
                    {
                        Rectangle res = await Task.Run(() => FindMonster(monster));
                        if (res.IsEmpty == false)
                        {
                            Console.WriteLine("Monster '" + monster + "' found");
                            AttackMonster(res);
                            break;
                        }
                        Console.WriteLine("Monster '" + monster + "' NOT found");
                    }
                }
                AutoItX.Sleep(500);
            }
        }
        public static void Stop()
        {
            Enabled = false;
        }
        public static Rectangle FindMonster(string monsterName)
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

        private async static void AttackMonster(Rectangle monsterRect)
        {
            AutoItX.MouseClick("right", monsterRect.X + (monsterRect.Width / 2), monsterRect.Y + (monsterRect.Height / 2));
            if (await Character.isAttacking)
            {

            }
        }
    }
}
