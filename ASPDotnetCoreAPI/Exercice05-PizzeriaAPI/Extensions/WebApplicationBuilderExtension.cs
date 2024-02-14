using Exercice05_PizzeriaAPI.Data;
using Exercice05_PizzeriaAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Exercice05_PizzeriaAPI.Extensions
{
    public static class WebApplicationBuilderExtension
    {
        public static void AddDatabase(this WebApplicationBuilder builder)
        {
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<PizzaRepository>();
        }
    }
}
