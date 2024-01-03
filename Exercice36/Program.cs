Console.WriteLine("***** Tableau des notes *****");
Console.WriteLine();

int notesCount;

Console.Write("Combien de notes comportera le tableau (1 à 100) ? : ");
while (!int.TryParse(Console.ReadLine(), out notesCount) || notesCount < 1 || notesCount > 100)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\tLe nombre de notes doit être compris entre 1 et 100 !");
    Console.ResetColor();
    Console.Write("Combien de notes comportera le tableau ? : ");
}

Console.WriteLine();
Console.WriteLine($"Merci de saisir les {notesCount} note(s) :");

int[] notes = new int[notesCount];

for(int i = 0; i < notesCount; i++)
{
    Console.Write($"\t- Note {i + 1} sur {notesCount} : ");
    int note;
    while (!int.TryParse(Console.ReadLine(), out note) || note < 0 || note > 20)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\tLa note doit être comprise entre 0 et 20 !");
        Console.ResetColor();
        Console.Write($"\t- Note {i + 1} sur {notesCount} : ");
    }

    notes[i] = note;
}

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"La note max est : {notes.Max()}/20");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"La note min est : {notes.Min()}/20");
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine($"La note moyenne est : {notes.Average():F2}/20");
Console.ResetColor();