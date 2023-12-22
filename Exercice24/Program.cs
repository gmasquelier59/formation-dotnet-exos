Console.WriteLine("--- Les suites chaînées de nombres ---\n");

Console.Write("Merci de saisir un nombre entier strictement positif : ");
if (!int.TryParse(Console.ReadLine(), out int nombreAAtteindre) || nombreAAtteindre <= 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("Ce n'est pas un nombre entier strictement positif !");
    Console.ResetColor();
    return;
}

int iterationsMax = nombreAAtteindre / 2 + 1;

Console.WriteLine("\nLes chaînes possibles sont : ");

int somme;
List<int> nombres;
for (int i = 1; i <= iterationsMax; i++)
{
    somme = 0;
    nombres = new List<int>();
    for(int j = i; j <= iterationsMax; j++)
    {
        somme += j;
        nombres.Add(j);
        if (somme == nombreAAtteindre)
        {
            Console.WriteLine(nombreAAtteindre + " = " + String.Join('+', nombres));
            break;
        }
    }
}