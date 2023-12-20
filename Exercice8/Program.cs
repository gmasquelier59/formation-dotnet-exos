Console.Write("Entrez le prix HT de l'objet (en Euros) : ");
double price = double.Parse(Console.ReadLine());

Console.Write("Entrez le taux de TVA (en %) : ");
double rate = double.Parse(Console.ReadLine());

double tva = Math.Round(price * (rate / 100), 2);
Console.WriteLine($"Le montant de la TVA est de {tva} Euros");
Console.WriteLine($"Le montant de la TVA est de {price + tva} Euros");