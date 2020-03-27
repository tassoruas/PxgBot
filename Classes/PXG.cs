using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PxgBot.Classes
{
    public static class PXG
    {
        /// <summary>
        /// X, Y, Z position
        /// </summary>
        public class Position
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }

            public Position(int X, int Y, int Z)
            {
                this.X = X;
                this.Y = Y;
                this.Z = Z;
            }
        }
    }
}
