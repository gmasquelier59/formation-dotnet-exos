using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Spectre.Console.AnsiConsole;

namespace Exercice05.Classes
{
    internal class Salarie
    {
        private const decimal salaireParDefaut = 16236;
        private const decimal salaireMinimum = 1;
        private const decimal salaireMaximum = 1000000;

        private decimal _salaire;

        public string Matricule { get; set; } = "";
        public string Service { get; set; } = "";
        public string Categorie { get; set; } = "";
        public string Nom { get; set; }
        public decimal Salaire
        {
            get => _salaire;
            set
            {
                if (value < salaireMinimum || value > salaireMaximum)
                    throw new ArgumentOutOfRangeException(nameof(value), "Le salaire doit être compris entre {salaireMinimum} et {salaireMaximum} euros");
                SalaireTotal = SalaireTotal - Salaire + value;
                _salaire = value;
            }
        }
        public static decimal SalaireTotal { get; private set; } = 0;
        public static int NombreSalaries { get; private set; } = 0;

        public static decimal SalaireMoyen
        {
            get
            {
                if (NombreSalaries == 0)
                    return 0;

                return SalaireTotal / NombreSalaries;
            }
        }

        public Salarie()
        {
            Nom = "Salarié par défaut";
            Salaire = salaireParDefaut;

            NombreSalaries++;
        }

        public Salarie(string nom, int salaire)
        {
            Nom = nom;
            Salaire = salaire;

            NombreSalaries++;
        }

        public static void AfficherEntreprise()
        {
            Console.WriteLine($"Nombre de salariés : {NombreSalaries}");
            Console.WriteLine($"Salaire total : {SalaireTotal} euros");
            Console.WriteLine($"Salaire moyen : {SalaireMoyen:F2} euros");
        }

        public static void RemiseAZero()
        {
            SalaireTotal = 0;
            NombreSalaries = 0;
        }

        public override string ToString()
        {
            return $"Salarié [nom = {Nom}, salaire = {Salaire}]";
        }

        public virtual void AfficherSalaire()
        {
            Console.MarkupLine($"[blue]{Nom}[/] ({GetType().Name})");
            Console.WriteLine();
            Console.MarkupLine($"\tSalaire : [red]{Salaire} euros[/]");
        }
    }
}