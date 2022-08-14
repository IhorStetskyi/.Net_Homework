using EFCHomework.StaticClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using EFCHomework.Models;

namespace EFCHomework.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Configuration config = StaticSourceMethods.CreateNewConfig();
            config.ClearConfigurationManagerConnectionStrings();
            config.AddConnectionSettingsToConfig(@".\MYMSSQLSERVER", "Homework14_2", "MyConnection");
            config.ProtectConnectionData(true);

            optionsBuilder.UseSqlServer(StaticSourceMethods.GetConnectionString("MyConnection"));

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(x => x.ProductId);


            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Description = "Description 1", Height = 1, Weight = 1, Length = 1, Width = 1 },
                new Product { Id = 2, Description = "Description 2", Height = 2, Weight = 2, Length = 2, Width = 2 },
                new Product { Id = 3, Description = "Description 3", Height = 3, Weight = 3, Length = 3, Width = 3 },
                new Product { Id = 4, Description = "Description 4", Height = 4, Weight = 4, Length = 4, Width = 4 },
                new Product { Id = 5, Description = "Description 5", Height = 5, Weight = 5, Length = 5, Width = 5 });

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, Status = "NotStarted", CreatedDate = new DateTime(2010, 05, 09), UpdatedDate = new DateTime(2010, 05, 09), ProductId = 1 },
                new Order { Id = 2, Status = "Loading", CreatedDate = new DateTime(2011, 05, 09), UpdatedDate = new DateTime(2011, 05, 09), ProductId = 2 },
                new Order { Id = 3, Status = "InProgress", CreatedDate = new DateTime(2012, 05, 09), UpdatedDate = new DateTime(2012, 05, 09), ProductId = 3 },
                new Order { Id = 4, Status = "Arrived", CreatedDate = new DateTime(2013, 05, 09), UpdatedDate = new DateTime(2013, 05, 09), ProductId = 4 },
                new Order { Id = 5, Status = "Unloading", CreatedDate = new DateTime(2014, 05, 09), UpdatedDate = new DateTime(2014, 05, 09), ProductId = 5 },
                new Order { Id = 6, Status = "Cancelled", CreatedDate = new DateTime(2015, 05, 09), UpdatedDate = new DateTime(2015, 05, 09), ProductId = 2 },
                new Order { Id = 7, Status = "Done", CreatedDate = new DateTime(2016, 05, 09), UpdatedDate = new DateTime(2016, 05, 09), ProductId = 2});

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
