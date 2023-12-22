Console.WriteLine("--- Acroissement de population ---\n");

const double populationInitale = 96809;
const double populationAAtteindre = 120000;
const int anneeInitiale = 2015;
const double tauxAcroissement = 0.89;

int annee = anneeInitiale;
double population;
for(population = populationInitale; population <= populationAAtteindre; population += (population * tauxAcroissement) / 100)
{
    annee++;
}
Console.WriteLine($"A Tourcoing, en {anneeInitiale}, avec une population de départ de {populationInitale:N0} habitants et un taux d'acroissement annuel de {tauxAcroissement:N}%, pour atteindre {populationAAtteindre:N0} habitants :\n");
Console.WriteLine($"\t- il faudra {annee - anneeInitiale} ans, nous serons en {annee}");
Console.WriteLine($"\t- il y aura {Math.Ceiling(population):N0} habitants en {annee}");