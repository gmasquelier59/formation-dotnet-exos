Console.WriteLine("--- Calcul du périmètre et de l'aire d'un carré ---");
Console.Write("Entrez la longueur du côté d'un carré (en cm) : ");
decimal length = decimal.Parse(Console.ReadLine());

Console.WriteLine($"Le périmètre du carré est : {length * 4} cm");
Console.WriteLine($"L'aire du carré est : {length * length} cm2");

Console.WriteLine();

Console.WriteLine("--- Calcul du périmètre et de l'aire d'un rectangle ---");
Console.Write("Entrez la longueur du rectangle (en cm) : ");
decimal length1 = decimal.Parse(Console.ReadLine());
Console.Write("Entrez la largeur du rectangle (en cm) : ");
decimal length2 = decimal.Parse(Console.ReadLine());

Console.WriteLine($"Le périmètre du rectangle est : {length1 * 2 + length2 * 2} cm");
Console.WriteLine($"L'aire du rectangle est : {length1 * length2} cm2");