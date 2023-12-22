Console.WriteLine("--- Les suites chaînées de nombres ---\n");

Console.Write("Merci de saisir un nombre entier strictement positif : ");
if (!int.TryParse(Console.ReadLine(), out int nombreAAtteindre) || nombreAAtteindre <= 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("Ce n'est pas un nombre entier strictement positif !");
    Console.ResetColor();
    return;
}

int somme;
List<int> nombres;

Console.WriteLine("\nLes chaînes possibles sont : ");

for (int i = 1; i <= nombreAAtteindre / 2; i++)
{
    somme = 0;
    nombres = new List<int>();
    for(int j = i; j <= nombreAAtteindre; j++)
    {
        somme += j;
        nombres.Add(j);
        if (somme == nombreAAtteindre)
        {
            Console.WriteLine(nombreAAtteindre + " = " + String.Join('+', nombres));
        }
    }
}