using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
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
        public static bool HasPokemonSet { get; set; }

        public static void Init()
        {
            if (Pokemon.PokemonSpells.Count == 0 || Pokemon.PokemonSpells.Count < 8)
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

            /// I put this here because WindowRect is not being found easely. 
            /// So I needed to put this like an wait condition
            /// The famous 'gambiarra'. I am very good at that. Hehe
            /// **Definição de gambiarra na internet: Engenharia alternativa.
            if (GUI.WindowRect.Width == 0 || GUI.WindowRect.Height == 0)
            {
                AutoItX.Sleep(2000);
                Task.Run(() => Init());
                return;
            }
            ///

            /// Call this to set Pokeball positions
            isOutside();

            if (Settings.Debug) { Settings.DebugText += "\n AutoReviveHotkey: " + AutoReviveHotkey; }
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
            if (GUI.isPxgActive() == false) AutoItX.WinActivate(Addresses.PxgClientName);
            if (GUI.PokeballPosition.X == 0 || GUI.PokeballPosition.Y == 0 || GUI.PokeballPosition.IsEmpty)
            {
                if (Settings.Debug) { Settings.DebugText += "\n Pokeball position not set for reviving"; }
                Console.WriteLine("Pokeball position not set for reviving");
                return;
            }
            if (Settings.Debug) { Settings.DebugText += "\n Will Revive"; }
            Reviving = true;
            InputHandler.BlockUserInput(true);
            if (HP > 0 && isOutside())
            {
                PutInOrOut();
            }
            //AutoItX.Sleep(30);
            InputHandler.SendKeys(new string[] { AutoReviveHotkey }, 5);
            //AutoItX.Sleep(30);
            InputHandler.MouseClick("left", GUI.PokeballPosition.X, GUI.PokeballPosition.Y, speed: 1);
            //AutoItX.Sleep(30);

            if (isOutside() == false && HP > AutoReviveHP)
            {
                PutInOrOut();
            }
            AutoItX.Sleep(50);
            if (isOutside() == false && HP > AutoReviveHP)
            {
                if (Settings.Debug) { Settings.DebugText += "\n Failed first PutInOrOut"; }
                PutInOrOut();
            }
            InputHandler.BlockUserInput(false);
            AutoItX.Sleep(100);
            Reviving = false;
            Console.WriteLine("End");
        }

        public static void PutInOrOut()
        {
            if (Pokemon.HP > 0 && Character.HP > 0)
            {
                InputHandler.MouseClick("right", GUI.PokeballPosition.X, GUI.PokeballPosition.Y + 15, speed: 1);
                AutoItX.MouseMove(GUI.PokeballPosition.X - 30, GUI.PokeballPosition.Y, 1);
                AutoItX.Sleep(50);
            }
        }

        public static bool isOutside()
        {
            int[] pokeOutside = ImageSearcher.UseImageSearch("PokeOutside.png", x: GUI.WindowRect.X, y: GUI.WindowRect.Y, height: GUI.BattleRect.Y, tolerance: 50);
            if (pokeOutside != null)
            {
                if (Settings.Debug) { Settings.DebugText += "\n Poke was outside: " + pokeOutside[0] + ", " + pokeOutside[1]; }
                GUI.PokeballPosition = new Point(pokeOutside[0], pokeOutside[1] + 15);
                Outside = true;
                HasPokemonSet = true;
                return true;
            }

            int[] pokeInside = ImageSearcher.UseImageSearch("PokeInside.png", x: GUI.WindowRect.X, y: GUI.WindowRect.Y, height: GUI.BattleRect.Y, tolerance: 10);
            if (pokeInside != null)
            {
                if (Settings.Debug) { Settings.DebugText += "\n Poke was inside: " + pokeInside[0] + ", " + pokeInside[1]; }
                GUI.PokeballPosition = new Point(pokeInside[0], pokeInside[1] + 15);
                Outside = false;
                HasPokemonSet = true;
                return false;
            }

            if (pokeOutside == null && pokeInside == null)
            {
                if (Settings.Debug) { Settings.DebugText += "\n Error initializing Pokemon: Pokeball Position not found"; }
            }

            HasPokemonSet = false;
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
