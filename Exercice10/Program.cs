Console.WriteLine("--- La lettre est-elle une voyelle ? ---");

Console.Write("Entrez une lettre : ");
string letter = Console.ReadLine().ToUpper();
if (letter.Length != 1)
{
    Console.WriteLine("Vous avez saisi trop de lettres !");
}
else
{
    Console.WriteLine("AEIOUY".Contains(letter) ? "Cette lettre est une voyelle !" : "Cette lettre n'est pas une voyelle !");
}