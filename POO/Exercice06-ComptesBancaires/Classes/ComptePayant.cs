using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice06_ComptesBancaires.Classes
{
    internal class ComptePayant : CompteBancaire
    {
        public decimal FraisFixeParOperation { get; set; } = 0.50M;
        public int FraisPctParOperation { get; set; } = 1;

        public override void NouvelleOperation(OperationStatut statut, decimal montant)
        {
            base.NouvelleOperation(statut, montant);
            base.NouvelleOperation(OperationStatut.FRAIS, FraisFixeParOperation + (FraisPctParOperation * montant / 100) );
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
                new Text("Frais par opération")
            });
            grid.AddRow(new Text[]{
                new Text($"{Solde:C2}", new Style(Solde >= 0 ? Color.Green : Color.Red, Color.Black)).RightJustified(),
                new Text($"{FraisFixeParOperation:C2} + {FraisPctParOperation} % du montant")
            }); ;
            AnsiConsole.Write(grid);
            AnsiConsole.WriteLine();

            AfficherOperations();
        }
    }
}
