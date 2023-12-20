Console.WriteLine("--- Calcul des intérêts ---");
Console.WriteLine();

Console.Write("Entrez le capital de départ (en euros) : ");
double capital = double.Parse(Console.ReadLine());

Console.Write("Entrez le taux d'intérêt (en %) : ");
double rate = double.Parse(Console.ReadLine());

Console.Write("Entrez la durée de l'épargne (en années) : ");
int years = int.Parse(Console.ReadLine());

double newCapital = capital * Math.Pow((1 + (rate / 100)), years);

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"Le montant des intérêts sera de {(newCapital - capital):F2} euros après {years} an{(years > 1 ? 's': '\0')}");
Console.WriteLine($"Le capital final sera de {newCapital:F2} euros");
Console.ResetColor();
