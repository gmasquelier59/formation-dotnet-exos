Console.WriteLine("--- Gestion des notes ---\n");

const int nbNotes = 5;
int[] notes = new int[nbNotes];

Console.WriteLine($"Veuillez saisir {nbNotes} notes :\n");

for(int i = 0; i < nbNotes; i++)
{
    Console.Write($"\t- Merci de saisir la note {i + 1} (sur /20) : ");
    while (!int.TryParse(Console.ReadLine(), out notes[i]) || notes[i] < 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine("\tLa note doit être un entier positif !");
        Console.ResetColor();
        Console.Write($"\t- Merci de saisir la note {i + 1} (sur /20) : ");
    }
}

Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"La meilleure note est {notes.Max()}/2");

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"La moins bonne note est {notes.Min()}/20");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"La moyenne des notes est {notes.Average()}/20");

Console.ResetColor();