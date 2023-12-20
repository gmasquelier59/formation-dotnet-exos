Console.Write("Merci de saisir le dernier salaire (en euros) : ");
if (!int.TryParse(Console.ReadLine(), out int salaire) || salaire <= 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("Le salaire doit être un nombre entier positif !");
    Console.ResetColor();
    return;
}

Console.Write("Merci de saisir votre âge : ");
if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0 || age > 99)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("L'âge doit être un nombre entier positif compris entre 1 et 99 !");
    Console.ResetColor();
    return;
}

Console.Write("Merci de saisir le nombre d'années d'ancienneté : ");
if (!int.TryParse(Console.ReadLine(), out int anciennete) || anciennete <= 0 || anciennete > 60)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("Le nombre d'années doit être un nombre entier positif compris entre 1 et 60 !");
    Console.ResetColor();
    return;
}

int indemnite = 0;
if (anciennete >= 1 && anciennete <= 10)
{
    indemnite = (salaire / 2) * anciennete;
}
else if (anciennete > 10)
{
    indemnite = (salaire / 2) * 10 + salaire * (anciennete - 10);
}

if (age >= 46 && age <= 49)
{
    indemnite += 2 * salaire;
}
else if (age >= 50)
{
    indemnite += 5 * salaire;
}

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine($"Votre indemnité est de : {indemnite} euros");
Console.ResetColor();