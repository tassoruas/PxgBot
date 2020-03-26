using PxgBot.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PxgBot.Classes
{
    static class Character
    {
        public static double HP { get; set; }
        public static int PosX { get; set; }
        public static int PosY { get; set; }
        public static int PosZ { get; set; }
        public static int DestinX { get; set; }
        public static int DestinY { get; set; }

        public static bool isAttacking
        {
            get
            {
                return (ImageSearcher.UseImageSearch("IsAttacking.png", tolerance: 10, transparency: "0xFFFFFF") != null);
            }
        }
    }
}
