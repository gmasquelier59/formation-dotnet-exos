using System.Collections.Concurrent;

Console.WriteLine("--- Question à choix multiple ---");
Console.WriteLine();
Console.WriteLine("Quelle est l'expression qui permet de sortir d'une boucle en C# ?");
Console.WriteLine("\ta) quit");
Console.WriteLine("\tb) continue");
Console.WriteLine("\tc) break");
Console.WriteLine("\td) exit");
Console.WriteLine();

while (true)
{
    Console.Write("Entrez votre réponse : ");
    string answer = Console.ReadLine().ToLower();
    if (answer != "c")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Réponse incorrecte !");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Un nouvel essai ? (oui/non) ");
        string retry = Console.ReadLine().ToLower();
        if (retry == "oui")
            continue;

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine();
        Console.WriteLine("Dommage :-/");
        Console.ResetColor();
        break;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Bravo !!! C'est la bonne réponse");
        break;
    }
}

Console.ResetColor();