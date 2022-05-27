using PxgBot.Helpers;

namespace PxgBot.Classes
{
    static class Character
    {
        public static double HP
        {
            get => MemoryManager.ReadDouble((int)Addresses.General.PlayerPointerAddress, (int)Addresses.PlayerOffsets.CharHP, 8);
        }
        public static int X
        {
            get => MemoryManager.ReadInt((int)Addresses.General.PlayerPointerAddress, (int)Addresses.PlayerOffsets.PosX, 4);
        }
        public static int Y
        {
            get => MemoryManager.ReadInt((int)Addresses.General.PlayerPointerAddress, (int)Addresses.PlayerOffsets.PosY, 4);
        }
        public static int Z
        {
            get => MemoryManager.ReadInt((int)Addresses.General.PlayerPointerAddress, (int)Addresses.PlayerOffsets.PosZ, 4, false);
        }
        public static int DestinX
        {
            get => MemoryManager.ReadInt((int)Addresses.General.PlayerPointerAddress, (int)Addresses.PlayerOffsets.DestinX, 4);
        }
        public static int DestinY
        {
            get => MemoryManager.ReadInt((int)Addresses.General.PlayerPointerAddress, (int)Addresses.PlayerOffsets.DestinY, 4);
        }

        public static bool IsAttacking
        {
            get => MemoryManager.ReadInt((int)Addresses.General.AttackingAddress, 0, 4, false) != 0;
        }
        public static bool IsFishing
        {
            get => MemoryManager.ReadInt((int)Addresses.General.PlayerPointerAddress, (int)Addresses.PlayerOffsets.Addon, 4) == 141;
        }

        public static PXG.Position GetPosition()
        {
            return new PXG.Position(X, Y, Z);
        }

        public static void SetDestinPosition(int x, int y)
        {
            MemoryManager.WriteOnMemory((int)Addresses.General.PlayerPointerAddress, (int)Addresses.PlayerOffsets.DestinX, (uint)x);
            MemoryManager.WriteOnMemory((int)Addresses.General.PlayerPointerAddress, (int)Addresses.PlayerOffsets.DestinY, (uint)y);
        }
    }
}
