using Homies.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homies.Data
{
    public class HomiesDbContext : IdentityDbContext
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventParticipant>()
                .HasKey(e => new { e.EventId, e.HelperId });

            modelBuilder.Entity<EventParticipant>()
                .HasOne(e => e.Event)
                .WithMany(e => e.EventsParticipants)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder
                .Entity<Models.Type>()
                .HasData(new Models.Type()
                {
                    Id = 1,
                    Name = "Animals"
                },
                new Models.Type()
                {
                    Id = 2,
                    Name = "Fun"
                },
                new Models.Type()
                {
                    Id = 3,
                    Name = "Discussion"
                },
                new Models.Type()
                {
                    Id = 4,
                    Name = "Work"
                });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Event> Events{ get; set; }
        public DbSet<Models.Type> Types{ get; set; }
        public DbSet<EventParticipant> EventsParticipants{ get; set; }
    }
}