using System;
using System.Collections.Generic;
using System.Timers;
using PxgBot.Helpers;

namespace PxgBot.Classes
{
    static class Pokemon
    {
        public static double HP
        {
            get
            {
                return MemoryManager.ReadDouble((int)Addresses.Offsets.PokeHP, 8);
            }
        }

        public static List<PokemonSpell> PokemonSpells { get; set; }
        public static bool Ready { get; } // TODO
    }

    class PokemonSpell
    {
        string SpellHotkey { get; set; }
        int Cooldown { get; set; }
        int Order { get; set; }
        bool Available
        {
            get { return Available; }
            set
            {
                if (value == true)
                    Available = value;
                else
                {

                }
            }
        }
        //Timer cooldownTimer { set; }

        public void startCooldownTimer()
        {
            //Timer cooldownTimer = new Timer();
            //cooldownTimer.Interval = Cooldown;
            //cooldownTimer.Elapsed += new EventHandler(() => { });
            //cooldownTimer.Start();
        }
    }
}
