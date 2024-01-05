using Exercice04.Classes;

WaterTank tank1 = new WaterTank(2, 150, 10);
WaterTank tank2 = new WaterTank(5, 200, 89);

List<WaterTank> waterTanks = new List<WaterTank>
{
    tank1, tank2
};

foreach (WaterTank waterTank in waterTanks)
    Console.WriteLine($"Poids total de la citerne {waterTank.Number} : {waterTank.TotalWeight} kg (poids à vide : {waterTank.WeightEmpty} kg)");

AfficherSeparateur();

AfficherNiveauCiternes();

AfficherSeparateur();

int excessWater = tank1.Fill(60);
Console.WriteLine($"Excès d'eau récupéré après avoir ajouté 60 litres à la citerne 1 : {excessWater} litre(s)");

AfficherSeparateur();

int waterTaken = tank1.Empty(10);
Console.WriteLine($"Eau récupérée après une tentative de retrait de 10 litres sur la citerne 1 : {waterTaken} litre(s)");
AfficherSeparateur();

AfficherNiveauCiternes();

waterTaken = tank1.Empty(8);
Console.WriteLine($"Eau récupérée après une tentative de retrait de 60 litres sur la citerne 1 : {waterTaken} litre(s)");
AfficherSeparateur();

AfficherNiveauCiternes();
AfficherSeparateur();
Console.WriteLine();

tank2.Fill(32);

foreach (WaterTank waterTank in waterTanks)
{
    waterTank.Show();
}

void AfficherSeparateur()
{
    Console.WriteLine(string.Concat(Enumerable.Repeat("»", 100)));
}

void AfficherNiveauCiternes()
{
    foreach (WaterTank waterTank in waterTanks)
        Console.WriteLine($"Quantité d'eau dans la citerne {waterTank.Number} : {waterTank.FillLevel} litre(s) sur {waterTank.MaxCapacity}");
    Console.WriteLine($"Quantité d'eau dans toutes les {WaterTank.TotalNumberOfTanks} citernes : {WaterTank.TotalFillLevels} litre(s)");
}