using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice06_ComptesBancaires.Classes
{
    internal class CompteEpargne : CompteBancaire
    {
        public int TauxInterets { get; set; } = 2;

        public decimal Interets
        {
            get
            {
                return (Solde * 2) / 100;
            }
        }

        public override void Afficher()
        {
            AnsiConsole.Write(new Rule($"[blue]{this.GetType().Name}[/]").LeftJustified());
            AnsiConsole.WriteLine();

            var grid = new Grid();

            grid.AddColumn();
            grid.AddColumn();

            grid.AddRow(new Text[]{
                new Text("Solde"),
                new Text($"Intérêts à {TauxInterets}%"),
            });
            grid.AddRow(new Text[]{
                new Text($"{Solde:C2}", new Style(Solde >= 0 ? Color.Green : Color.Red, Color.Black)).RightJustified(),
                new Text($"{Interets:C2}")
            });
            AnsiConsole.Write(grid);

            AnsiConsole.WriteLine();
            AfficherOperations();
        }
    }
}
