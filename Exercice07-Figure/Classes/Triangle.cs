using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice07_Figure.Classes
{
    internal class Triangle : Figure
    {
        public int Base { get; init; }
        public int Hauteur { get; init; }

        private Point PointA { get; init; } = new Point();
        private Point PointB { get; init; } = new Point();
        private Point PointC { get; init; } = new Point();

        public Triangle(double x, double y, int _base, int hauteur) : base(x, y)
        {
            Base = _base;
            Hauteur = hauteur;

            CalculerPoints();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Concat(Enumerable.Repeat(" ", Base)) + "A");
            for (int i = 0; i < Hauteur; i++)
                sb.AppendLine("");
            sb.AppendLine("C" + string.Concat(Enumerable.Repeat(" ", Base * 2)) + "B");
            sb.AppendLine();
            sb.AppendLine($"Coordonnées du triangle ABC isocèle en A, origine en A (base = {Base}, hauteur = {Hauteur})");
            sb.AppendLine($"A = " + PointA);
            sb.AppendLine($"B = " + PointB);
            sb.AppendLine($"C = " + PointC);

            return sb.ToString();
        }

        public override void CalculerPoints()
        {
            PointA.Deplacer(Origine.PosX, Origine.PosY);
            PointB.Deplacer(Origine.PosX + Base / 2, Origine.PosY + Hauteur);
            PointC.Deplacer(Origine.PosX - Base / 2, Origine.PosY + Hauteur);
        }
    }
}
