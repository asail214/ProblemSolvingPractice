using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AirportManagementSystem.Context;
using AirportManagementSystem.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AirportManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create & update database
            CreateDatabase();

            // adding sample data
            AddSampleData();

            // querying the database
            QueryDatabase();

        }

        static void CreateDatabase()
        {
            using (var context = new ApplicationDbContext())
            {
                Console.WriteLine("Creating database if it doesn't exist...");
                context.Database.EnsureCreated();
                Console.WriteLine("AirportDB Database is ready.");
            }
        }

        static void AddSampleData()
        {
            using (var context = new ApplicationDbContext())
            {
                // Check if data exist
                if (context.Airlines.Any())
                {
                    Console.WriteLine("Sample data already exists.");
                    return;
                }

                Console.WriteLine("Adding sample data...");

                // Add a terminal
                var terminal = new Terminal
                {
                    Name = "Terminal 1",
                    Capacity = 5000,
                    Location = "North Wing"
                };
                context.Terminals.Add(terminal);

                // Add an airline
                var airline = new Airline
                {
                    Name = "Oman Air",
                    ContactNumber = "+968 2453 1111",
                    ContactEmail = "info@omanair.com",
                    RepresentativeName = "Ahmed Al-Balushi"
                };
                context.Airlines.Add(airline);

                // Save changes to get IDs for terminal and airline
                context.SaveChanges();

                // Add a gate
                var gate = new Gate
                {
                    GateNumber = "G1",
                    IsAvailable = true,
                    TerminalId = terminal.TerminalId,
                    AirlineId = airline.AirlineId
                };
                context.Gates.Add(gate);

                // Save changes to get ID for gate
                context.SaveChanges();

                // Add a flight
                var flight = new Flight
                {
                    FlightNumber = "OA123",
                    DepartureCity = "Muscat",
                    DestinationCity = "Dubai",
                    DepartureTime = DateTime.Now.AddHours(2),
                    ArrivalTime = DateTime.Now.AddHours(3),
                    Status = "Scheduled",
                    AirlineId = airline.AirlineId,
                    GateId = gate.GateId
                };
                context.Flights.Add(flight);

                // Add a security checkpoint
                var checkpoint = new SecurityCheckpoint
                {
                    PassengerCapacity = 200,
                    Location = "Terminal 1 Entrance",
                    TerminalId = terminal.TerminalId
                };
                context.SecurityCheckpoints.Add(checkpoint);

                // Save changes to get IDs for flight and checkpoint
                context.SaveChanges();

                // Add a passenger
                var passenger = new Passenger
                {
                    FirstName = "Mohammed",
                    LastName = "Al-Abri",
                    DateOfBirth = new DateTime(1985, 5, 15),
                    Gender = "Male",
                    Nationality = "Omani",
                    PassportNumber = "12345678",
                    ContactPhone = "+968 9876 5432",
                    ContactEmail = "mohammed@example.com"
                };
                context.Passengers.Add(passenger);

                // Save changes to get ID for passenger
                context.SaveChanges();

                // Add baggage for the passenger
                var baggage = new Baggage
                {
                    Weight = 23.5,
                    TrackingNumber = "BAG12345",
                    PassengerId = passenger.PassengerId
                };
                context.Baggage.Add(baggage);

                // Add an officer
                var officer = new Officer
                {
                    FirstName = "Salim",
                    LastName = "Al-Habsi",
                    Position = "Security Officer",
                    Department = "Security",
                    ContactPhone = "+968 9123 4567",
                    ContactEmail = "salim@airport.om"
                };
                context.Officers.Add(officer);

                // Save final changes
                context.SaveChanges();

                Console.WriteLine("Sample data added successfully.");
            }
        }

        static void QueryDatabase()
        {
            using (var context = new ApplicationDbContext())
            {
                Console.WriteLine("\nQuerying database...");

                // Query airlines
                var airlines = context.Airlines.ToList();
                Console.WriteLine($"\nAirlines ({airlines.Count}):");
                foreach (var airline in airlines)
                {
                    Console.WriteLine($"- {airline.Name} ({airline.RepresentativeName})");
                }

                // Query flights with airline and gate
                var flights = context.Flights
                    .Include(f => f.Airline)
                    .Include(f => f.Gate)
                    .ToList();

                Console.WriteLine($"\nFlights ({flights.Count}):");
                foreach (var flight in flights)
                {
                    Console.WriteLine($"- {flight.FlightNumber}: {flight.DepartureCity} to {flight.DestinationCity}");
                    Console.WriteLine($"  Airline: {flight.Airline.Name}");
                    Console.WriteLine($"  Gate: {flight.Gate.GateNumber}");
                    Console.WriteLine($"  Status: {flight.Status}");
                }

                // Query terminals with gates
                var terminals = context.Terminals
                    .Include(t => t.Gates)
                    .ToList();

                Console.WriteLine($"\nTerminals ({terminals.Count}):");
                foreach (var terminal in terminals)
                {
                    Console.WriteLine($"- {terminal.Name} (Capacity: {terminal.Capacity})");
                    Console.WriteLine($"  Gates: {terminal.Gates.Count}");
                    foreach (var gate in terminal.Gates)
                    {
                        Console.WriteLine($"    - {gate.GateNumber} (Available: {gate.IsAvailable})");
                    }
                }
            }
        }
    }
}