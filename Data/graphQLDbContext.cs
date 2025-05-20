using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Data
{
    public class graphQLDbContext : DbContext
    {

        public graphQLDbContext(DbContextOptions<graphQLDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>(builder =>
            {
                builder.ToTable("User");
                builder.HasKey(c => c.UserId);
            });
            builder.Entity<Product>(builder =>
            {
                builder.ToTable("Product");
                builder.HasKey(c => c.ProductId);
            });
            builder.Entity<Order>(builder =>
            {
                builder.ToTable("Order");
                builder.HasKey(c => c.OrderId);
            });
            builder.Entity<HashedPassword>().HasNoKey();
            base.OnModelCreating(builder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<HashedPassword> HashedPasswords { get; set; }
    }
}
