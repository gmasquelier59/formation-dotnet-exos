using ASPDotnetCoreMVC_Exercice06_TodoList.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPDotnetCoreMVC_Exercice06_TodoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskModel>().HasData(
                new TaskModel
                {
                    Id = 1,
                    Title = "Rangement",
                    Description = "Préparer la venue de belle-maman",
                    Status = Models.TaskStatus.Opened
                },
                new TaskModel
                {
                    Id = 2,
                    Title = "Promenade",
                    Description = "Promener Médor et faire attention à la voisine !",
                    Status = Models.TaskStatus.Closed
                }
            );
        }
    }
}
