using Microsoft.EntityFrameworkCore;
using Personnage = PersoNage.Entities.Personnage;

namespace PersoNage.Classes
{
    internal class PersoNageDbContext : DbContext
    {
        public DbSet<Personnage> Personnages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\M2I;Initial Catalog=PersoNage;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personnage>().HasData(new
            {
                Id = 1,
                DateCreation = DateTime.Now,
                Pseudo = "Guillausaure",
                PointsVie = 50,
                PointsArmure = 20,
                Degats = 20,
                NombrePersonnagesTues = 0
            });

            modelBuilder.Entity<Personnage>().HasData(new
            {
                Id = 2,
                DateCreation = DateTime.Now,
                Pseudo = "Uno",
                PointsVie = 30,
                PointsArmure = 5,
                Degats = 15,
                NombrePersonnagesTues = 0
            });
        }
    }
}
