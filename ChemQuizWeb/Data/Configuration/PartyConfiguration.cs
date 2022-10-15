using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ChemQuizWeb.Core.Entities;

namespace ChemQuizWeb.Core.Entities.Configuration
{
    public class PartyConfiguration : IEntityTypeConfiguration<Party>
    {
        public void Configure(EntityTypeBuilder<Party> builder)
        {
            builder
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
        }
    }
}
