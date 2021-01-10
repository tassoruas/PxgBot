using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PxgBot.Helpers;

namespace PxgBot.Classes
{
    static class Character
    {
        public static double HP
        {
            get => MemoryManager.ReadDouble((int)Addresses.Offsets.CharHP, 8);
        }
        public static int X
        {
            get => MemoryManager.ReadInt((int)Addresses.Offsets.PosX, 8);
        }
        public static int Y
        {
            get => MemoryManager.ReadInt((int)Addresses.Offsets.PosY, 8);
        }
        public static int Z
        {
            get => MemoryManager.ReadInt((int)Addresses.Offsets.PosZ, 8);
        }
        public static int DestinX
        {
            get => MemoryManager.ReadInt((int)Addresses.Offsets.DestinX, 8);
        }
        public static int DestinY
        {
            get => MemoryManager.ReadInt((int)Addresses.Offsets.DestinY, 8);
        }

        public static Task<bool> isAttacking
        {
            get => Task.Run(() => (ImageHandler.UseImageSearch("IsAttacking.png", GUI.BattleRect.X - 60, GUI.BattleRect.Y, tolerance: 10, transparency: "0xFFFFFF") != null));
        }

        public static PXG.Position GetPosition()
        {
            return new PXG.Position(X, Y, Z);
        }

        public static void SetDestinPosition(int x, int y)
        {
            MemoryManager.WriteOnMemory((int)Addresses.Offsets.DestinX, (uint)x);
            MemoryManager.WriteOnMemory((int)Addresses.Offsets.DestinY, (uint)y);
        }
    }
}
