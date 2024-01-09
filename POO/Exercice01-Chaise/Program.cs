using Exercice01.Classes;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Chaise> chaises = new List<Chaise>();

        chaises.Add(new Chaise());
        chaises.Add(new Chaise(2, "Métal", "Noire"));
        chaises.Add(new Chaise(6, "Plastique", "Bleues"));

        foreach(Chaise chaise in chaises)
        {
            Console.WriteLine(chaise);
        }
    }
}