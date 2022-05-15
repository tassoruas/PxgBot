using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PxgBot.Helpers
{
    public static class Addresses
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string ClassName, string WindowName);

        public static uint PxgPointerAddress = 0x00CE9380; // Base PXG Client pointer address
        public static string PxgProcessName = "pxgme"; // Name of PXG Proccess
        public static string PxgClientName = "PokeXGames"; // Name of window
        public static IntPtr PxgHandle;
        public enum Offsets
        {
            PokeHP = 0x3F0, // Pokemon current HP
            PokeMaxHP = 0x3F8, // Pokemon maximum HP
            CharHP = 0x3B8, // Character current HP
            CharMaxHP = 0x3C0, // Character maximum HP
            CharName = 0x34, // Character name
            PosX = 0x10, // Position X of character
            PosY = 0x14, // Position Y of character
            PosZ = 0xC, // Position Z of character
            DestinX = 0x2F0, // Destin X of where character is going to when auto walking
            DestinY = 0x2F4, // Destin Y of where character is going to when auto walking
        }

        public static void RegisterHandle()
        {
            PxgHandle = FindWindow(null, PxgClientName);
        }
    }

}
