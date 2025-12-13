using Microsoft.EntityFrameworkCore;
using RestfulApisWithRepositoryDesignPattern.Models.Entities;

namespace RestfulApisWithRepositoryDesignPattern.Models
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
    }
}
