using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Z3_EF
{
    public class Kontekst : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hello;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
                .Property(x => x.Imie)
                .HasMaxLength(40)
                .IsRequired()
                .HasColumnName("Name");
            modelBuilder.Entity<Student>()
                .Property(x => x.Nazwisko)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("Surname");
            modelBuilder.Entity<Student>()
                .Property(x => x.Id)
                .IsRequired();
        }
    }
}