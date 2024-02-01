using ASPDotnetCoreMVC_Exercice04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ASPDotnetCoreMVC_Exercice04.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MarmosetModel> Marmosets { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MarmosetModel>().HasData(new MarmosetModel
            {
                Id = 1,
                Name = "Black-tufted",
                Photo = "https://upload.wikimedia.org/wikipedia/commons/5/5c/Black-tufted_marmoset_%28sagui-de-tufos-pretos%29.jpg",
                Description = "The black-tufted marmoset (Callithrix penicillata), also known as Mico-estrela in Portuguese, is a species of New World monkey that lives primarily in the Neo-tropical gallery forests of the Brazilian Central Plateau. It ranges from Bahia to Paraná,[3] and as far inland as Goiás, between 14 and 25 degrees south of the equator, and can commonly be seen in the City of Rio de Janeiro where it was introduced. This marmoset typically resides in rainforests, living an arboreal life high in the trees, but below the canopy. They are only rarely spotted near the ground.",
                Areas = "Forests in eastern Brazil"
            });

            modelBuilder.Entity<MarmosetModel>().HasData(new MarmosetModel
            {
                Id = 2,
                Name = "White-headed",
                Photo = "https://upload.wikimedia.org/wikipedia/commons/e/e6/Sagui-de-cara-branca_%28Callithrix_geoffroyi%29_-_White-headed_marmoset.jpg",
                Description = "The white-headed marmoset (Callithrix geoffroyi), also known as the tufted-ear marmoset, Geoffroy's marmoset, or Geoffrey's marmoset, is a marmoset endemic to forests in eastern Brazil, where it is native to Bahia, Espírito Santo, and Minas Gerais, and introduced to Santa Catarina.[2] It is known as the sagüi or sauim in Brazil.[3] Its diet consists of fruits, insects, and the gum of trees.[4] It is a host of Pachysentis lenti an acanthocephalan intestinal parasite.[5]",
                Areas = "Neo-tropical gallery forests of the Brazilian Central Plateau"
            });

            modelBuilder.Entity<MarmosetModel>().HasData(new MarmosetModel
            {
                Id = 3,
                Name = "Munduruku",
                Photo = "https://upload.wikimedia.org/wikipedia/commons/7/76/Black-tailed_Marmoset_%28Callithrix_melanura%29_male_obviously_..._%2828485508852%29.jpg",
                Description = "The Munduruku marmoset (Mico munduruku) is a marmoset endemic to Brazil. It is found only in the southern Amazon, in an area of approximately 120,000 km2, from the right bank of the Jamanxim River, below the mouth of the Rio Novo, to the mouth of the Tapajós River, below the mouth of the Cururu River. According to researcher and discoverer Rodrigo Araújo, approximately half of the distribution area lies within Mundurucu Indigenous Territory in the Amazonas state. The name sagui-dos-Munduruku is a tribute to the Munduruku people who lives in the same location as the species.[2][3]",
                Areas = "Only in the southern Amazon"
            });                
        }
    }
}
