using _153501_Bybko.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace _153501_Bybko.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Artist> Artists => Set<Artist>();
        public DbSet<Song> Songs => Set<Song>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .HasMany(m => m.Songs)
                .WithOne(o => o.Artist)
                .IsRequired();
        }
    }
}
