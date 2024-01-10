using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Exercice06_ComptesBancaires.Classes
{
    internal abstract class CompteBancaire
    {
        protected decimal Solde { get; set; } = 0;
        protected string Client { get; set; }
        protected List<Operation> Operations { get; private set; } = new();

        public virtual void NouvelleOperation(OperationStatut statut, decimal montant)
        {
            Operation operation = new Operation(this.Operations.Count + 1, montant, statut);
            Operations.Add(operation);

            if (statut == OperationStatut.DEPOT)
                Solde += montant;

            if (statut == OperationStatut.RETRAIT || statut == OperationStatut.FRAIS)
                Solde -= montant;
        }

        public abstract void Afficher();

        public void AfficherOperations()
        {
            var table = new Table();
            table.AddColumn("Numéro");
            table.AddColumn("Statut");
            table.AddColumn(new TableColumn("Montant").RightAligned());
            foreach (Operation operation in Operations)
                table.AddRow(operation.Numero.ToString(), operation.Statut.ToString(), operation.Statut == OperationStatut.DEPOT ? "[green]" + operation.Montant.ToString() + "[/]" : "[red]" + (operation.Montant * -1).ToString() + "[/]");
            AnsiConsole.Write(table);
        }
    }
}
