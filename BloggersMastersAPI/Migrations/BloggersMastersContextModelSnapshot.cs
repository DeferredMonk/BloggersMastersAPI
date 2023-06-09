﻿// <auto-generated />
using System;
using BloggersMastersAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BloggersMastersAPI.Migrations
{
    [DbContext(typeof(BloggersMastersContext))]
    partial class BloggersMastersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BloggersMastersAPI.Models.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Agrees")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Disagrees")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PublicPost")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Agrees = 0,
                            Content = "One of my greatest achiements is winning a league game!",
                            CreatedAt = new DateTime(2023, 4, 14, 10, 44, 54, 480, DateTimeKind.Local).AddTicks(6957),
                            Disagrees = 0,
                            PublicPost = false,
                            Title = "My greatest achievements",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Agrees = 0,
                            Content = "I've currently spent a month looking for a job as a web dev. Lets hope this is the one.",
                            CreatedAt = new DateTime(2023, 4, 14, 10, 44, 54, 480, DateTimeKind.Local).AddTicks(7001),
                            Disagrees = 0,
                            PublicPost = true,
                            Title = "Job hunting",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Agrees = 0,
                            Content = "Today I printed hello world to my console, I felt like a hacker!",
                            CreatedAt = new DateTime(2023, 4, 14, 10, 44, 54, 480, DateTimeKind.Local).AddTicks(7004),
                            Disagrees = 0,
                            PublicPost = true,
                            Title = "Hello world!",
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            Agrees = 0,
                            Content = "Finally I master the skills of C#, its time to apply for amazing opportunities!",
                            CreatedAt = new DateTime(2023, 4, 14, 10, 44, 54, 480, DateTimeKind.Local).AddTicks(7005),
                            Disagrees = 0,
                            PublicPost = true,
                            Title = "I just finished Noroff's bootcamp!",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("BloggersMastersAPI.Models.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            firstName = "Will",
                            lastName = "Smith",
                            username = "WillSmith"
                        },
                        new
                        {
                            Id = 2,
                            firstName = "Peter",
                            lastName = "Griffin",
                            username = "PeterGriffin"
                        },
                        new
                        {
                            Id = 3,
                            firstName = "Homer",
                            lastName = "Simpsons",
                            username = "HomeSimpsons"
                        });
                });

            modelBuilder.Entity("BloggersMastersAPI.Models.Models.Post", b =>
                {
                    b.HasOne("BloggersMastersAPI.Models.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BloggersMastersAPI.Models.Models.User", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
