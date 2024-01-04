Console.WriteLine("--- La lettre est-elle une voyelle ? ---");

Console.Write("Entrez une lettre : ");
string? letter = Console.ReadLine();

if (letter == null)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("Veuillez saisir une lettre !");
    Console.ResetColor();
    return;
}

if (letter.Length != 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("Vous avez saisi trop de lettres !");
    Console.ResetColor();
    return;
}
else
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("AEIOUY".Contains(letter.ToUpper()) ? "Cette lettre est une voyelle !" : "Cette lettre n'est pas une voyelle !");
    Console.ResetColor();
}