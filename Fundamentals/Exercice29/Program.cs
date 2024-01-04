Console.WriteLine("--- Gestion des notes ---");
Console.WriteLine();
Console.WriteLine("Veuillez saisir les notes :");
Console.WriteLine("(999 pour calculer)");
Console.WriteLine();

int numberOfNotes = 1;
int lowestNote = 20;
int highestNote = 0;
int sumOfNotes = 0;
double averageNote;

while (true)
{
    Console.Write($"\t- Merci de saisir la note {numberOfNotes} (/20) : ");
    int.TryParse(Console.ReadLine(), out int note);

    if (note == 999)
    {
        numberOfNotes--;
        break;
    }

    if (note < 0 || note > 20)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\t\tErreur de saisie, la note doit être compris entre 0 et 20 !");
        Console.ResetColor();
        continue;
    }

    if (note < lowestNote)
        lowestNote = note;

    if (note > highestNote)
        highestNote = note;

    sumOfNotes += note;

    numberOfNotes++;
}

Console.WriteLine();

if (numberOfNotes > 0)
{
    averageNote = sumOfNotes / numberOfNotes;

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"La meilleure note est {highestNote}/20");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"La moins bonne note est {lowestNote}/20");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"La moyenne des {numberOfNotes} note(s) est {averageNote:F2}/20");
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Pas assez de note pour faire mes calculs !");
}

Console.ResetColor();