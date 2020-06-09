using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_13.Entities
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Confectionary> Confectionaries { get; set; }
        public DbSet<Confectionary_Order> Confectionaries_Order{ get; set; }

        public CustomerDbContext()
        {

        }
        public CustomerDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdClient);
                entity.Property(e => e.IdClient).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();

                entity.ToTable("Customer");

                entity.HasMany(d => d.Orders)
                              .WithOne(d => d.Customer)
                              .HasForeignKey(d => d.IdClient)
                              .IsRequired();
            });
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);
                entity.Property(e => e.IdEmployee).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();

                entity.ToTable("Employee");

                entity.HasMany(d => d.Orders)
                              .WithOne(d => d.Employee)
                              .HasForeignKey(d => d.IdEmployee)
                              .IsRequired();
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);
                entity.Property(e => e.IdOrder).ValueGeneratedOnAdd();
                

                entity.ToTable("Order");

                entity.HasMany(d => d.Confectionary_Order)
                              .WithOne(d => d.Order)
                              .HasForeignKey(d => d.IdOrder)
                              .IsRequired();
            });

            modelBuilder.Entity<Confectionary>(entity =>
            {
                entity.HasKey(e => e.IdConfectionary);
                entity.Property(e => e.IdConfectionary).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();

                entity.ToTable("Confectionary");

                entity.HasMany(d => d.Confectionary_Orders)
                              .WithOne(d => d.Confectionary)
                              .HasForeignKey(d => d.IdConfection)
                              .IsRequired();
            });
            modelBuilder.Entity<Confectionary_Order>(entity =>
            {
                entity.HasKey(e => new {e.IdConfection, e.IdOrder });

                


                entity.ToTable("Confectionary_Order");
            });
        }
    }
}
