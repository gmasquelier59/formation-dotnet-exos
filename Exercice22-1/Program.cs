using System.Threading;

Console.Write("Merci de saisir le nombre de tables : ");
int nbTables;
while (!int.TryParse(Console.ReadLine(), out nbTables) || nbTables < 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("Ce n'est pas un nombre entier strictement positif !");
    Console.ResetColor();
}
Console.WriteLine();

Console.Write($"Merci de saisir le nombre de colonnes : ");
int nbColonnes;
while (!int.TryParse(Console.ReadLine(), out nbColonnes) || nbColonnes < 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("Ce n'est pas un nombre entier strictement positif !");
    Console.ResetColor();
}
Console.WriteLine();

int largeurColonne = (nbTables * nbColonnes).ToString().Length;

string sousBarre = string.Concat(Enumerable.Repeat("-", largeurColonne));
string barre = "+" + string.Concat(Enumerable.Repeat(sousBarre + "+", nbColonnes));

ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.DarkBlue, ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Magenta };

for (int ligne = 1; ligne <= nbTables; ligne++)
{
    Console.WriteLine(barre);

    int colorIndex = ligne - 1;
    for (int colonne = 1; colonne <= nbColonnes; colonne++)
    {
        Console.ForegroundColor = colors[colorIndex % (colors.Length)];
        Console.Write("|" + (ligne * colonne).ToString().PadLeft(largeurColonne));
        colorIndex++;
    }
    Console.WriteLine("|");

    Console.ResetColor();
}

Console.WriteLine(barre);