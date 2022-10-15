using ChemQuizWeb.Core.Entities.Configuration;
using ChemQuizWeb.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace ChemQuizWeb.Core.Entities
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PartyConfiguration());
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
