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


        public static uint PxgPointerAddress = 0x007C5320; // Base PXG Client pointer address
        public static string PxgProcessName = "pxgclient"; // Name of PXG Proccess
        public static string PxgClientName = "PXG Client"; // Name of window
        public static IntPtr PxgHandle;
        public enum Offsets
        {
            PokeHP = 0x3e8, // Pokemon current HP
            CharHP = 0x3b0, // Character current HP
            PosX = 0xC, // Position X of character
            PosY = 0x10, // Position Y of character
            PosZ = 0x14, // Position Z of character
            DestinX = 0x2c4, // Destin X of where character is going to when auto walking
            DestinXConf = 0x2d0,
            DestinY = 0x2c8, // Destin Y of where character is going to when auto walking
            DestinYConf = 0x2d4,
        }

        public static void RegisterHandle()
        {
            PxgHandle = FindWindow(null, PxgClientName);
        }
    }

}
