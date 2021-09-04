﻿using Data.Context;
using Microsoft.EntityFrameworkCore;
using ReviewService.Domain.Entities;

namespace ReviewService.Infrastructure.Context
{
    public class ReviewDbContext : DbContextBase
    {
        public ReviewDbContext() : base() { }
        public ReviewDbContext(DbContextOptions opts) : base(opts) { }
        
        public virtual DbSet<Review> Reviews { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Reviews;User Id=sa;Password=kloia12345!@#$%;");
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Review>().HasData(
                new Review{
                    ReviewId = 1,
                    ArticleId = 1, 
                    Reviewer = "John Doe",
                    ReviewContent = "OMG perfect!!",
                },
                new Review{
                    ReviewId = 2,
                    ArticleId = 1, 
                    Reviewer = "Jane Doe",
                    ReviewContent = "OMG perfect!!",
                });
            base.OnModelCreating(builder);
        }
        
    }
}