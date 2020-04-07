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
        public static bool AutoRevive { get; set; }
        public static int AutoReviveHP { get; set; }
        public static int AutoReviveOutOfBattleHP { get; set; }
        public static string AutoReviveHotkey { get; set; }
        public static string FoodHotkey { get; set; }
        public static bool Reviving { get; set; }
        public static bool ReviveCooldown = false;
        public static bool PutOutCooldown = false;
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

        public static void PutOut()
        {
            if (Pokemon.HP > 0 && Character.HP > 0)
            {
                if (isOutside() == false && PutOutCooldown == false)
                {
                    InputHandler.MouseClick("right", GUI.PokeballPosition.X, GUI.PokeballPosition.Y + 10);
                    AutoItX.MouseMove(GUI.PokeballPosition.X - 50, GUI.PokeballPosition.Y, 1);
                    PutOutCooldown = true;
                    Task.Run(async () =>
                    {
                        await Task.Delay(1000);
                        PutOutCooldown = false;
                    });
                    AutoItX.Sleep(100);
                }
            }
        }

        public static void PutIn()
        {
            if (isOutside() == true)
            {
                InputHandler.MouseClick("right", GUI.PokeballPosition.X, GUI.PokeballPosition.Y + 10);
            }
        }

        public static void Revive(bool manual = false)
        {
            try
            {
                if (GUI.isPxgActive() == false) AutoItX.WinActivate(Addresses.PxgClientName);
                if (GUI.PokeballPosition.X == 0 || GUI.PokeballPosition.Y == 0 || GUI.PokeballPosition.IsEmpty)
                {
                    if (Settings.Debug) { Settings.DebugText += "\n Pokeball position not set for reviving"; }
                    Console.WriteLine("Pokeball position not set for reviving");
                    Reviving = false;
                    return;
                }
                if (manual == false && Pokemon.HP > Pokemon.AutoReviveHP)
                {
                    return;
                }

                Reviving = true;
                ReviveCooldown = true;
                if (Settings.Debug) { Settings.DebugText += "\n Will Revive"; }

                /////////////////////////
                if (HP > 0 && isOutside())
                {
                    PutIn();
                }

                InputHandler.BlockUserInput(true);

                AutoItX.Sleep(200);
                if (HP <= AutoReviveHP || manual)
                {
                    InputHandler.SendKeys(new string[] { AutoReviveHotkey }, 5);
                    InputHandler.MouseClick("left", GUI.PokeballPosition.X, GUI.PokeballPosition.Y);
                    Settings.DebugText += "Run Revive";
                }

                InputHandler.BlockUserInput(false);

                foreach (PokemonSpell spell in Pokemon.PokemonSpells)
                {
                    spell.Available = true;
                }
                Task.Run(async () => { await Task.Delay(1000); ReviveCooldown = false; });
                Reviving = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Revive: " + ex.Message);
            }
        }

        public static bool isOutside()
        {
            int[] pokeOutside = ImageSearcher.UseImageSearch("PokeOutside.png", x: GUI.WindowRect.X, y: GUI.WindowRect.Y, height: GUI.BattleRect.Y, tolerance: 50);
            if (pokeOutside != null)
            {
                if (Settings.Debug) { Settings.DebugText += "\n Poke was outside: " + pokeOutside[0] + ", " + pokeOutside[1]; }
                GUI.PokeballPosition = new Point(pokeOutside[0], pokeOutside[1] + 15);
                HasPokemonSet = true;
                return true;
            }

            int[] pokeInside = ImageSearcher.UseImageSearch("PokeInside.png", x: GUI.WindowRect.X, y: GUI.WindowRect.Y, height: GUI.BattleRect.Y, tolerance: 10);
            if (pokeInside != null)
            {
                if (Settings.Debug) { Settings.DebugText += "\n Poke was inside: " + pokeInside[0] + ", " + pokeInside[1]; }
                GUI.PokeballPosition = new Point(pokeInside[0], pokeInside[1] + 15);
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

        public static void EatFood()
        {
            if (GUI.isPxgActive() == false) AutoItX.WinActivate(Addresses.PxgClientName);

            if (Settings.Debug) { Settings.DebugText += "\n Will Eat Food"; }

            if (HasPokemonSet == false)
            {
                return;
            }

            if (FoodHotkey == null) return;

            InputHandler.SendKeys(new string[] { FoodHotkey }, 5);
            AutoItX.Sleep(50);
            InputHandler.MouseClick("left", GUI.BattleRect.X + 20, GUI.BattleRect.Y);

            AutoItX.Sleep(300);

            InputHandler.SendKeys(new string[] { FoodHotkey }, 5);
            AutoItX.Sleep(50);
            InputHandler.MouseClick("left", GUI.ScreenGrid[7, 5].X + (int)(GUI.sqmWidth / 2), GUI.ScreenGrid[7, 5].Y + (int)(GUI.sqmHeight / 2));
            AutoItX.Sleep(30);

            AutoItX.MouseMove(823, 476, 1);
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
