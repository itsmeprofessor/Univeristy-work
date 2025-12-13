using EFMV.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFMV.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
