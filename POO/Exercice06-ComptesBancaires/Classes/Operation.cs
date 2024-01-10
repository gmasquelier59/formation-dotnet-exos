using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice06_ComptesBancaires.Classes
{
    public enum OperationStatut
    {
        DEPOT = 1,
        RETRAIT = 2,
        FRAIS = 3
    }
    internal class Operation
    {
        public int Numero { get; set; } = 0;
        public decimal Montant { get; set; } = 0;
        public OperationStatut Statut { get; set; }

        public Operation(int numero, decimal montant, OperationStatut statut)
        {
            Numero = numero;
            Montant = montant;
            Statut = statut;
        }
    }
}
