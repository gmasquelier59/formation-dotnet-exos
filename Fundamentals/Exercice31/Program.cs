int choice;
int lowestNote = 20;
int highestNote = 0;
int sumOfNotes = 0;
double averageNote;
int numberOfNotes = 0;

while (true)
{
    Console.WriteLine();
    Console.WriteLine("--- Gestion des notes avec menu ---");
    Console.WriteLine();

    Console.WriteLine($"1 ══> Saisir les notes - actuellement {numberOfNotes} note(s)");
    if (numberOfNotes == 0)
        Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("2 ══> La plus grande note");
    Console.WriteLine("3 ══> La plus petite note");
    Console.WriteLine("4 ══> La moyenne des notes");
    Console.ResetColor();
    Console.WriteLine("0 ══> Quitter");
    
    Console.WriteLine();

    Console.Write("Faites votre choix : ");
    while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 4)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Choix incorrect !");
        Console.ResetColor();
        Console.Write("Faites votre choix : ");
    }

    Console.Clear();

    switch (choice)
    {
        case 0:
            Environment.Exit(0);
            break;
        case 1:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----- Saisie des notes -----");
            Console.WriteLine();

            numberOfNotes++;
            while (true)
            {
                Console.Write($"\t- Merci de saisir la note {numberOfNotes} (/20, 999 pour terminer) : ");
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
            Console.ResetColor();
            break;
        case 2:
            if (numberOfNotes < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Il faut au minimum une note ! Faites le choix 1 pour saisir les notes");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----- La plus grande note -----");
                Console.WriteLine();
                Console.WriteLine($"La plus grande note est {highestNote}/20");
            }
            Console.ResetColor();
            break;
        case 3:
            if (numberOfNotes < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Il faut au minimum une note ! Faites le choix 1 pour saisir les notes");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("----- La moins bonne note -----");
                Console.WriteLine();
                Console.WriteLine($"La moins bonne note est {lowestNote}/20");
            }
            Console.ResetColor();
            break;
        case 4:
            if (numberOfNotes < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Il faut au minimum une note ! Faites le choix 1 pour saisir les notes");
            }
            else
            {
                averageNote = sumOfNotes / numberOfNotes;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("----- La moyennes des notes -----");
                Console.WriteLine();
                Console.WriteLine($"La moyenne des notes est de {averageNote:F2}/20");
            }
            Console.ResetColor();
            break;
    }
}