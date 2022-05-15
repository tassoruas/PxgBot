using AutoIt;
using System;
using System.Windows.Forms;

namespace PxgBot.Classes
{
    public static class Hotkeys
    {
        public static bool Enabled = false;
        public static string ReviveHotkey = "";
        public static string PauseCavebotHotkey = "";
        public static string PauseAttackerHotkey = "";
        public static void KeyPress(object sender, KeyEventArgs e)
        {
            string key = e.KeyData.ToString();
            //Console.WriteLine("Key press: " + key);
            if (key == ReviveHotkey)
            {
                if (Pokemon.isOutside() == true) Pokemon.PutInOrOut();
                Pokemon.Revive(true);
                AutoItX.Sleep(100);
                if (Pokemon.isOutside() == false) Pokemon.PutInOrOut();
            }
            else if (key == PauseCavebotHotkey)
            {
                if (Cavebot.Script.Count == 0 && Cavebot.Enabled == false)
                {
                    return;
                }
                Cavebot.Enabled = !Cavebot.Enabled;
            }
            else if (key == PauseAttackerHotkey)
            {
                CavebotAttack.Enabled = !CavebotAttack.Enabled;
            }
        }
    }

}
