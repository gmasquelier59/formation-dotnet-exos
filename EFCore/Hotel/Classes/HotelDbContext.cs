using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Classes
{
    internal class HotelDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Chambre> Chambres { get; set; }
        DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=(localdb)\\M2I; Database=Hotel;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder
            //    .Entity<ReservationChambre>()
            //    .HasKey(c => new { c.ChambreId, c.ReservationId });

            //modelBuilder.Entity<ReservationChambre>()
            //    .HasOne(rc => rc.Chambre)
            //    .WithMany(c => c.ReservationChambres)
            //    .HasForeignKey(rc => rc.ChambreId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<ReservationChambre>()
            //    .HasOne(rc => rc.Reservation)
            //    .WithMany(c => c.ReservationChambres)
            //    .HasForeignKey(rc => rc.ReservationId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Hotel>().HasData(new Hotel()
            //{
            //    Id = 1,
            //    Nom = "Hôtel"
            //});
        }
    }
}
