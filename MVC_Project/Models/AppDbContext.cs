﻿using Microsoft.EntityFrameworkCore;

namespace MVC_Project.Models
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN-0AVBIPRU9F2;Database=MiniMVC;" +
                "integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                .HasOne(x => x.Seller)
                .WithMany(y => y.SellersSale)
                .HasForeignKey(z => z.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Sale>()
                .HasOne(x => x.Buyer)
                .WithMany(y => y.BuyersSale)
                .HasForeignKey(z => z.BuyerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Sale> Sales { get; set; }

    }
}
