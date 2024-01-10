using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice07_Figure.Classes
{
    internal class Rectangle : Figure
    {
        public int Longueur { get; init; }
        public int Largeur { get; init; }

        private Point PointA { get; init; } = new Point();
        private Point PointB { get; init; } = new Point();
        private Point PointC { get; init; } = new Point();
        private Point PointD { get; init; } = new Point();

        public Rectangle(int x, int y, int longueur, int largeur) : base(x, y)
        {
            Longueur = longueur;
            Largeur = largeur;

            CalculerPoints();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("A" + string.Concat(Enumerable.Repeat("─", Longueur * 2)) + "B");
            for (int i = 0; i < Largeur; i++)
                sb.AppendLine("│" + string.Concat(Enumerable.Repeat(" ", Longueur * 2)) + "│");
            sb.AppendLine("D" + string.Concat(Enumerable.Repeat("─", Longueur * 2)) + "C");
            sb.AppendLine();
            sb.AppendLine($"Coordonnées du rectangle ABCD, origine en A (longueur = {Longueur}, largeur = {Largeur})");
            sb.AppendLine($"A = " + PointA);
            sb.AppendLine($"B = " + PointB);
            sb.AppendLine($"C = " + PointC);
            sb.AppendLine($"D = " + PointD);

            return sb.ToString();
        }

        public override void CalculerPoints()
        {
            PointA.Deplacer(Origine.PosX, Origine.PosY);
            PointB.Deplacer(Origine.PosX + Longueur, Origine.PosY);
            PointC.Deplacer(Origine.PosX + Longueur, Origine.PosY + Largeur);
            PointD.Deplacer(Origine.PosX, Origine.PosY + Largeur);
        }
    }
}
