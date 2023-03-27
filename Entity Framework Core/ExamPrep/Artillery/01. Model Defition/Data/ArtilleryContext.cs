using Artillery.Data.Models;

namespace Artillery.Data
{
    using Microsoft.EntityFrameworkCore;

    public class ArtilleryContext : DbContext
    {
        public ArtilleryContext() { }

        public ArtilleryContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryGun> CountriesGuns { get; set; }
        public DbSet<Gun> Guns { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Shell> Shells { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryGun>(entity =>
                entity.HasKey(e => new { e.CountryId, e.GunId }));

        }
    }
}
