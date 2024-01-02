Console.WriteLine("--- Trouver le nombre mystère ---");
Console.WriteLine();

Random random = new Random();
int mysteryNumber = random.Next(1, 51);
int numberOfTries = 0;
int userNumber = -1;

while (userNumber != mysteryNumber)
{
    numberOfTries++;

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("\tVeuillez saisir un nombre : ");
    int.TryParse(Console.ReadLine(), out userNumber);

    if (userNumber < mysteryNumber)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\t\tLe nombre mystère est plus grand");
    }

    if (userNumber > mysteryNumber)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\t\tLe nombre mystère est plus petit");
    }

    
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine();
Console.WriteLine("Bravo !!! Vous avez trouvé le nombre mystère !");
Console.WriteLine();
Console.WriteLine($"Vous avez trouvé en {numberOfTries} coups.");
Console.ResetColor();