Console.Write("Entrez le prix HT de l'objet (en Euros) : ");
decimal price = decimal.Parse(Console.ReadLine());

Console.Write("Entrez le taux de TVA (en %) : ");
decimal rate = decimal.Parse(Console.ReadLine());

decimal tva = Math.Round(price * (rate / 100), 2);
Console.WriteLine($"Le montant de la TVA est de {tva} Euros");
Console.WriteLine($"Le montant de la TVA est de {price + tva} Euros");