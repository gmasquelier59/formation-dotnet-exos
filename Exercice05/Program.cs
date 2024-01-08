using System;
using Exercice05.Classes;
using Spectre.Console;
using Console = Spectre.Console.AnsiConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Salarie> salaries = new List<Salarie>() {
            new Salarie("Chloé", 24000),
            new Salarie("Emma", 30000),
            new Salarie("Georges", 26000),
            new Commercial("Jean-Pierre", 26000, 12000, 10)
        };

        while (true)
        {
            Console.WriteLine("============================");
            Console.MarkupLine("[yellow][bold]=== Gestion des employés ===[/][/]");
            Console.WriteLine("============================");
            Console.WriteLine();

            string choix = Console.Prompt(
                new SelectionPrompt<string>()
                    .Title("[slowblink]Faites votre choix :[/]")
                    .AddChoices(new[] {
                        "1. Ajouter un employé",
                        "2. Afficher le salaire des employés",
                        "3. Rechercher un employé",
                        "0. Quitter"
                    })).Substring(0, 1);

            switch (int.Parse(choix))
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    AjouterEmploye(salaries);
                    break;
                case 2:
                    AfficherSalaires(salaries);
                    break;
                case 3:
                    RechercherEmployer(salaries);
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche pour revenir au menu...");
            System.Console.ReadKey();
            Console.Clear();
        }
    }

    public static void AjouterEmploye(List<Salarie> salaries)
    {
        Console.MarkupLine("[bold][purple]=== Ajouter un(e) employé(e) ===[/][/]");
        Console.WriteLine();

        string choix = Console.Prompt(
            new SelectionPrompt<string>()
                .Title("[slowblink]Statut du nouvel employé :[/]")
                .AddChoices(new[] {
                        "1. Commercial",
                        "2. Autre salarié",
                        "0. Retour au menu"
                })).Substring(0, 1);

        Salarie salarie;
        switch (int.Parse(choix))
        {
            case 0:
                return;
            case 1:
                //  AjouterCommercial();
                break;
            case 2:
                AjouterSalarie(salaries);
                break;
        }
    }

    public static void AjouterSalarie(List<Salarie> salaries)
    {
        var nom = Console.Ask<string>("Nom : ");
        var salaire = Console.Ask<int>("Salaire : ");

        Salarie salarie = new Salarie(nom, salaire);
        salaries.Add(salarie);

        Console.WriteLine("");
        Console.WriteLine("Le salarié a bien été ajouté !");
    }

    public static void RechercherEmployer(List<Salarie> salaries)
    {
        Console.MarkupLine("[bold][purple]=== Rechercher un(e) employé(e) ===[/][/]");
        Console.WriteLine();

        var nom = Console.Ask<string>("Quel est le nom de l'employé(e) à recherche ?").ToLower();
        Console.WriteLine();
        bool trouve = false;
        foreach (Salarie salarie in salaries)
        {
            if (salarie.Nom.ToLower().Contains(nom))
            {
                trouve = true;
                salarie.AfficherSalaire();
                Console.WriteLine();
            }
        }

        if (!trouve)
        {
            Console.MarkupLine($"[red]Aucun employé avec le nom {nom}[/]");
        }
    }

    public static void AfficherSalaires(List<Salarie> salaries)
    {
        Console.MarkupLine("[bold][purple]=== Salaires des employés ===[/][/]");
        Console.WriteLine();

        foreach (Salarie salarie in salaries)
        {
            salarie.AfficherSalaire();
            Console.WriteLine();
        }

        Salarie.AfficherEntreprise();
        Console.WriteLine();
    }
}