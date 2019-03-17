using System;
using Microsoft.EntityFrameworkCore;

namespace Sample.Data
{
    using Models;

    public class Context : DbContext
    {
        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=/tmp/sample.sqlite");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity => {
                entity.ToTable("persons");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });
        }
    }
}