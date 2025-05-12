using System;
using Microsoft.EntityFrameworkCore;
using AirportManagementSystem.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AirportManagementSystem.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Baggage> Baggage { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Gate> Gates { get; set; }
        public DbSet<SecurityCheckpoint> SecurityCheckpoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=AirportDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship between Passenger and Flight
            modelBuilder.Entity<Passenger>()
                .HasMany(p => p.Flights)
                .WithMany(f => f.Passengers)
                .UsingEntity(j => j.ToTable("PassengerFlights"));
        }
    }
}