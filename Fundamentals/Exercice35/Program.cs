Console.WriteLine("===== Gestion des contacts ======");
Console.WriteLine();

Console.Write("Merci de saisir le nombre de contacts (1 à 10) : ");
int nbContacts;
while (!int.TryParse(Console.ReadLine(), out nbContacts) || nbContacts < 1 || nbContacts > 10)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Le nombre de contacts doit être compris entre 1 et 10 !");
    Console.ResetColor();
    Console.WriteLine();
    Console.Write("Merci de saisir le nombre de contacts (1 à 10) : ");
}

Console.Clear();

List<string> contacts = new List<string>();
while (true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("----- Ma liste de contacts -----");
    Console.WriteLine();
    Console.WriteLine("1 -> Saisir des contacts");
    Console.WriteLine($"2 -> Afficher mes contacts ({contacts.Count} actuellement)");
    Console.WriteLine("0 -> Quitter");
    Console.WriteLine();
    Console.Write("Faites votre choix : ");
    int choice;
    while (!int.TryParse(Console.ReadLine()!, out choice) || choice < 0 || choice > 2)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Choix incorrecte !");
        Console.ResetColor();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Faites votre choix : ");
    }
    Console.ResetColor();

    switch (choice)
    {
        case 1:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--- Saisir des contacts ---");
            Console.ResetColor();
            Console.WriteLine();

            contacts = new List<string>();
            for(int i=0; i < nbContacts; i++)
            {
                Console.Write($"Nom et prénom du contact n°{i + 1} sur {nbContacts} : ");
                contacts.Add(Console.ReadLine());
            }
            Console.Clear();
            break;
        case 2:
            Console.Clear();

            if (contacts.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aucun contact saisi pour le moment !");
                Console.ResetColor();
                Console.WriteLine();
                continue;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--- Afficher mes contacts ---");
            Console.ResetColor();
            Console.WriteLine();
            for(int i=0; i<nbContacts; i++)
            {
                Console.WriteLine($"\t- Contact n°{i + 1} : " + contacts[i]);
            }
            Console.WriteLine();
            break;
        case 0:
            Environment.Exit(0);
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Saisie incorrecte !");
            Console.ResetColor();
            continue;
    }
}