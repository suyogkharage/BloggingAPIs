using BloggingInfrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingInfrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<UserTable> Users { get; set; }
        public DbSet<BlogPostTable> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPostTable>().HasKey(b => b.BlogId);
            
            modelBuilder.Entity<BlogPostTable>(entity =>
            {
                entity.ToTable("BlogPosts"); // Optional: Set the table name explicitly

                entity.Property(e => e.Title)
                    .HasColumnName("BlogTitle")
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(e => e.Content)
                    .HasColumnName("BlogContent")
                    .HasMaxLength(6000)
                    .IsRequired();
            });
        }


    }
}
