using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static bool Ready { get; }
    }
}
