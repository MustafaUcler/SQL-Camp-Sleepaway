using SP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using System.Globalization;

namespace SP2.Managers
{
    public class CRUDCouncelor
    {
        static ShowMenuManager showMenuManager = new ShowMenuManager();
        public void Councelor()
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
                        CreateCounselor();
                        break;
                    case 1:
                        ReadCounselor();
                        break;
                    case 2:
                        UpdateCounselor();
                        break;
                    case 3:
                        DeleteCounselor();
                        break;
                    case 4:
                        return;

                }
                Console.ReadKey();
            }
        }
        public void CreateCounselor()
        {
            using (var context = new CampDbContext())
            {
                Console.WriteLine("Add a new counselor:");

                Console.Write("First Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();

                Console.Write("Age: ");
                if (!int.TryParse(Console.ReadLine(), out int age) || age < 0)
                {
                    Console.WriteLine("Invalid age. Please enter a valid positive integer.");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Do you want to add the counselor to a cabin? (YES/NO): ");
                string addToCabinChoice = Console.ReadLine();

                bool addToCabin = addToCabinChoice.ToUpper() == "YES";

                int? chosenCabinId = null;

                if (addToCabin)
                {
                    while (true)
                    {
                        Console.WriteLine("Available Cabins without a Counselor:");

                        var cabinsWithoutCounselor = context.Cabins
                            .Where(c => !context.Counselors.Any(counselor => counselor.CabinId == c.CabinId))
                            .ToList();

                        if (cabinsWithoutCounselor.Count == 0)
                        {
                            Console.WriteLine("No available cabins without a counselor.");
                            Console.ReadKey();
                            return;
                        }

                        var cabinsTable = new ConsoleTable("ID", "Name", "Color");
                        cabinsWithoutCounselor.ForEach(cabin => cabinsTable.AddRow(cabin.CabinId, cabin.CabinName, cabin.CabinColor));
                        cabinsTable.Write(Format.Minimal);

                        Console.Write("Choose the ID of the cabin to assign the counselor: ");
                        if (!int.TryParse(Console.ReadLine(), out int tempCabinId) || !cabinsWithoutCounselor.Any(cabin => cabin.CabinId == tempCabinId))
                        {
                            Console.WriteLine("Invalid cabin ID. Please choose a valid ID from the list.");
                        }
                        else
                        {
                            chosenCabinId = tempCabinId;
                            break;
                        }
                    }
                }

                Console.Write("Years of Experience: ");
                if (!int.TryParse(Console.ReadLine(), out int yearsExperience) || yearsExperience < 0)
                {
                    Console.WriteLine("Invalid years of experience. Please enter a valid positive integer.");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Responsibility Start Date (YYYY-MM-DD): ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime responsibilityStartDate))
                {
                    Console.WriteLine("Invalid date format. Please enter a valid date (YYYY-MM-DD).");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Responsibility End Date (leave blank for ongoing responsibility) (YYYY-MM-DD): ");
                DateTime? responsibilityEndDate = null;
                string endDateInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(endDateInput))
                {
                    if (!DateTime.TryParseExact(endDateInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate))
                    {
                        Console.WriteLine("Invalid date format. Please enter a valid date (YYYY-MM-DD) or leave it blank.");
                        Console.ReadKey();
                        return;
                    }
                    responsibilityEndDate = endDate;
                }

                var newCounselor = new Counselor
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    YearsExperience = yearsExperience,
                    CabinId = addToCabin ? chosenCabinId : null,
                    ResponsibilityStartDate = responsibilityStartDate,
                    ResponsibilityEndDate = responsibilityEndDate
                };

                context.Counselors.Add(newCounselor);

                if (addToCabin)
                {
                    Console.WriteLine($"The counselor {firstName} {lastName} has been added to Cabin ID {chosenCabinId}.");
                }
                else
                {
                    Console.WriteLine($"The counselor {firstName} {lastName} has been added without assigning to a cabin.");
                }

                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
            }
        }



        public void ReadCounselor()
        {
            using (var context = new CampDbContext())
            {
                var counselors = context.Counselors.ToList();

                Console.WriteLine("List of counselors:");

                var table = new ConsoleTable("Counselor ID", "Name", "Age", "Years of Experience", "Cabin ID", "Responsibility Start Date", "Responsibility End Date");

                foreach (var counselor in counselors)
                {
                    table.AddRow(
                        counselor.CounselorId,
                        $"{counselor.FirstName} {counselor.LastName}",
                        counselor.Age,
                        counselor.YearsExperience,
                        counselor.CabinId,
                        counselor.ResponsibilityStartDate.ToString("yyyy-MM-dd"),
                        counselor.ResponsibilityEndDate.HasValue ? counselor.ResponsibilityEndDate.Value.ToString("yyyy-MM-dd") : "N/A"

                    );
                }

                table.Write(Format.Minimal);
                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
            }
        }

        public void UpdateCounselor()
        {
            using (var context = new CampDbContext())
            {
                var counselors = context.Counselors.ToList();

                Console.WriteLine("Update a COUNSELOR:");

                var counselorsTable = new ConsoleTable("ID", "Name", "Age", "Years of Experience", "Cabin ID", "Responsibility Start Date", "Responsibility End Date");
                counselors.ForEach(counselor => counselorsTable.AddRow(counselor.CounselorId, $"{counselor.FirstName} {counselor.LastName}", counselor.Age, counselor.YearsExperience, counselor.CabinId, counselor.ResponsibilityStartDate.ToString("yyyy-MM-dd"), counselor.ResponsibilityEndDate.HasValue ? counselor.ResponsibilityEndDate.Value.ToString("yyyy-MM-dd") : "N/A"));
                counselorsTable.Write(Format.Minimal);

                int counselorId;

                while (true)
                {
                    Console.Write("Enter the ID of the Counselor you want to update: ");
                    if (int.TryParse(Console.ReadLine(), out counselorId))
                    {
                        var counselorToUpdate = context.Counselors.Find(counselorId);

                        if (counselorToUpdate != null)
                        {

                            Console.Write("New First Name: ");
                            string newFirstName = Console.ReadLine();

                            Console.Write("New Last Name: ");
                            string newLastName = Console.ReadLine();

                            Console.Write("New Age: ");
                            int newAge = int.Parse(Console.ReadLine());

                            Console.Write("New Years of Experience: ");
                            int newYearsExperience = int.Parse(Console.ReadLine());

                            // Display available cabins without a counselor
                            Console.WriteLine("Available Cabins without a Counselor:");
                            var availableCabins = context.Cabins
                                .Where(c => !context.Counselors.Any(co => co.CabinId == c.CabinId))
                                .ToList();

                            if (availableCabins.Count == 0)
                            {
                                Console.WriteLine("No available cabins without a counselor.");
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
                                    counselorToUpdate.CabinId = newCabinId;
                                    break;
                                }
                            }

                            Console.Write("New Responsibility Start Date (YYYY-MM-DD): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime newResponsibilityStartDate))
                            {
                                counselorToUpdate.ResponsibilityStartDate = newResponsibilityStartDate;
                            }

                            Console.Write("New Responsibility End Date (leave blank for ongoing responsibility) (YYYY-MM-DD): ");
                            DateTime? newResponsibilityEndDate = null;
                            string endDateInput = Console.ReadLine();
                            if (!string.IsNullOrEmpty(endDateInput))
                            {
                                if (DateTime.TryParse(endDateInput, out DateTime endDate))
                                {
                                    newResponsibilityEndDate = endDate;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid date format. Please enter a valid date (YYYY-MM-DD) or leave it blank.");
                                    Console.ReadKey();
                                    return;
                                }
                            }

                            counselorToUpdate.ResponsibilityEndDate = newResponsibilityEndDate;
                            context.SaveChanges();

                            Console.WriteLine("The Counselor information has been updated.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Counselor with ID {counselorId} not found.");
                        }
                    }
                }

                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
            }
        }

        public void DeleteCounselor()
        {
            using (var context = new CampDbContext())
            {
                Console.WriteLine("List of All Counselors:");

                var counselors = context.Counselors.ToList();

                var counselorsTable = new ConsoleTable("ID", "Name", "Age", "Years of Experience", "Cabin ID", "Responsibility Start Date", "Responsibility End Date");
                foreach (var counselor in counselors)
                {
                    counselorsTable.AddRow(counselor.CounselorId, $"{counselor.FirstName} {counselor.LastName}", counselor.Age, counselor.YearsExperience, counselor.CabinId, counselor.ResponsibilityStartDate.ToString("yyyy-MM-dd"), counselor.ResponsibilityEndDate.HasValue ? counselor.ResponsibilityEndDate.Value.ToString("yyyy-MM-dd") : "N/A");
                }
                counselorsTable.Write(Format.Minimal);

                while (true)
                {
                    Console.Write("Enter the ID of the Counselor you want to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int counselorId))
                    {
                        var counselorToDelete = context.Counselors.Find(counselorId);

                        if (counselorToDelete != null)
                        {
                            context.Counselors.Remove(counselorToDelete);
                            context.SaveChanges();

                            Console.WriteLine($"Counselor with ID {counselorId} has been deleted.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Counselor with ID {counselorId} not found. Please enter a valid ID.");
                        }
                    }
                }

                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
            }
        }
    }
}

