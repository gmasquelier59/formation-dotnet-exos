Console.WriteLine("--- Dans quelle catégorie mon enfant est-il... ? ---\n");

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
    Console.Error.WriteLine("L'enfant est trop jeune !");
    Console.ResetColor();
    return;
}

if (age >= 18)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("C'est un adulte maintenant !");
    Console.ResetColor();
    return;
}


string categorie;
switch(age)
{
    case <= 6:
        {
            categorie = "Baby";
            break;
        }
    case <= 8:
        {
            categorie = "Poussin";
            break;
        }
    case <= 10:
        {
            categorie = "Pupille";
            break;
        }
    case <= 12:
        {
            categorie = "Minime";
            break;
        }
    case > 12:
        {
            categorie = "Cadet";
            break;
        }
}

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine($"Votre enfant est dans la catégorie \"{categorie}\" !");
Console.ResetColor();