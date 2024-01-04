Console.WriteLine("--- Calcul de la longueur de l'hypothénuse ---");

Console.Write("Entrez la longueur du premier côté (en cm) : ");
double length1 = double.Parse(Console.ReadLine());

Console.Write("Entrez la longueur du second côté (en cm) : ");
double length2 = double.Parse(Console.ReadLine());

Console.WriteLine($"La longueur de l'hypothénuse est : { Math.Round( Math.Sqrt(Math.Pow(length1, 2) + Math.Pow(length2, 2)), 2) } cm");