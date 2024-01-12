using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice07_Figure.Classes
{
    internal class Point
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Point()
        {
            PosX = 0;
            PosY = 0;
        }
        public Point(int x, int y)
        {
            PosX = x;
            PosY = y;
        }
        public void Deplacer(int x, int y)
        {
            PosX = x;
            PosY = y;
        }
        public override string ToString()
        {
            return $"{PosX};{PosY}";
        }
    }
}
