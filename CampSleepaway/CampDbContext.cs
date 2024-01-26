using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SP2.Models;
using System;
using System.IO;

namespace SP2
{
    public class CampDbContext : DbContext
    {
        public DbSet<Camper> Campers { get; set; }
        public DbSet<NextOfKin> NextOfKins { get; set; }
        public DbSet<Counselor> Counselors { get; set; }
        public DbSet<Cabin> Cabins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Local");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            DateTime currentDate = DateTime.Now;

            // Add cabins
            modelBuilder.Entity<Cabin>().HasData(
                new Cabin { CabinId = 1, CabinName = "Cabin1", CabinColor = "Blue" },
                new Cabin { CabinId = 2, CabinName = "Cabin2", CabinColor = "Green" },
                new Cabin { CabinId = 3, CabinName = "Cabin3", CabinColor = "Red" },
                new Cabin { CabinId = 4, CabinName = "Cabin4", CabinColor = "Yellow" },
                new Cabin { CabinId = 5, CabinName = "Cabin5", CabinColor = "White" },
                new Cabin { CabinId = 6, CabinName = "Cabin6", CabinColor = "Black" },
                new Cabin { CabinId = 7, CabinName = "Cabin7", CabinColor = "Brown" },
                new Cabin { CabinId = 8, CabinName = "Cabin8", CabinColor = "Orange" }
            );

            // Add counselors
            modelBuilder.Entity<Counselor>().HasData(
                new Counselor { CounselorId = 1, FirstName = "Counselor1", LastName = "Last1", Age = 18, CabinId = 1, YearsExperience = 2, ResponsibilityStartDate = currentDate, ResponsibilityEndDate = currentDate.AddDays(7) },
                new Counselor { CounselorId = 2, FirstName = "Counselor2", LastName = "Last2", Age = 18, CabinId = 2, YearsExperience = 3, ResponsibilityStartDate = currentDate, ResponsibilityEndDate = currentDate.AddDays(7) },
                new Counselor { CounselorId = 3, FirstName = "Counselor3", LastName = "Last3", Age = 18, CabinId = 3, YearsExperience = 1, ResponsibilityStartDate = currentDate, ResponsibilityEndDate = currentDate.AddDays(7) },
                new Counselor { CounselorId = 4, FirstName = "Counselor4", LastName = "Last4", Age = 18, CabinId = 4, YearsExperience = 2, ResponsibilityStartDate = currentDate, ResponsibilityEndDate = currentDate.AddDays(7) },
                new Counselor { CounselorId = 5, FirstName = "Counselor5", LastName = "Last5", Age = 18, CabinId = 5, YearsExperience = 3, ResponsibilityStartDate = currentDate, ResponsibilityEndDate = currentDate.AddDays(7) },
                new Counselor { CounselorId = 6, FirstName = "Counselor6", LastName = "Last6", Age = 18, CabinId = 6, YearsExperience = 1, ResponsibilityStartDate = currentDate, ResponsibilityEndDate = currentDate.AddDays(7) }
                );

            // Add campers
            modelBuilder.Entity<Camper>().HasData(
                new Camper { CamperId = 1, FirstName = "Camper1", LastName = "Last1", Age = 18, CabinId = 1, Gender = "Female", PhoneNumber = "4444444444", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new Camper { CamperId = 2, FirstName = "Camper2", LastName = "Last2", Age = 18, CabinId = 1, Gender = "Male", PhoneNumber = "5555555555", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new Camper { CamperId = 3, FirstName = "Camper3", LastName = "Last3", Age = 18, CabinId = 1, Gender = "Female", PhoneNumber = "6666666666", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new Camper { CamperId = 4, FirstName = "Camper4", LastName = "Last4", Age = 18, CabinId = 1, Gender = "Male", PhoneNumber = "7777777777", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new Camper { CamperId = 5, FirstName = "Camper5", LastName = "Last5", Age = 18, CabinId = 2, Gender = "Female", PhoneNumber = "8888888888", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new Camper { CamperId = 6, FirstName = "Camper6", LastName = "Last6", Age = 18, CabinId = 2, Gender = "Male", PhoneNumber = "9999999999", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new Camper { CamperId = 7, FirstName = "Camper7", LastName = "Last7", Age = 18, CabinId = 2, Gender = "Female", PhoneNumber = "1010101010", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new Camper { CamperId = 8, FirstName = "Camper8", LastName = "Last8", Age = 18, CabinId = 2, Gender = "Male", PhoneNumber = "1111111111", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new Camper { CamperId = 9, FirstName = "Camper9", LastName = "Last9", Age = 18, CabinId = 3, Gender = "Female", PhoneNumber = "1212121212", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new Camper { CamperId = 10, FirstName = "Camper10", LastName = "Last10", Age = 18, CabinId = 3, Gender = "Male", PhoneNumber = "1313131313", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new Camper { CamperId = 11, FirstName = "Camper11", LastName = "Last11", Age = 18, CabinId = 3, Gender = "Female", PhoneNumber = "1414141414", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new Camper { CamperId = 12, FirstName = "Camper12", LastName = "Last12", Age = 18, CabinId = 3, Gender = "Male", PhoneNumber = "1515151515", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new Camper { CamperId = 13, FirstName = "Camper13", LastName = "Last13", Age = 18, CabinId = 4, Gender = "Female", PhoneNumber = "1616161616", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new Camper { CamperId = 14, FirstName = "Camper14", LastName = "Last14", Age = 18, CabinId = 4, Gender = "Male", PhoneNumber = "1717171717", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new Camper { CamperId = 15, FirstName = "Camper15", LastName = "Last15", Age = 18, CabinId = 4, Gender = "Female", PhoneNumber = "1818181818", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new Camper { CamperId = 16, FirstName = "Camper16", LastName = "Last16", CabinId = 4, Gender = "Male", PhoneNumber = "1919191919", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new Camper { CamperId = 17, FirstName = "Camper17", LastName = "Last17", CabinId = 5, Gender = "Male", PhoneNumber = "2020202020", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new Camper { CamperId = 18, FirstName = "Camper18", LastName = "Last18", CabinId = 5, Gender = "Female", PhoneNumber = "2121212121", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) }
            );

            // Add next of kin
            modelBuilder.Entity<NextOfKin>().HasData(
                new NextOfKin { NextOfKinId = 1, CamperId = 1, FirstName = "Parent1", LastName = "Last1", Age = 40, Gender = "Female", PhoneNumber = "4567890123", RelationToCamper = "Parent", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new NextOfKin { NextOfKinId = 2, CamperId = 2, FirstName = "Parent2", LastName = "Last2", Age = 40, Gender = "Male", PhoneNumber = "5678901234", RelationToCamper = "Parent", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new NextOfKin { NextOfKinId = 3, CamperId = 3, FirstName = "Parent3", LastName = "Last3", Age = 40, Gender = "Female", PhoneNumber = "6789012345", RelationToCamper = "Parent", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new NextOfKin { NextOfKinId = 4, CamperId = 4, FirstName = "Parent4", LastName = "Last4", Age = 40, Gender = "Male", PhoneNumber = "7890123456", RelationToCamper = "Parent", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new NextOfKin { NextOfKinId = 5, CamperId = 5, FirstName = "Parent5", LastName = "Last5", Age = 40, Gender = "Male", PhoneNumber = "8901234567", RelationToCamper = "Parent", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) },
                new NextOfKin { NextOfKinId = 6, CamperId = 6, FirstName = "Parent6", LastName = "Last6", Age = 40, Gender = "Female", PhoneNumber = "9012345678", RelationToCamper = "Parent", MoveInDate = currentDate, MoveOutDate = currentDate.AddDays(7) }
            );
        }
    }
}
