using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice07_Figure.Classes
{
    internal class Carre : Figure
    {
        public int Cote { get; init; }

        private Point PointA { get; init; } = new Point();
        private Point PointB { get; init; } = new Point();
        private Point PointC { get; init; } = new Point();
        private Point PointD { get; init; } = new Point(); 

        public Carre(double x, double y, int cote) : base(x, y)
        {
            Cote = cote;

            CalculerPoints();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("A" + string.Concat(Enumerable.Repeat("─", Cote * 2)) + "B");
            for(int i=0; i<Cote; i++)
                sb.AppendLine("│" + string.Concat(Enumerable.Repeat(" ", Cote * 2)) + "│");
            sb.AppendLine("D" + string.Concat(Enumerable.Repeat("─", Cote * 2)) + "C");
            sb.AppendLine();
            sb.AppendLine($"Coordonnées du carré ABCD, origine en A (côté = {Cote})");
            sb.AppendLine($"A = " + PointA);
            sb.AppendLine($"B = " + PointB);
            sb.AppendLine($"C = " + PointC);
            sb.AppendLine($"D = " + PointD);

            return sb.ToString();
        }

        public override void CalculerPoints()
        {
            PointA.Deplacer(Origine.PosX, Origine.PosY);
            PointB.Deplacer(Origine.PosX + Cote, Origine.PosY);
            PointC.Deplacer(Origine.PosX + Cote, Origine.PosY + Cote);
            PointD.Deplacer(Origine.PosX, Origine.PosY + Cote);
        }
    }
}
