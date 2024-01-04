Dictionary<string, string> boissons = new Dictionary<string, string>();
boissons.Add("1", "Eau plate");
boissons.Add("2", "Eau gazeuze");
boissons.Add("3", "Coca-cola");
boissons.Add("4", "Fanta");
boissons.Add("5", "Sprite");
boissons.Add("6", "Orangina");
boissons.Add("7", "7Up");

Console.WriteLine("--- Quelle boisson souhaitez-vous ? ---\n");

Console.WriteLine("Liste des boissons disponibles :\n");
Console.ForegroundColor = ConsoleColor.Magenta;
foreach(KeyValuePair<string, string> boisson in boissons)
{
    Console.WriteLine($"\t{boisson.Key}) {boisson.Value}");
}
Console.ResetColor();

string choixBoisson;
while(true)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write($"Faites votre choix de boisson ([{String.Join(',', boissons.Keys)}] ou [q] pour partir sans boisson) : ");
    Console.ResetColor();

    choixBoisson = Console.ReadLine() ?? "";

    if (choixBoisson == "q")
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("A bientôt :-)");
        Console.ResetColor();
        return;
    }
    
    if (!boissons.Keys.Contains(choixBoisson))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Beep();
        Console.Error.WriteLine("Votre choix de boisson est incorrect !");
        Console.ResetColor();
        continue;
    }

    break;
}

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine($"Votre {boissons[choixBoisson]} est servi...");
Console.ResetColor();