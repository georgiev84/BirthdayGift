﻿// <auto-generated />
using System;
using Birthday.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Birthday.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210607211059_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Birthday.Entities.Gift", b =>
                {
                    b.Property<int>("GiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GiftName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GiftId");

                    b.ToTable("Gifts");

                    b.HasData(
                        new
                        {
                            GiftId = 1,
                            GiftName = "Flowers",
                            Image = "~/images/flower.png"
                        },
                        new
                        {
                            GiftId = 2,
                            GiftName = "Chocolate",
                            Image = "~/images/chocolate.png"
                        },
                        new
                        {
                            GiftId = 3,
                            GiftName = "Wine",
                            Image = "~/images/wine.png"
                        });
                });

            modelBuilder.Entity("Birthday.Entities.Voting", b =>
                {
                    b.Property<int>("VotingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CelebratorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("VotingStatus")
                        .HasColumnType("bit");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("VotingId");

                    b.ToTable("Votings");
                });

            modelBuilder.Entity("Birthday.Entities.VotingDetails", b =>
                {
                    b.Property<int>("VotingDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AlreadyVoted")
                        .HasColumnType("bit");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.Property<int>("VotingId")
                        .HasColumnType("int");

                    b.HasKey("VotingDetailsId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("GiftId");

                    b.HasIndex("VotingId");

                    b.ToTable("VotingDetails");
                });

            modelBuilder.Entity("Birthday.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "d927e259-7d03-430d-a7c1-5ddd4d2fbc9f",
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1985, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "df9fe65e-ca45-44ad-bb2e-a24ddd061d5a",
                            Email = "john@test.com",
                            EmailConfirmed = false,
                            FullName = "John",
                            LockoutEnabled = false,
                            NormalizedEmail = "JOHN@TEST.COM",
                            NormalizedUserName = "JOHN@TEST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEFWngCadYHTujP0NsDAfvGzWTMAMYBVM2GxTTP4mVyDLHze8mmuAoZ0x6nTBmD2S0w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9d0d7a0a-fbfe-4396-a79b-c53851f943f8",
                            TwoFactorEnabled = false,
                            UserName = "john@test.com"
                        },
                        new
                        {
                            Id = "9ff3cbfd-17d4-4656-b58c-a16f68a0f573",
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1990, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "256eb190-2e33-4cf5-9b5a-f71c2271cfc2",
                            Email = "peter@test.com",
                            EmailConfirmed = false,
                            FullName = "Peter",
                            LockoutEnabled = false,
                            NormalizedEmail = "PETER@TEST.COM",
                            NormalizedUserName = "PETER@TEST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAELeJ9h6sC/13gorHfRXGsVxam9pjWFL5CoSU6+ef/LrODraez/P7JGHY3uPvKClHkw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2c95956b-5187-4107-940d-da2695869ed3",
                            TwoFactorEnabled = false,
                            UserName = "peter@test.com"
                        },
                        new
                        {
                            Id = "2d968af3-0b88-4dc7-b799-730b710535a3",
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1989, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "c22d98b4-7e00-4c48-a3c6-64d48e81c9fe",
                            Email = "charles@test.com",
                            EmailConfirmed = false,
                            FullName = "Charles",
                            LockoutEnabled = false,
                            NormalizedEmail = "CHARLES@TEST.COM",
                            NormalizedUserName = "CHARLES@TEST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ3tjq/bg9c8tk9JXxqgrt50OXxhOFNjOoAZPZR3gFC48OF9bM3KobjTrZb7spvZ8A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f06ceaab-8723-4160-8985-ce5ef95ca7c4",
                            TwoFactorEnabled = false,
                            UserName = "charles@test.com"
                        },
                        new
                        {
                            Id = "6fdafeb8-b30e-4d7d-a6d0-2c6fcde333b3",
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1995, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "e2b0e549-d68b-4875-a90c-9b46a9c0ff70",
                            Email = "alexandra@test.com",
                            EmailConfirmed = false,
                            FullName = "Alexandra",
                            LockoutEnabled = false,
                            NormalizedEmail = "ALEXANDRA@TEST.COM",
                            NormalizedUserName = "ALEXANDRA@TEST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEDcCTWmw9EgJOgqsNlvfj98TrDyBxHlmYHtr3LOVNhCZ4gryprMqX7emFavUIJVEpQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "83f92137-7ba4-4247-9bf1-de6428d62cd4",
                            TwoFactorEnabled = false,
                            UserName = "alexandra@test.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Birthday.Entities.VotingDetails", b =>
                {
                    b.HasOne("Birthday.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Birthday.Entities.Gift", "Gift")
                        .WithMany()
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Birthday.Entities.Voting", null)
                        .WithMany("VotingDetails")
                        .HasForeignKey("VotingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Birthday.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Birthday.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Birthday.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Birthday.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}