using BloggersMastersAPI.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggersMastersAPI.Models
{
    public class BloggersMastersContext : DbContext
    {
        public BloggersMastersContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relations set up
            modelBuilder.Entity<User>()
                .HasMany(c => c.Posts)
                .WithOne(e => e.User);

            //Dummy users
            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        firstName = "Will",
                        lastName = "Smith",
                        username = "WillSmith"
                    },
                    new User
                    {
                        Id = 2,
                        firstName = "Peter",
                        lastName = "Griffin",
                        username = "PeterGriffin"
                    },
                    new User
                    {
                        Id = 3,
                        firstName = "Homer",
                        lastName = "Simpsons",
                        username = "HomeSimpsons"
                    }
                );
            //Dummy posts
            modelBuilder.Entity<Post>()
                .HasData(
                    new Post
                    {
                        Id = 1,
                        Title = "My greatest achievements",
                        Content = "One of my greatest achiements is winning a league game!",
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        PublicPost = false,
                        UserId = 1,
                        Agrees = 0,
                        Disagrees = 0
                    },
                    new Post
                    {
                        Id = 2,
                        Title = "Job hunting",
                        Content = "I've currently spent a month looking for a job as a web dev. Lets hope this is the one.",
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        PublicPost = true,
                        UserId = 1,
                        Agrees = 0,
                        Disagrees = 0
                    },
                    new Post
                    {
                        Id = 3,
                        Title = "Hello world!",
                        Content = "Today I printed hello world to my console, I felt like a hacker!",
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        PublicPost = true,
                        UserId = 2,
                        Agrees = 0,
                        Disagrees = 0
                    },
                    new Post
                    {
                        Id = 4,
                        Title = "I just finished Noroff's bootcamp!",
                        Content = "Finally I master the skills of C#, its time to apply for amazing opportunities!",
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        PublicPost = true,
                        UserId = 3,
                        Agrees = 0,
                        Disagrees = 0
                    }
                );
        }
    }
}
