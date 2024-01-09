using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Spectre.Console.AnsiConsole;

namespace Exercice05.Classes
{
    internal class Commercial : Salarie
    {
        public decimal ChiffreAffaire { get; private set; }
        public int CommissionEnPourc {  get; private set; }
        public decimal SalaireAvecCommission
        {
            get => Salaire + Commission;
        }
        public decimal Commission
        {
            get => (CommissionEnPourc * ChiffreAffaire) / 100;
        }
        public Commercial() : base()
        {
            ChiffreAffaire = 0;
            CommissionEnPourc = 5;
        }

        public Commercial(string nom, int salaire, decimal chiffreAffaire, int commissionEnPourc) : base(nom, salaire)
        {
            ChiffreAffaire = chiffreAffaire;
            CommissionEnPourc = commissionEnPourc;
        }

        public override string ToString()
        {
            return $"Commercial [nom = {Nom}, salaire de base = {Salaire}, salaire avec commission = {SalaireAvecCommission}, chiffre d'affaire = {ChiffreAffaire}, commission = {CommissionEnPourc}%]";
        }

        public override void AfficherSalaire()
        {
            Console.MarkupLine($"[blue]{Nom}[/] ({GetType().Name})");
            Console.WriteLine();
            Console.MarkupLine($"\tSalaire : [red]{SalaireAvecCommission} euros[/]");
            Console.WriteLine($"\tdont commission : {Commission} euros");
            Console.WriteLine($"\tsalaire de base : {Salaire} euros");
            Console.WriteLine($"\tchiffre d'affaires : {ChiffreAffaire} euros");
            Console.WriteLine($"\ttaux de commission : {CommissionEnPourc} %");
        }
    }
}
