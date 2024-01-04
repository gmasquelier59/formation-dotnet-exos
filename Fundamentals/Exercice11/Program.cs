Console.WriteLine("--- Le nombre est-il divisible par... ? ---");

Console.Write("Entrez un chiffre/nombre entier : ");
if (!int.TryParse(Console.ReadLine(), out int numerateur))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("Ce n'est pas un nombre entier !");
    Console.ResetColor();
    return;
}

Console.Write("Entrez un chiffre/nombre diviseur : ");
if (!int.TryParse(Console.ReadLine(), out int denominateur))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("Ce n'est pas un nombre entier !");
    Console.ResetColor();
    return;
}

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine((numerateur % denominateur == 0) ? $"Le chiffre/nombre est divisible par {denominateur}" : $"Le chiffre/nombre n'est pas divisible par {denominateur}");
Console.ResetColor();