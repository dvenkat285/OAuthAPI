using Microsoft.EntityFrameworkCore;
using OAuthAPI.Models.Entities;

namespace OAuthAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
