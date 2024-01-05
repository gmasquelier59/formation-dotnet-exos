using Exercice03.Classes;

Pendu pendu = new Pendu(10);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(ASCIIArt.Titre);
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"Vous avez {pendu.NbEssais} essais pour trouver le mot !");
Console.WriteLine($"Indice : c'est un animal ou un insecte :-)");
Console.ResetColor();
Console.WriteLine();

int nbEssai = pendu.NbEssais;

while (!pendu.TestWin() && nbEssai > 0)
{
    string masque = pendu.GenererMasque();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"Le mot à trouver : {masque}");

    char lettre = SaisieLettre();

    if (!pendu.TestChar($"{lettre}"))
    {
        nbEssai--;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Zut ! Il vous reste maintenant {nbEssai} essai(s) !");
    }
    else
    {
        if (pendu.TestWin())
            break;

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"Bien, il vous reste toujours {nbEssai} essai(s) !");
    }

    Console.ResetColor();
    Console.WriteLine();
}

if (pendu.TestWin())
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(ASCIIArt.Bravo);
    Console.WriteLine("");
    Console.WriteLine($"C'était bien le mot \"{pendu.MotADeviner}\" qu'il fallait trouver !");
    Console.WriteLine("");
}
else
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine(ASCIIArt.Dommage);
    Console.WriteLine("");
    Console.WriteLine($"Il fallait trouver le mot \"{pendu.MotADeviner}\" :-)");
    Console.WriteLine("");
}

Console.ResetColor();

char SaisieLettre()
{
    char lettre;

    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.Write("Veuillez saisir une lettre minuscule : ");
    while (!char.TryParse(Console.ReadLine(), out lettre) || lettre < 'a' || lettre > 'z')
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Saisie incorrecte !");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine();
        Console.Write("Veuillez saisir une lettre minuscule : ");
    }

    return lettre;
}