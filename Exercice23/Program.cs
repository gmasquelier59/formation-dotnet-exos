Console.WriteLine("--- Acroissement de population ---\n");

int annee = 2015;
double population;
for(population = 96809; population <= 120000; population += (population * 0.89) / 100)
{
    annee++;
}
Console.WriteLine($"Il faudra {annee - 2015} ans, nous serons en {annee}");
Console.WriteLine($"Il y aura {Math.Ceiling(population)} habitants en {annee}");