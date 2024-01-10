using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice06_ComptesBancaires.Classes
{
    internal class Client
    {
        public string Nom {  get; set; }
        public string Prenom { get; set; }
        public string Identifiant { get; set; }
        public List<CompteBancaire> Comptes { get; set; }
        public string Telephone { get; set; }

        public Client(string nom, string prenom, string identifiant, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Identifiant = identifiant;
            Telephone = telephone;
            Comptes = new List<CompteBancaire>();
        }

        public void AjouterCompte(CompteBancaire compteBancaire)
        {
            Comptes.Add(compteBancaire);
        }

        public void Afficher()
        {
            var rule = new Rule($"[red]Client {Nom} {Prenom}[/]");
            AnsiConsole.Write(rule);
            AnsiConsole.WriteLine();

            var grid = new Grid();

            grid.AddColumn();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddColumn();

            grid.AddRow(new Text[]{
                new Text("Nom", new Style(Color.Green, Color.Black)).LeftJustified(),
                new Text("Prénom", new Style(Color.Green, Color.Black)).Centered(),
                new Text("Identifiant", new Style(Color.Red, Color.Black)).RightJustified(),
                new Text("Téléphone", new Style(Color.Blue, Color.Black)).RightJustified()
            });
            grid.AddRow(new Text[]{
                new Text(Nom).LeftJustified(),
                new Text(Prenom).LeftJustified(),
                new Text(Identifiant).RightJustified(),
                new Text(Telephone).RightJustified()
            });
            AnsiConsole.Write(grid);

            AnsiConsole.WriteLine();
            foreach (CompteBancaire compte in Comptes)
            {
                compte.Afficher();
                AnsiConsole.WriteLine();
            }
        }
    }
}
