using civ5hype.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace civ5hype.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamePlayer> GamePlayers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Game - CreatedBy relationship
            modelBuilder.Entity<Game>()
                .HasOne(g => g.CreatedBy)
                .WithMany(u => u.CreatedGames)
                .HasForeignKey(g => g.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            // Player - User relationship (optional)
            modelBuilder.Entity<Player>()
                .HasOne(p => p.User)
                .WithOne(u => u.Player)
                .HasForeignKey<Player>(p => p.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            // GamePlayer relationships
            modelBuilder.Entity<GamePlayer>()
                .HasOne(gp => gp.Game)
                .WithMany(g => g.GamePlayers)
                .HasForeignKey(gp => gp.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GamePlayer>()
                .HasOne(gp => gp.Player)
                .WithMany(p => p.GamePlayers)
                .HasForeignKey(gp => gp.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            modelBuilder.Entity<Game>()
                .HasIndex(g => g.PlayedOn);

            modelBuilder.Entity<Player>()
                .HasIndex(p => p.Name);
        }
    }
}
