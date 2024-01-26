using SP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
                                   


namespace SP2.Managers
{
    public class CRUDNextOfKin
    {
        static ShowMenuManager showMenuManager = new ShowMenuManager();
        public void NextOfKin()
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
                            CreateNextOfKin();
                            break;
                        case 1:
                            ReadNextOfKin();
                            break;
                        case 2:
                            UpdateNextOfKin();
                            break;
                        case 3:
                            DeleteNextOfKin();
                            break;
                        case 4:
                            return;

                }
                Console.ReadKey();
            }
        }
        public void CreateNextOfKin()
        {
            using (var context = new CampDbContext())
            {
                Console.WriteLine("Add a new next of kin:");

                Console.Write("First Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();

                Console.Write("Age: ");
                if (!int.TryParse(Console.ReadLine(), out int age))
                {
                    Console.WriteLine("Invalid age format. Please enter a valid number.");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Gender: ");
                string gender = Console.ReadLine();

                Console.Write("Phone Number: ");
                string phoneNumber = Console.ReadLine();

                while (true)
                {
                    // Display available campers
                    Console.WriteLine("Available Campers:");
                    var campers = context.Campers.ToList();
                    var campersTable = new ConsoleTable("Camper ID", "First Name", "Last Name", "Cabin ID", "Phone Number", "Move In Date", "Move Out Date");
                    campers.ForEach(camper => campersTable.AddRow(camper.CamperId, camper.FirstName, camper.LastName, camper.CabinId, camper.PhoneNumber, camper.MoveInDate.ToString("yyyy-MM-dd"), camper.MoveOutDate.ToString("yyyy-MM-dd")));
                    campersTable.Write(Format.Minimal);

                    Console.Write("Camper ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int camperId))
                    {
                        Console.WriteLine("Invalid camper ID format. Please enter a valid number.");
                        Console.ReadKey();
                        return;
                    }

                    if (campers.Any(camper => camper.CamperId == camperId))
                    {
                        // Valid Camper ID entered
                        Console.Write("Relation to Camper: ");
                        string relationToCamper = Console.ReadLine();

                        Console.Write("Move In Date (YYYY-MM-DD): ");
                        if (!DateTime.TryParse(Console.ReadLine(), out DateTime moveInDate))
                        {
                            Console.WriteLine("Invalid date format. Please enter a valid date (YYYY-MM-DD).");
                            Console.ReadKey();
                            return;
                        }

                        Console.Write("Move Out Date (YYYY-MM-DD): ");
                        if (!DateTime.TryParse(Console.ReadLine(), out DateTime moveOutDate))
                        {
                            Console.WriteLine("Invalid date format. Please enter a valid date (YYYY-MM-DD).");
                            Console.ReadKey();
                            return;
                        }


                        var newNextOfKin = new NextOfKin
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Age = age,
                            Gender = gender,
                            PhoneNumber = phoneNumber,
                            CamperId = camperId,
                            RelationToCamper = relationToCamper,
                            MoveInDate = moveInDate,
                            MoveOutDate = moveOutDate
                        };

                        context.NextOfKins.Add(newNextOfKin);
                        context.SaveChanges();

                        Console.WriteLine($"The next of kin {firstName} {lastName} has been added.");
                        Console.WriteLine("Press any key to return to the menu.");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Camper ID. Please enter a valid Camper ID from the list.");
                    }
                }
            }
        }

        public void ReadNextOfKin()
        {
            using (var context = new CampDbContext())
            {
                var nextOfKins = context.NextOfKins.ToList();

                Console.WriteLine("List of next of kin:");

                var table = new ConsoleTable("Next of Kin ID", "Name", "Age", "Gender", "Phone Number", "Camper ID", "Relation to Camper", "Move In Date", "Move Out Date");

                foreach (var nextOfKin in nextOfKins)
                {
                    table.AddRow(
                        nextOfKin.NextOfKinId,
                        $"{nextOfKin.FirstName} {nextOfKin.LastName}",
                        nextOfKin.Age,
                        nextOfKin.Gender,
                        nextOfKin.PhoneNumber,
                        nextOfKin.CamperId,
                        nextOfKin.RelationToCamper,
                        nextOfKin.MoveInDate.ToString("yyyy-MM-dd"),
                        nextOfKin.MoveOutDate.HasValue ? nextOfKin.MoveOutDate.Value.ToString("yyyy-MM-dd") : "N/A"
                    );
                }

                table.Write(Format.Minimal);
                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
            }
        }

        public void UpdateNextOfKin()
        {
            using (var context = new CampDbContext())
            {
                Console.WriteLine("Update a NEXT OF KIN:");

                while (true)
                {
                    var nextOfKins = context.NextOfKins.ToList();

                    var nextOfKinsTable = new ConsoleTable("ID", "Name", "Age", "Gender", "Phone Number", "Camper ID", "Relation to Camper", "Move In Date", "Move Out Date");
                    nextOfKins.ForEach(nok => nextOfKinsTable.AddRow(nok.NextOfKinId, $"{nok.FirstName} {nok.LastName}", nok.Age, nok.Gender, nok.PhoneNumber, nok.CamperId, nok.RelationToCamper, nok.MoveInDate.ToString("yyyy-MM-dd"), nok.MoveOutDate.HasValue ? nok.MoveOutDate.Value.ToString("yyyy-MM-dd") : "N/A"));
                    nextOfKinsTable.Write(Format.Minimal);

                    int nextOfKinId;

                    Console.Write("Enter the ID of the Next of Kin you want to update: ");
                    if (int.TryParse(Console.ReadLine(), out nextOfKinId))
                    {
                        var nextOfKinToUpdate = context.NextOfKins.Find(nextOfKinId);

                        if (nextOfKinToUpdate != null)
                        {
                            Console.Write("New First Name: ");
                            string newFirstName = Console.ReadLine();

                            Console.Write("New Last Name: ");
                            string newLastName = Console.ReadLine();

                            Console.Write("New Age: ");
                            if (int.TryParse(Console.ReadLine(), out int newAge))
                            {
                                nextOfKinToUpdate.Age = newAge;
                            }

                            Console.Write("New Gender: ");
                            string newGender = Console.ReadLine();

                            Console.Write("New Phone Number: ");
                            string newPhoneNumber = Console.ReadLine();

                            // Display available campers for selection
                            Console.WriteLine("Available Campers:");
                            var availableCampers = context.Campers.ToList();
                            var campersTable = new ConsoleTable("ID", "Name", "Age", "Gender", "Phone Number", "Cabin ID", "Move In Date", "Move Out Date");
                            availableCampers.ForEach(camper => campersTable.AddRow(camper.CamperId, $"{camper.FirstName} {camper.LastName}", camper.Age, camper.Gender, camper.PhoneNumber, camper.CabinId, camper.MoveInDate.ToString("yyyy-MM-dd"), camper.MoveOutDate.ToString("yyyy-MM-dd")));
                            campersTable.Write(Format.Minimal);

                            while (true)
                            {
                                Console.Write("New Camper ID: ");
                                if (int.TryParse(Console.ReadLine(), out int newCamperId))
                                {
                                    if (availableCampers.Any(camper => camper.CamperId == newCamperId))
                                    {
                                        nextOfKinToUpdate.CamperId = newCamperId;
                                        break; // Exit the loop if a valid Camper ID is provided
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Camper ID. Please choose a valid ID from the list.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Camper ID format. Please enter a valid number.");
                                }
                            }

                            Console.Write("New Relation to Camper: ");
                            string newRelationToCamper = Console.ReadLine();

                            Console.Write("New Move In Date (YYYY-MM-DD): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime newMoveInDate))
                            {
                                nextOfKinToUpdate.MoveInDate = newMoveInDate;
                            }

                            Console.Write("New Move Out Date (leave blank for ongoing tracking) (YYYY-MM-DD): ");
                            DateTime? newMoveOutDate = null;
                            string endDateInput = Console.ReadLine();
                            if (!string.IsNullOrEmpty(endDateInput))
                            {
                                if (DateTime.TryParse(endDateInput, out DateTime endDate))
                                {
                                    newMoveOutDate = endDate;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid date format. Please enter a valid date (YYYY-MM-DD) or leave it blank.");
                                    Console.ReadKey();
                                    return;
                                }
                            }

                            nextOfKinToUpdate.MoveOutDate = newMoveOutDate;
                            context.SaveChanges();

                            Console.WriteLine("The Next of Kin information has been updated.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Next of Kin with ID {nextOfKinId} not found. Please enter a valid ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID format. Please enter a valid numeric ID.");
                    }
                }

                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
            }
        }

        public void DeleteNextOfKin()
        {
            using (var context = new CampDbContext())
            {
                Console.WriteLine("List of All Next of Kin:");

                var nextOfKinList = context.NextOfKins.ToList();

                if (nextOfKinList.Count > 0)
                {
                    var nextOfKinTable = new ConsoleTable("ID", "Name", "Age", "Gender", "Phone Number", "Camper ID", "Relation to Camper", "Move In Date", "Move Out Date");
                    foreach (var nok in nextOfKinList)
                    {
                        nextOfKinTable.AddRow(nok.NextOfKinId, $"{nok.FirstName} {nok.LastName}", nok.Age, nok.Gender, nok.PhoneNumber, nok.CamperId, nok.RelationToCamper, nok.MoveInDate.ToString("yyyy-MM-dd"), nok.MoveOutDate.HasValue ? nok.MoveOutDate.Value.ToString("yyyy-MM-dd") : "N/A");
                    }
                    nextOfKinTable.Write(Format.Minimal);

                    while (true)
                    {
                        Console.Write("Enter the ID of the Next of Kin you want to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int nextOfKinId))
                        {
                            var nextOfKinToDelete = context.NextOfKins.Find(nextOfKinId);

                            if (nextOfKinToDelete != null)
                            {
                                context.NextOfKins.Remove(nextOfKinToDelete);
                                context.SaveChanges();

                                Console.WriteLine($"Next of Kin with ID {nextOfKinId} has been deleted.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Next of Kin with ID {nextOfKinId} not found. Please enter a valid ID.");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No Next of Kin found in the database.");
                }

                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
            }
        }
    }
}
