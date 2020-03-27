using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
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
        public static bool Ready { get; } // TODO
        public static void AddSpell(string hotkey, int cooldown)
        {
            PokemonSpell newSpell = new PokemonSpell();
            newSpell.SpellHotkey = "{" + hotkey + "}";
            newSpell.Cooldown = cooldown;
            newSpell.Available = true;
            PokemonSpells.Add(newSpell);
        }
    }


    public class PokemonSpell
    {
        public string SpellHotkey { get; set; }
        public int Cooldown { get; set; }
        public int Order { get; set; }
        public bool Available { get; set; }

        public void Execute()
        {
            InputHandler.SendKeys(new string[] { SpellHotkey }, 100);
        }
    }
}
