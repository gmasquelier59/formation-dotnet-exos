using Exercice07_Figure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice07_Figure.Classes
{
    internal abstract class Figure : IDeplacable
    {
        public Point Origine { get; init; }

        public Figure(int x, int y) {
            Origine = new Point(x, y);
        }
        public void Deplacer(int x, int y)
        {
            Origine.Deplacer(x, y);
            CalculerPoints();
        }
        public abstract void CalculerPoints();
    }
}
