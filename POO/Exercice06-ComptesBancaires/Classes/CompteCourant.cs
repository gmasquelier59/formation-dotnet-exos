using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Exercice06_ComptesBancaires.Classes
{
    internal class CompteCourant : CompteBancaire
    {
        public override void Afficher()
        {
            AnsiConsole.Write(new Rule($"[blue]{this.GetType().Name}[/]").LeftJustified());
            AnsiConsole.WriteLine();

            var grid = new Grid();

            grid.AddColumn();

            grid.AddRow(new Text[]{
                new Text("Solde"),
            });
            grid.AddRow(new Text[]{
                new Text($"{Solde:C2}", new Style(Solde >= 0 ? Color.Green : Color.Red, Color.Black)).RightJustified()
            });
            AnsiConsole.Write(grid);

            AnsiConsole.WriteLine();
            AfficherOperations();
        }
    }
}
