using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChemQuizWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
            .Entity<Party>()
            .HasMany(p => p.Games)
            .WithMany(p => p.Parties)
            .UsingEntity<Dictionary<string, object>>(
            "GameParty",
            j => j
            .HasOne<Game>()
            .WithMany()
            .HasForeignKey("GameId"),
            j => j
            .HasOne<Party>()
            .WithMany()
            .HasForeignKey("PartyId"));

            builder
            .Entity<Party>()
            .HasMany(p => p.Users)
            .WithMany(p => p.Parties)
            .UsingEntity<Dictionary<string, object>>(
            "UserParty",
            j => j
            .HasOne<AppUser>()
            .WithMany()
            .HasForeignKey("UserId"),
            j => j
            .HasOne<Party>()
            .WithMany()
            .HasForeignKey("PartyId"));
            base.OnModelCreating(builder);
        }
        public virtual DbSet<Avatar> Avatar { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Level> Level { get; set; }
        public virtual DbSet<Party> Party { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }

        public virtual DbSet<AppUser> AppUser { get; set; }

    }
}
