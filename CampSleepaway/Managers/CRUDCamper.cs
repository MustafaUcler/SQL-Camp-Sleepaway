using ConsoleTables;
using SP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using Microsoft.EntityFrameworkCore;

namespace SP2.Managers
{
    public class CRUDCamper
    {
        static ShowMenuManager showMenuManager = new ShowMenuManager();
        public void Camper()
        {
            while (true)
            {
                Console.Clear();

                List<string> menuOptions = new List<string>
            {
                "CREATE",
                "READ",
                "UPDATE",
                "DELETE",
                "Tillbaka"

            };
                Console.Clear();

                int actionChoice = showMenuManager.ShowMenu("Choose a Option:", menuOptions);

                Console.Clear();

                switch (actionChoice)
                {
                    case 0:
                        CreateCamper();
                        break;
                    case 1:
                        ReadCamper();
                        break;
                    case 2:
                        UpdateCamper();
                        break;
                    case 3:
                        DeleteCamper();
                        break;
                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid selection.Returning to main menu.");
                        break;
                }
                Console.ReadKey();
            }
        }

        public void CreateCamper()
        {
            using (var context = new CampDbContext())
            {
                Console.WriteLine("Add a new camper:");

                Console.Write("First Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();

                Console.Write("Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Gender: ");
                string gender = Console.ReadLine();

                Console.Write("Phone Number: ");
                string phoneNumber = Console.ReadLine();

                Console.Write("Do you want to add the camper to a cabin? (YES/NO): ");
                string addToCabinChoice = Console.ReadLine();

                int? chosenCabinId = null;

                if (addToCabinChoice.ToUpper() == "YES")
                {
                    // Display available cabins with less than 4 campers and 1 counselor assigned
                    Console.WriteLine("Available Cabins with less than 4 campers and 1 counselor assigned:");

                    var cabins = context.Cabins
                        .Where(c => context.Campers.Count(camper => camper.CabinId == c.CabinId) < 4 && context.Counselors.Any(counselor => counselor.CabinId == c.CabinId))
                        .ToList();

                    if (cabins.Count == 0)
                    {
                        Console.WriteLine("No available cabins with less than 4 campers and no counselor assigned.");
                        Console.ReadKey();
                        return;
                    }

                    // Create ConsoleTable for displaying cabin options
                    var table = new ConsoleTable("ID", "Name", "Color");
                    foreach (var cabin in cabins)
                    {
                        table.AddRow(cabin.CabinId, cabin.CabinName, cabin.CabinColor);
                    }
                    table.Write(Format.Minimal);

                    bool validCabinId = false;
                    while (!validCabinId)
                    {
                        Console.Write("Choose Cabin ID: ");
                        if (int.TryParse(Console.ReadLine(), out int tempCabinId) && cabins.Any(cabin => cabin.CabinId == tempCabinId))
                        {
                            chosenCabinId = tempCabinId;
                            validCabinId = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Cabin ID. Please choose a valid ID from the list.");
                        }
                    }
                }

                bool validMoveInDate = false;
                DateTime moveInDate = DateTime.MinValue;
                while (!validMoveInDate)
                {
                    Console.Write("Move In Date (YYYY-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out moveInDate))
                    {
                        validMoveInDate = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please enter a valid date (YYYY-MM-DD).");
                    }
                }

                bool validMoveOutDate = false;
                DateTime moveOutDate = DateTime.MinValue;
                while (!validMoveOutDate)
                {
                    Console.Write("Move Out Date (YYYY-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out moveOutDate))
                    {
                        validMoveOutDate = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please enter a valid date (YYYY-MM-DD).");
                    }
                }

                var newCamper = new Camper
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Gender = gender,
                    PhoneNumber = phoneNumber,
                    CabinId = chosenCabinId,
                    MoveInDate = moveInDate,
                    MoveOutDate = moveOutDate // Include move out date
                };

                context.Campers.Add(newCamper);
                context.SaveChanges();

                if (chosenCabinId.HasValue)
                {
                    Console.WriteLine($"The camper {firstName} {lastName} has been added to Cabin ID {chosenCabinId.Value}.");
                }
                else
                {
                    Console.WriteLine($"The camper {firstName} {lastName} has been added.");
                }

                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
            }
        }

        public void ReadCamper()
        {
            using (var context = new CampDbContext())
            {
                var campers = context.Campers.OrderBy(c => c.CamperId).ToList();

                Console.WriteLine("List of Campers:");

                var table = new ConsoleTable("Camper ID", "Name", "Age", "Gender", "Phone Number", "Cabin ID", "Move In Date", "Move Out Date");

                foreach (var camper in campers)
                {
                    table.AddRow(
                        camper.CamperId,
                        $"{camper.FirstName} {camper.LastName}",
                        camper.Age,
                        camper.Gender,
                        camper.PhoneNumber,
                        camper.CabinId,
                        camper.MoveInDate.ToString("yyyy-MM-dd"),
                        camper.MoveOutDate.ToString("yyyy-MM-dd")
                    );
                }

                table.Write(Format.Minimal);
                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
            }
        }

        public void UpdateCamper()
        {
            using (var context = new CampDbContext())
            {
                var campers = context.Campers.ToList();

                Console.WriteLine("Update a CAMPER:");

                var campersTable = new ConsoleTable("ID", "FirstName", "LastName", "Age", "Gender", "Phone Number", "Cabin ID", "Move In Date", "Move Out Date");
                campers.ForEach(camper => campersTable.AddRow(camper.CamperId, camper.FirstName, camper.LastName, camper.Age, camper.Gender, camper.PhoneNumber, camper.CabinId, camper.MoveInDate.ToString("yyyy-MM-dd"), camper.MoveOutDate.ToString("yyyy-MM-dd")));
                campersTable.Write(Format.Minimal);

                int camperId;

                while (true)
                {
                    Console.Write("Enter the ID of the Camper you want to update: ");
                    if (int.TryParse(Console.ReadLine(), out camperId))
                    {
                        var camperToUpdate = context.Campers.Find(camperId);

                        if (camperToUpdate != null)
                        {

                            Console.Write("New First Name: ");
                            string newFirstName = Console.ReadLine();

                            Console.Write("New Last Name: ");
                            string newLastName = Console.ReadLine();

                            Console.Write("New Age: ");
                            int newAge = int.Parse(Console.ReadLine());

                            Console.Write("New Gender: ");
                            string newGender = Console.ReadLine();

                            Console.Write("New Phone Number: ");
                            string newPhoneNumber = Console.ReadLine();

                            // Display available cabins with less than 4 campers and at least 1 counselor
                            Console.WriteLine("Available Cabins with less than 4 campers and at least 1 counselor:");
                            var availableCabins = context.Cabins
                                .Where(c => c.Campers.Count < 4 && context.Counselors.Any(co => co.CabinId == c.CabinId))
                                .ToList();

                            if (availableCabins.Count == 0)
                            {
                                Console.WriteLine("No available cabins with less than 4 campers and at least 1 counselor.");
                                Console.ReadKey();
                                return;
                            }

                            // Create ConsoleTable for displaying cabin options
                            var table = new ConsoleTable("ID", "Name", "Color");
                            foreach (var cabin in availableCabins)
                            {
                                table.AddRow(cabin.CabinId, cabin.CabinName, cabin.CabinColor);
                            }
                            table.Write(Format.Minimal);

                            int newCabinId;

                            while (true)
                            {
                                Console.Write("Choose Cabin ID: ");
                                if (!int.TryParse(Console.ReadLine(), out newCabinId) || !availableCabins.Any(cabin => cabin.CabinId == newCabinId))
                                {
                                    Console.WriteLine("Invalid Cabin ID. Please choose a valid ID from the list.");
                                }
                                else
                                {
                                    camperToUpdate.CabinId = newCabinId;
                                    break;
                                }
                            }

                            Console.Write("New Move In Date (YYYY-MM-DD): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime newMoveInDate))
                            {
                                camperToUpdate.MoveInDate = newMoveInDate;
                            }

                            Console.Write("New Move Out Date (YYYY-MM-DD): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime newMoveOutDate))
                            {
                                camperToUpdate.MoveInDate = newMoveOutDate;
                            }

                            context.SaveChanges();

                            Console.WriteLine("The Camper information has been updated.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Camper with ID {camperId} not found.");
                        }
                    }
                }

                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
            }
        }

        public void DeleteCamper()
        {
            using (var context = new CampDbContext())
            {
                Console.WriteLine("List of All Campers:");

                var campers = context.Campers.ToList();

                // Create ConsoleTable for displaying all campers
                var campersTable = new ConsoleTable("ID", "First Name", "Last Name", "Age", "Gender", "Phone Number", "Cabin ID", "Move In Date", "Move Out Date");
                foreach (var camper in campers)
                {
                    campersTable.AddRow(camper.CamperId, camper.FirstName, camper.LastName, camper.Age, camper.Gender, camper.PhoneNumber, camper.CabinId, camper.MoveInDate.ToString("yyyy-MM-dd"), camper.MoveOutDate.ToString("yyyy-MM-dd"));
                }
                campersTable.Write(Format.Minimal);

                while (true)
                {
                    Console.Write("Enter the ID of the Camper you want to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int camperId))
                    {
                        var camperToDelete = context.Campers.Find(camperId);

                        if (camperToDelete != null)
                        {
                            context.Campers.Remove(camperToDelete);
                            context.SaveChanges();

                            Console.WriteLine($"Camper with ID {camperId} has been deleted.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Camper with ID {camperId} not found. Please enter a valid ID.");
                        }
                    }
                }

                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
            }
        }
    }
}

