using vnexchange1.Models;
using Microsoft.EntityFrameworkCore;

namespace vnexchange1.Data
{
    public class VnExchangeContext : DbContext
    {
        public VnExchangeContext(DbContextOptions<VnExchangeContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Item>().Metadata.AddProperty("ItemLocation", typeof(string));            
            //modelBuilder.Entity<Category>().ToTable("Category");
            //modelBuilder.Entity<Item>().ToTable("Item");
            //modelBuilder.Entity<ItemType>().ToTable("ItemType");
            //modelBuilder.Entity<ItemImage>().ToTable("ItemImage");
        }
    }
}
