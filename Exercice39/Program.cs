string[] names = {"Kath Holder", "Diane Hatton", "Sandy Grainger", "Jeremy Hutchinson", "Brenda Jamieson", "Mohammad Aldridge", "Natalie Hoare", "Gilbert Tyler", "Craig Jackson", "Eddie FitzGerald", "Isabel Robbins", "Lucy Whittaker", "Kathryn Schofield", "Marcus Hatton", "Roxanne Bowen", "Ernest Cohen", "Maria Franklin", "Faye MacKenzie", "Flora Mohammed", "Ali Clark", "Daren Tattersall", "Sheryl Hayes", "Wayne Dawes", "Edwina Meredith", "Peter Clifford", "Steve Lilley", "Felix Clarkson", "Steph Herbert", "Victoria Brown", "Elisabeth Birch"};

List<string> availaibleNames = new List<string>(names);
List<string> choosenNames = new List<string>();

Console.WriteLine("--- Le grand tirage au sort ---");
Console.WriteLine();

while(true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("1 --- Effectuer un tirage");
    Console.WriteLine($"2 --- Voir la liste des personnes déjà tirées ({choosenNames.Count})");
    Console.WriteLine($"3 --- Voir la liste des personnes restantes ({availaibleNames.Count})");
    Console.WriteLine("0 --- Quitter");
    Console.ResetColor();

    Console.WriteLine();
    Console.Write("Faites votre choix : ");
    int choice;
    while(!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 3)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\tSaisie incorrecte !");
        Console.ResetColor();
        Console.Write("Faites votre choix : ");
    }

    Console.Clear();
    string tabulation;

    switch (choice)
    {
        case 1:
            Random random = new Random();

            int index = random.Next(0, availaibleNames.Count);
            string choosenName = availaibleNames.ElementAt(index);
            availaibleNames.RemoveAt(index);
            choosenNames.Add(choosenName);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔" + string.Concat(Enumerable.Repeat("═", 33 + choosenName.Length)) + "╗");
            Console.WriteLine($"║ L'heureux(se) gagnant(e) est {choosenName} ! ║");
            Console.WriteLine("╚" + string.Concat(Enumerable.Repeat("═", 33 + choosenName.Length)) + "╝");
            Console.ResetColor();
            Console.WriteLine();

            if (availaibleNames.Count == 0)
            {
                availaibleNames = new List<string>(names);
                choosenNames.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Tous les noms ont été tirés au sort, une nouvelle série commence !");
                Console.ResetColor();
                Console.WriteLine();
            }

            break;
        case 2:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔═════════════════════════════════╗");
            Console.WriteLine("║ Liste des personnes déjà tirées ║");
            Console.WriteLine("╚═════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            if (choosenNames.Count == 0)
            {
                Console.WriteLine("(liste vide)");
                Console.WriteLine();
                break;
            }

            tabulation = "";
            foreach (string name in choosenNames)
            {
                Console.WriteLine(tabulation + name);
                tabulation += "  ";
            }
            Console.WriteLine();
            break;
        case 3:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ Liste des personnes restantes ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            if (availaibleNames.Count == 0)
            {
                Console.WriteLine("(liste vide)");
                Console.WriteLine();
                break;
            }

            tabulation = "";
            foreach(string name in availaibleNames)
            {
                Console.WriteLine(tabulation + name);
                tabulation += "  ";
            }
            Console.WriteLine();
            break;
        case 0:
            return;
    }
}