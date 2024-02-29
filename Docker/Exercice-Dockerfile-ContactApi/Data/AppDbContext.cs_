using ContactApiDTO.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactApiDTO.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
#nullable disable
        public DbSet<Contact> Contacts { get; set; }
#nullable enable
    }
}
