Console.WriteLine("--- Est pair... ? Est impair... ? ---");
Console.WriteLine();

Console.Write("Combien de nombre contiendra le tableau ? : ");
int.TryParse(Console.ReadLine(), out int count);

List<int> list = new List<int>();
Random random = new Random();
for(int i=0; i<count; i++)
{
    list.Add(random.Next(1, 51));
}

Console.WriteLine();
Console.WriteLine("Vérification des nombres du tableau :");
foreach(int value in list)
{
    string oddOrEven = (value % 2 == 0) ? "pair" : "impair";
    Console.WriteLine($"\tLe nombre {value} est {oddOrEven}.");
}