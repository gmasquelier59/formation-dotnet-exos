using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice07_Figure.Classes
{
    internal class Point
    {
        public double PosX { get; private set; }
        public double PosY { get; private set; }

        public Point()
        {
            PosX = 0;
            PosY = 0;
        }
        public Point(double x, double y)
        {
            PosX = x;
            PosY = y;
        }
        public void Deplacer(double x, double y)
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
