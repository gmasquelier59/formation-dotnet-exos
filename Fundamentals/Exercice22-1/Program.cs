//  Liste des couleurs d'affichage
ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.DarkBlue, ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Magenta };

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

string sousBarre = string.Concat(Enumerable.Repeat("═", largeurColonne));
string barreHaute = "╔" + string.Concat(Enumerable.Repeat(sousBarre + "╦", nbColonnes)).TrimEnd('╦') + "╗";
string barreIntermediaire = "╠" + string.Concat(Enumerable.Repeat(sousBarre + "╬", nbColonnes)).TrimEnd('╬') + "╣";
string barreBasse = "╚" + string.Concat(Enumerable.Repeat(sousBarre + "╩", nbColonnes)).TrimEnd('╩') + "╝";

Console.WriteLine(barreHaute);
for (int ligne = 1; ligne <= nbTables; ligne++)
{
    if (ligne > 1)
        Console.WriteLine(barreIntermediaire);

    int colorIndex = ligne - 1;
    for (int colonne = 1; colonne <= nbColonnes; colonne++)
    {
        Console.Write('║');
        Console.ForegroundColor = colors[colorIndex % colors.Length];
        Console.Write((ligne * colonne).ToString().PadLeft(largeurColonne));
        Console.ResetColor();
        colorIndex++;
    }
    Console.WriteLine("║");

    Console.ResetColor();
}
Console.WriteLine(barreBasse);