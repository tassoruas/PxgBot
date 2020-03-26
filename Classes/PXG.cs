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
            int X { get; set; }
            int Y { get; set; }
            int Z { get; set; }

            public Position(int X, int Y, int Z)
            {
                this.X = X;
                this.Y = Y;
                this.Z = Z;
            }
        }
    }
}
