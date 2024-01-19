using Microsoft.EntityFrameworkCore;
using PersoNage.Classes;
using PersoNage.Entities;
using Spectre.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        using (var database = new PersoNageDbContext())
        {
            //Personnage personnage = new Personnage()
            //{
            //    Pseudo = "Guillausaure",
            //    PointsVie = 50,
            //    PointsArmure = 20,
            //    Degats = 10,
            //};

            //database.Personnages.Add(personnage);
            //database.SaveChanges();

            foreach(Personnage personnage in database.Personnages)
                personnage.Afficher();
            Console.WriteLine();

            Personnage guillausaure = database.Personnages.First(p => p.Id == 1);
            Personnage uno = database.Personnages.First(p => p.Id == 2);

            guillausaure.Attaquer(uno);

            foreach (Personnage personnage in database.Personnages)
                personnage.Afficher();
            Console.WriteLine();
        }
    }
}