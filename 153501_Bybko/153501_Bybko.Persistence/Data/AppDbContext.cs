using Microsoft.EntityFrameworkCore;

namespace _153501_Bybko.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        {
            Database.EnsureCreated();
        }
    }
}
