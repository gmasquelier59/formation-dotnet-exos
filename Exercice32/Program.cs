Console.WriteLine("Insertation des valeurs du tableau :");
int[] table = new int[10];
for(int i=0; i<10; i++)
{
    Console.Write($"Saisir la valeur {i + 1} : ");
    int.TryParse(Console.ReadLine(), out table[i]);
}
Console.WriteLine("Affichage des valeurs du tableau :");
for(int i=0; i<10;i++)
{
    Console.WriteLine(string.Concat(Enumerable.Repeat("\t", i)) + table[i]);
}