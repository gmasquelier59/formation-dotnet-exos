Console.WriteLine("--- Le nombre est-il divisible par... ? ---");

Console.Write("Entrez un chiffre/nombre entier : ");
if (!int.TryParse(Console.ReadLine(), out int numerateur))
{
    Console.WriteLine("Ce n'est pas un chiffre, ou ce n'est pas un chiffre entier !");
    return;
}

Console.Write("Entrez un chiffre/nombre diviseur : ");
if (!int.TryParse(Console.ReadLine(), out int denominateur))
{
    Console.WriteLine("Ce n'est pas un chiffre, ou ce n'est pas un chiffre entier !");
    return;
}

Console.WriteLine((numerateur % denominateur == 0) ? $"Le chiffre/nombre est divisible par {denominateur}" : $"Le chiffre/nombre n'est pas divisible par {denominateur}");