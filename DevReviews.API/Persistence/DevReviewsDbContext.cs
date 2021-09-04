using System.Collections.Generic;
using DevReviews.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevReviews.API.Persistence
{
    public class DevReviewsDbContext : DbContext
    {
        public DevReviewsDbContext(DbContextOptions<DevReviewsDbContext> options)
        : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("tb_Products");
                p.HasKey(p => p.Id);

                p.HasMany(pp => pp.Reviews)
                .WithOne(r => r.Product)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<ProductReview>(p =>
            {
                p.ToTable("tb_ProductReviews");
                p.HasKey(p => p.Id);
                p.Property(p => p.Author).HasMaxLength(50);
            });

        }
    }
}