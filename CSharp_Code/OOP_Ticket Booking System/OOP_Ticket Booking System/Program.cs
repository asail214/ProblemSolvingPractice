//Assignment 1: Ticket Booking System
using System;
using System.Collections.Generic;

namespace OOP_Ticket_Booking_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicketSystem system = new TicketSystem();

            system.AddTicket(new Ticket { EventName = "Rock Concert", SeatNumber = "A12", TicketType = TicketType.VIP });
            system.AddTicket(new Ticket { EventName = "Rock Concert", SeatNumber = "B5", TicketType = TicketType.Regular });
            system.AddTicket(new Ticket { EventName = "Rock Concert", SeatNumber = "C8", TicketType = TicketType.Backstage });
            system.AddTicket(new Ticket { EventName = "Rock Concert", SeatNumber = "D15", TicketType = TicketType.Regular });
            system.AddTicket(new Ticket { EventName = "Rock Concert", SeatNumber = "E20", TicketType = TicketType.VIP });

            Console.WriteLine($"Ticket at seat A12: {system["A12"].TicketType}");
            Console.WriteLine($"Ticket at seat C8: {system["C8"].TicketType}");

            var counts = system.CountTicketsByType();
            Console.WriteLine($"Regular tickets: {counts[TicketType.Regular]}");
            Console.WriteLine($"VIP tickets: {counts[TicketType.VIP]}");
            Console.WriteLine($"Backstage tickets: {counts[TicketType.Backstage]}");
        }
    }

    enum TicketType
    {
        Regular,
        VIP,
        Backstage
    }

    class Ticket
    {
        public string EventName { get; set; }
        public string SeatNumber { get; set; }
        public TicketType TicketType { get; set; }
    }

    class TicketSystem
    {
        private List<Ticket> tickets = new List<Ticket>();

        public void AddTicket(Ticket ticket)
        {
            tickets.Add(ticket);
        }

        public Ticket this[string seatNumber]
        {
            get
            {
                for (int i = 0; i < tickets.Count; i++)
                {
                    if (tickets[i].SeatNumber == seatNumber)
                    {
                        return tickets[i];
                    }
                }
                return null;
            }
        }

        public Dictionary<TicketType, int> CountTicketsByType()
        {
            Dictionary<TicketType, int> counts = new Dictionary<TicketType, int>
        {
            { TicketType.Regular, 0 },
            { TicketType.VIP, 0 },
            { TicketType.Backstage, 0 }
        };

            foreach (var ticket in tickets)
            {
                counts[ticket.TicketType]++;
            }

            return counts;
        }
    }

}
