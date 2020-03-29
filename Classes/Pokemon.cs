using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Timers;
using AutoIt;
using PxgBot.Helpers;

namespace PxgBot.Classes
{
    public static class Pokemon
    {
        public static double HP
        {
            get
            {
                return MemoryManager.ReadDouble((int)Addresses.Offsets.PokeHP, 8);
            }
        }

        public static List<PokemonSpell> PokemonSpells = new List<PokemonSpell>();
        public static bool Outside { get; set; } // TODO
        public static bool AutoRevive { get; set; }
        public static int AutoReviveHP { get; set; }
        public static string AutoReviveHotkey { get; set; }
        public static bool Reviving { get; set; }

        public static void Init()
        {
            Pokemon.AddSpell("{F1}", 0, false);
            Pokemon.AddSpell("{F2}", 0, false);
            Pokemon.AddSpell("{F3}", 0, false);
            Pokemon.AddSpell("{F4}", 0, false);
            Pokemon.AddSpell("{F5}", 0, false);
            Pokemon.AddSpell("{F6}", 0, false);
            Pokemon.AddSpell("{F7}", 0, false);
            Pokemon.AddSpell("{F8}", 0, false);
            Pokemon.AddSpell("{F9}", 0, false);
        }

        public static void AddSpell(string hotkey, int cooldown, bool enabled)
        {
            PokemonSpell newSpell = new PokemonSpell();
            newSpell.SpellHotkey = hotkey;
            newSpell.Cooldown = cooldown;
            newSpell.Available = true;
            newSpell.Enabled = enabled;
            PokemonSpells.Add(newSpell);
        }

        public static void Revive()
        {
            Console.WriteLine("Will revive");
            Reviving = true;
            if (isOutside())
            {
                PutInOrOut();
            }
            InputHandler.SendKeys(new string[] { Pokemon.AutoReviveHotkey });
            AutoItX.Sleep(10);
            AutoItX.MouseClick("left", GUI.PokeballPosition.X, GUI.PokeballPosition.Y, speed: 1);
            AutoItX.Sleep(50);
            PutInOrOut();
            AutoItX.Sleep(100);
            AutoItX.MouseMove(500, 500, 1);
            if (isOutside() == false)
            {
                PutInOrOut();
            }
            AutoItX.Sleep(1000);
            Reviving = false;
        }

        public static void PutInOrOut()
        {
            AutoItX.MouseClick("right", GUI.PokeballPosition.X, GUI.PokeballPosition.Y, speed: 1);
            AutoItX.Sleep(10);
        }

        public static bool isOutside()
        {
            int[] pokeInside = ImageSearcher.UseImageSearch("PokeInside.png", x: GUI.ScreenRect.X, y: GUI.ScreenRect.Y, height: GUI.BattleRect.Y, tolerance: 5);
            if (pokeInside != null)
            {
                Outside = false;
                GUI.PokeballPosition = new Point(pokeInside[0], pokeInside[1]);
                return false;
            }

            int[] pokeOutside = ImageSearcher.UseImageSearch("PokeOutside.png", x: GUI.ScreenRect.X, y: GUI.ScreenRect.Y, height: GUI.BattleRect.Y, tolerance: 5);
            if (pokeOutside != null)
            {
                Outside = true;
                GUI.PokeballPosition = new Point(pokeOutside[0], pokeOutside[1]);
                return true;
            }
            return false;
        }
    }


    public class PokemonSpell
    {
        public string SpellHotkey { get; set; }
        public int Cooldown { get; set; }
        public int Order { get; set; }
        public bool Available { get; set; }
        public bool Enabled { get; set; }

        public void UseSpell()
        {
            InputHandler.SendKeys(new string[] { SpellHotkey }, 100);
        }
    }
}
