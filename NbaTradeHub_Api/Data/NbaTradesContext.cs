using Microsoft.EntityFrameworkCore;
using NbaTradeHub_Api.Data.Enteties;

namespace NbaTradeHub_Api.Data
{
    public class NbaTradesContext : DbContext
    {
        public NbaTradesContext(DbContextOptions options) : base(options)
        {
        }

        // Mappning mellan tabeller i databasen och entitetsklasser
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<BlogPost> BlogPosts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Official Trades" },
                new Category { CategoryId = 2, Name = "Trade Rumors"}
            );

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
