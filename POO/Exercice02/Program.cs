using Exercice02.Classes;

internal class Program
{
    private static void Main(string[] args)
    {
        Salarie chloe = new Salarie("Chloé", 24000);
        chloe.AfficherSalaire();
        new Salarie("Emma", 30000).AfficherSalaire();
        new Salarie("Georges", 26000).AfficherSalaire();
        new Salarie().AfficherSalaire();

        Console.WriteLine();
        Salarie.AfficherEntreprise();

        chloe.Salaire = 500000;

        Console.WriteLine();
        Salarie.AfficherEntreprise();

        Salarie.RemiseAZero();

        Console.WriteLine();
        Salarie.AfficherEntreprise();
    }
}