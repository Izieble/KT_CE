using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UE03_Eventmanagement_Backend._01_DB_Models
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Uni_KT_CE");
        }

        public DbSet<LVA> LVAs { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Rooms
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Room A", Location = "Building 1", Floor = "1st Floor" },
                new Room { Id = 2, Name = "Room B", Location = "Building 2", Floor = "2nd Floor" },
                new Room { Id = 3, Name = "Room C", Location = "Building 3", Floor = "Ground Floor" },
                new Room { Id = 4, Name = "Room D", Location = "Building 1", Floor = "3rd Floor" },
                new Room { Id = 5, Name = "Room E", Location = "Building 2", Floor = "Basement" },
                new Room { Id = 6, Name = "Room F", Location = "Building 3", Floor = "2nd Floor" },
                new Room { Id = 7, Name = "Room G", Location = "Building 1", Floor = "Ground Floor" },
                new Room { Id = 8, Name = "Room H", Location = "Building 2", Floor = "1st Floor" },
                new Room { Id = 9, Name = "Room I", Location = "Building 3", Floor = "3rd Floor" },
                new Room { Id = 10, Name = "Room J", Location = "Building 1", Floor = "Basement" }
            // Add more rooms as needed
            );

            // Seed data for LVAs
            modelBuilder.Entity<LVA>().HasData(
                new LVA { Id = 1, Name = "Mathematics", Leader = "Prof. Smith", Type = "Lecture", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2), Rhythm = "Weekly" },
                new LVA { Id = 2, Name = "Physics", Leader = "Dr. Johnson", Type = "Lab", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2), Rhythm = "Bi-weekly" },
                new LVA { Id = 3, Name = "History", Leader = "Prof. Brown", Type = "Seminar", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2), Rhythm = "Weekly" },
                new LVA { Id = 4, Name = "Chemistry", Leader = "Dr. White", Type = "Workshop", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2), Rhythm = "Monthly" },
                new LVA { Id = 5, Name = "Biology", Leader = "Prof. Green", Type = "Tutorial", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2), Rhythm = "Weekly" },
                new LVA { Id = 6, Name = "Computer Science", Leader = "Dr. Black", Type = "Project", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2), Rhythm = "Bi-weekly" },
                new LVA { Id = 7, Name = "Literature", Leader = "Prof. Gray", Type = "Discussion", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2), Rhythm = "Weekly" },
                new LVA { Id = 8, Name = "Art", Leader = "Dr. Red", Type = "Studio", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2), Rhythm = "Weekly" },
                new LVA { Id = 9, Name = "Music", Leader = "Prof. Blue", Type = "Performance", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2), Rhythm = "Monthly" },
                new LVA { Id = 10, Name = "Geography", Leader = "Dr. Yellow", Type = "Field Trip", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(8), Rhythm = "One-time" }
            // Add more LVAs as needed
            );

            // Seed data for Bookings
            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id = 1, RoomId = 1, LvaId = 1, Date = DateTime.Now },
                new Booking { Id = 2, RoomId = 2, LvaId = 2, Date = DateTime.Now },
                new Booking { Id = 3, RoomId = 3, LvaId = 3, Date = DateTime.Now },
                new Booking { Id = 4, RoomId = 4, LvaId = 4, Date = DateTime.Now },
                new Booking { Id = 5, RoomId = 5, LvaId = 5, Date = DateTime.Now },
                new Booking { Id = 6, RoomId = 6, LvaId = 6, Date = DateTime.Now },
                new Booking { Id = 7, RoomId = 7, LvaId = 7, Date = DateTime.Now },
                new Booking { Id = 8, RoomId = 8, LvaId = 8, Date = DateTime.Now },
                new Booking { Id = 9, RoomId = 9, LvaId = 9, Date = DateTime.Now },
                new Booking { Id = 10, RoomId = 10, LvaId = 10, Date = DateTime.Now },
                new Booking { Id = 11, RoomId = 10, LvaId = 4, Date = DateTime.Now }
            // Add more bookings as needed
            );
        }

    }
}
