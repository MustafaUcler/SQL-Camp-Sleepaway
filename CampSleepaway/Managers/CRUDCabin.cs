using ConsoleTables;
using Microsoft.EntityFrameworkCore;
using SP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace SP2.Managers
{
    public class CRUDCabin
    {
        static ShowMenuManager showMenuManager = new ShowMenuManager();

        public void Cabin()
        {
            while (true)
            {
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
                        CreateCabin();
                        break;
                    case 1:
                        ReadCabin();
                        break;
                    case 2:
                        UpdateCabin();
                        break;
                    case 3:
                        DeleteCabin();
                        break;
                    case 4:
                        return;
                }
                Console.ReadKey();
            }
        }

        public void CreateCabin()
        {
            
            using (var context = new CampDbContext())
            {

                Console.WriteLine("Add a new Cabin:");

                Console.Write("Cabin Name: ");
                string cabinName = Console.ReadLine();

                Console.Write("Cabin Color: ");
                string cabinColor = Console.ReadLine();

                // Check if the cabin already exists
                if (context.Cabins.Any(cabin => cabin.CabinName.ToLower() == cabinName.ToLower()))
                {
                    Console.WriteLine($"A Cabin with the name {cabinName} already exists.");
                    Console.WriteLine("Press any key to return to the menu.");
                    
                    return;
                }

                var newCabin = new Cabin
                {
                    CabinName = cabinName,
                    CabinColor = cabinColor
                };

                context.Cabins.Add(newCabin);
                context.SaveChanges();

                Console.WriteLine($"The Cabin {cabinName} has been added.");
                Console.WriteLine("Press any key to return to the menu.");
            }
        }

        public void ReadCabin()
        {
            using (var context = new CampDbContext())
            {
                var cabins = context.Cabins.ToList();

                Console.WriteLine("List of Cabins:");

                var table = new ConsoleTable("ID", "Name", "Color");

                foreach (var cabin in cabins)
                {
                    table.AddRow(cabin.CabinId, cabin.CabinName, cabin.CabinColor);
                }

                table.Write(Format.Minimal);
                Console.WriteLine("Press any key to return to the menu.");
            }
        }

        public void UpdateCabin()
        {
            using (var context = new CampDbContext())
            {
                var cabins = context.Cabins.ToList();

                Console.WriteLine("Update CABIN:");

                var cabinsTable = new ConsoleTable("ID", "Name", "Color");
                cabins.ForEach(cabin => cabinsTable.AddRow(cabin.CabinId, cabin.CabinName, cabin.CabinColor));
                cabinsTable.Write(Format.Minimal);

                int CabinId;

                while (true)
                {
                    Console.Write("Enter the ID of the Cabin to update: ");
                    if (int.TryParse(Console.ReadLine(), out CabinId))
                    {
                        var cabinToUpdate = cabins.FirstOrDefault(c => c.CabinId == CabinId);

                        if (cabinToUpdate != null)
                        {

                            Console.Write("New Cabin Name: ");
                            string newCabinName = Console.ReadLine();

                            Console.Write("New Cabin Color: ");
                            string newCabinColor = Console.ReadLine();

                            cabinToUpdate.CabinName = newCabinName;
                            cabinToUpdate.CabinColor = newCabinColor;

                            context.SaveChanges();

                            Console.WriteLine("The Cabin information has been updated.");

                            break; 
                        }
                        else
                        {
                            Console.WriteLine($"Cabin with ID {CabinId} not found.");
                        }
                    }
                }

                Console.WriteLine("Press any key to return to the menu.");
            }
        }

        public void DeleteCabin()
        {
            using (var context = new CampDbContext())
            {
                var cabins = context.Cabins.Include(c => c.Campers).Include(c => c.Counselor).ToList();

                Console.WriteLine("Delete a CABIN:");

                var cabinsTable = new ConsoleTable("ID", "Name", "Color");
                cabins.ForEach(cabin => cabinsTable.AddRow(cabin.CabinId, cabin.CabinName, cabin.CabinColor));
                cabinsTable.Write(Format.Minimal);

                int selectedCabinId;

                while (true)
                {
                    Console.Write("Enter the ID of the Cabin to delete: ");
                    if (int.TryParse(Console.ReadLine(), out selectedCabinId))
                    {
                        var cabinToDelete = cabins.FirstOrDefault(c => c.CabinId == selectedCabinId);

                        if (cabinToDelete != null)
                        {
                            if (cabinToDelete.Campers != null && cabinToDelete.Campers.Count > 0 || cabinToDelete.Counselor != null)
                            {
                                Console.WriteLine($"Campers and/or Counselor found in Cabin {cabinToDelete.CabinId}:");

                                var campersTable = new ConsoleTable("Camper ID", "Name");
                                cabinToDelete.Campers?.ForEach(camper => campersTable.AddRow(camper.CamperId, $"{camper.FirstName} {camper.LastName}"));
                                campersTable.Write(Format.Minimal);

                                if (cabinToDelete.Counselor != null)
                                {
                                    var counselorTable = new ConsoleTable("Counselor ID", "Name");
                                    counselorTable.AddRow(cabinToDelete.Counselor.CounselorId, $"{cabinToDelete.Counselor.FirstName} {cabinToDelete.Counselor.LastName}");
                                    counselorTable.Write(Format.Minimal);
                                }

                                Console.WriteLine("Are you sure you want to delete this Cabin?");
                                Console.Write("Enter 'YES' to confirm, or any other input to cancel: ");
                                string confirmationChoice = Console.ReadLine();

                                if (confirmationChoice?.ToUpper() == "YES")
                                {
                                    // Set CabinId to null for counselor
                                    if (cabinToDelete.Counselor != null)
                                    {
                                        cabinToDelete.Counselor.CabinId = null;
                                        context.Entry(cabinToDelete.Counselor).State = EntityState.Modified; // Mark as modified
                                    }

                                    context.Cabins.Remove(cabinToDelete);
                                    context.SaveChanges();

                                    Console.WriteLine($"Cabin with ID {cabinToDelete.CabinId} has been deleted.");
                                    Console.WriteLine("Campers and Counselor are now cabinless, you can go to campers/counselor CRUD and update them to a new cabin!.");
                                }
                                else
                                {
                                    Console.WriteLine("Deletion canceled. Press any key to return to the menu.");
                                }
                            }
                            else
                            {
                                context.Cabins.Remove(cabinToDelete);
                                context.SaveChanges();

                                Console.WriteLine($"Cabin with ID {cabinToDelete.CabinId} has been deleted.");
                            }

                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Cabin with ID {selectedCabinId} not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }

                Console.WriteLine("Press any key to return to the menu.");
            }
        }


    }
}
