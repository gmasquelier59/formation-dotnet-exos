Console.WriteLine("--- Dans quelle catégorie mon enfant est-il... ? ---");

Console.Write("Entrez l'âge de votre enfant : ");

if (!int.TryParse(Console.ReadLine(), out int age) || age < 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("L'âge doit être un nombre entier positif !");
    Console.ResetColor();
    return;
}

if (age < 3)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("L'enfant est trop jeune");
    Console.ResetColor();
    return;
}
else if (age >= 18)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("Ce n'est plus un enfant !");
    Console.ResetColor();
    return;
}

string categorie = "";
if (age >= 3 && age <=6)
{
    categorie = "Baby";
}
else if (age >= 7 && age <= 8)
{
    categorie = "Poussin";
}
else if (age >= 9 && age <= 10)
{
    categorie = "Pupille";
}
else if (age >= 11 && age <= 12)
{
    categorie = "Minime";
}
else
{
    categorie = "Cadet";
}

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine($"Votre enfant est dans la catégorie \"{categorie}\" !");
Console.ResetColor();