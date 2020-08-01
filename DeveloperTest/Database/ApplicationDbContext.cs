﻿using System;
using Microsoft.EntityFrameworkCore;
using DeveloperTest.Database.Models;

namespace DeveloperTest.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
                .HasKey(x => x.JobId);

            modelBuilder.Entity<Job>()
                .Property(x => x.JobId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Job>()
               .Property(x => x.CustomerId);

            modelBuilder.Entity<Job>()
                .HasOne(d => d.Customer);

            modelBuilder.Entity<Job>()
                .HasData(new Job
                {
                    JobId = 1,
                    Engineer = "Test",
                    When = DateTime.Now
                });

            modelBuilder.Entity<Customer>()
                .HasKey(x => x.CustomerId);

            modelBuilder.Entity<Customer>()
                .Property(x => x.CustomerId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Customer>()
                .HasData(new Customer
                {
                    CustomerId = 1,
                    CustomerName = "Ram Natarajan",
                    CustomerType = "Large"
                });
        }
    }
}
