(double, double, double, double) operation(double a, double b)
{
    return (a + b, a - b, a / b, a * b);
}

Console.Write("Nombre A : ");
int.TryParse(Console.ReadLine(), out int nombreA);
Console.Write("Nombre B : ");
int.TryParse(Console.ReadLine(), out int nombreB);

(double somme, double difference, double quotient, double produit) = operation(nombreA, nombreB);

Console.WriteLine($"Somme : {somme}");
Console.WriteLine($"Différence : {difference}");
Console.WriteLine($"Quotient : {quotient}");
Console.WriteLine($"Produit : {produit}");