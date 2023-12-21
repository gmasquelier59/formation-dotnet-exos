string[] boissons = new string[] { "Eau Plate", "Eau Gazeuze", "Coca-Cola", "Fanta", "Sprite", "Orangina", "7Up" };

Console.WriteLine("--- Quelle boisson souhaitez-vous ? ---\n");

Console.WriteLine("Liste des boissons disponibles :\n");
int indexBoisson = 1;
Console.ForegroundColor = ConsoleColor.Magenta;
foreach (string boisson in boissons)
{
    Console.WriteLine($"\t{indexBoisson}) {boisson}");
    indexBoisson++;
}
Console.ResetColor();

int choixBoisson;
while(true)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write($"Faites votre choix (1 à {boissons.Length}) : ");
    Console.ResetColor();

    if (!int.TryParse(Console.ReadLine(), out choixBoisson) || choixBoisson < 1 || choixBoisson > boissons.Length)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine("Votre choix de boisson est incorrect !");
        Console.ResetColor();
        continue;
    }

    break;
}

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine($"Votre {boissons[choixBoisson - 1]} est servi...");
Console.ResetColor();