Console.WriteLine("--- Où est passé mon numéro ? ---");
Console.WriteLine();

Random random = new Random();
List<int> numbers  = new List<int>();
for(int i=0; i<10; i++)
{
    numbers.Add(random.Next(1, 51));
}

Console.WriteLine("Affichage avant triage :");
int increment = 0;
foreach(int number in numbers)
{
    Console.WriteLine(string.Concat(Enumerable.Repeat("  ", increment)) + number);
    increment++;
}

int firstNumber = numbers[0];
numbers.Sort();

Console.WriteLine();
Console.WriteLine("Affichage avant triage :");

increment = 0;
foreach (int number in numbers)
{
    Console.WriteLine(string.Concat(Enumerable.Repeat("  ", increment)) + number);
    increment++;
}

Console.WriteLine($"Le nombre {firstNumber} se trouvait en 1ère position");
Console.WriteLine($"Il se retrouve à la position {numbers.IndexOf(firstNumber) + 1} après triage");