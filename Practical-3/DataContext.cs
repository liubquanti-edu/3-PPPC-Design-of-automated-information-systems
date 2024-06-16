using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Store
{
    internal class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = UserData.db");
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Receipt>()
                .HasMany(c => c.Products)
                .WithMany(s => s.Receipts)
                .UsingEntity<ReceiptProduct>(
                    j => j
                        .HasOne(pt => pt.Product)
                        .WithMany(t => t.ReceiptProduct)
                        .HasForeignKey(pt => pt.ProductId),
                    j => j
                        .HasOne(pt => pt.Receipt)
                        .WithMany(p => p.ReceiptProduct)
                        .HasForeignKey(pt => pt.ReceiptId)
                );
        }
    }
}
