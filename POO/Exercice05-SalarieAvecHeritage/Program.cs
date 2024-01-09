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
            Console.Write(new Rule().RuleStyle("red dim"));
            Console.Write(new Rule("[white bold]Gestion des employés[/]").RuleStyle("red"));
            Console.Write(new Rule($"[white]{salaries.Count} employé(s)[/]").RuleStyle("red"));
            Console.Write(new Rule().RuleStyle("red dim"));
            Console.WriteLine();

            List<string> listeChoix = new List<string> {
                "Ajouter un employé",
                "Afficher le salaire des employés",
                "Rechercher un employé",
                "Quitter"
            };
            int choix = listeChoix.IndexOf(Console.Prompt(
                new SelectionPrompt<string>()
                    .Title("[slowblink]Faites votre choix :[/]")
                    .AddChoices(listeChoix))) + 1;

            bool attenteAppuiTouche = true;
            switch (choix)
            {
                case 1:
                    attenteAppuiTouche = AjouterEmploye(salaries);
                    break;
                case 2:
                    AfficherSalaires(salaries);
                    break;
                case 3:
                    RechercherEmployer(salaries);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }

            if (attenteAppuiTouche)
            {
                Console.WriteLine();
                Console.WriteLine("Appuyez sur une touche pour revenir au menu...");
                System.Console.ReadKey();
            }
            Console.Clear();
        }
    }

    public static bool AjouterEmploye(List<Salarie> salaries)
    {
        Console.MarkupLine("[bold][purple]=== Ajouter un(e) employé(e) ===[/][/]");
        Console.WriteLine();

        List<string> listeChoix = new List<string> {
            "Commercial",
            "Autre salarié",
            "Retour au menu"
        };

        int choix = listeChoix.IndexOf(Console.Prompt(
            new SelectionPrompt<string>()
                .Title("[slowblink]Statut du nouvel employé :[/]")
                .AddChoices(listeChoix))) + 1;

        switch (choix)
        {
            case 0:
                return false;
            case 1:
                AjouterCommercial(salaries);
                return true;
            case 2:
                AjouterSalarie(salaries);
                return true;
        }

        return false;
    }

    public static void AjouterCommercial(List<Salarie> salaries)
    {
        var nom = Console.Ask<string>("Nom : ");
        var salaire = Console.Ask<int>("Salaire de base  (en euros) : ");
        var chiffreAffaires = Console.Ask<int>("Chiffre d'affaires (en euros) : ");
        var commission = Console.Ask<int>("Commission (en %) : ");

        Commercial commercial = new Commercial(nom, salaire, chiffreAffaires, commission);
        salaries.Add(commercial);

        Console.WriteLine("");
        Console.WriteLine("Le commercial a bien été ajouté !");
    }

    public static void AjouterSalarie(List<Salarie> salaries)
    {
        var nom = Console.Ask<string>("Nom : ");
        var salaire = Console.Ask<int>("Salaire (en €) : ");

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