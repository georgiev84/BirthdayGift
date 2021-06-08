using Birthday.Entities;
using Birthday.EntityConfiguration;
using Birthday.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Birthday.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Voting> Votings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new GiftConfiguration());
            builder.ApplyConfiguration(new VotingConfiguration());


            base.OnModelCreating(builder);


            // seed users in database
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    // primary key
                    UserName = "john@test.com",
                    NormalizedUserName = "JOHN@TEST.COM",
                    NormalizedEmail = "JOHN@TEST.COM",
                    PasswordHash = hasher.HashPassword(null, "123456"),
                    Email = "john@test.com",
                    FullName = "John",
                    BirthDate = new DateTime(1985, 12, 12)
                },
                 new ApplicationUser
                 {
                     // primary key
                     UserName = "peter@test.com",
                     NormalizedUserName = "PETER@TEST.COM",
                     NormalizedEmail = "PETER@TEST.COM",
                     PasswordHash = hasher.HashPassword(null, "123456"),
                     Email = "peter@test.com",
                     FullName = "Peter",
                     BirthDate = new DateTime(1990, 05, 05)
                 },
                  new ApplicationUser
                  {
                      // primary key
                      UserName = "charles@test.com",
                      NormalizedUserName = "CHARLES@TEST.COM",
                      NormalizedEmail = "CHARLES@TEST.COM",
                      PasswordHash = hasher.HashPassword(null, "123456"),
                      Email = "charles@test.com",
                      FullName = "Charles",
                      BirthDate = new DateTime(1989, 04, 02)
                  },
                  new ApplicationUser
                  {
                      // primary key
                      UserName = "alexandra@test.com",
                      NormalizedUserName = "ALEXANDRA@TEST.COM",
                      NormalizedEmail = "ALEXANDRA@TEST.COM",
                      PasswordHash = hasher.HashPassword(null, "123456"),
                      Email = "alexandra@test.com",
                      FullName = "Alexandra",
                      BirthDate = new DateTime(1995, 10, 15)
                  }
            );

            builder.Entity<Gift>().HasData(
                new Gift
                {
                    GiftId = 1,
                    GiftName = "Flowers",
                    Image = "~/images/flower.png"
                },
                new Gift
                {
                    GiftId = 2,
                    GiftName = "Chocolate",
                    Image = "~/images/chocolate.png"
                },
                new Gift
                {
                    GiftId = 3,
                    GiftName = "Wine",
                    Image = "~/images/wine.png"
                }
            );

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Birthday.Entities.VotingDetails> VotingDetails { get; set; }
    }
}
