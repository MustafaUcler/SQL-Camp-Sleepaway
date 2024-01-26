using System;
using System.Collections.Generic;
using ConsoleTables;
using Microsoft.EntityFrameworkCore;
using SP2;
using SP2.Managers;
using SP2.Models;
                                    ///////////////////////// SAID: ABDUL: MUSTAFA: \\\\\\\\\\\\\\\\\\\\\\\\\
class Program

{
    static ShowMenuManager showMenuManager = new ShowMenuManager();
    static CRUDCabin crudCabin = new CRUDCabin();
    static CRUDCamper crudCamper = new CRUDCamper();
    static CRUDCouncelor crudCouncelor = new CRUDCouncelor();
    static CRUDNextOfKin crudNextOfKin = new CRUDNextOfKin();

    static void Main()
    {

        while (true)
        {

            List<string> menuOptions = new List<string>
            {
                "CRUD",
                "Show all campers",
                "Show campers based on cabin",
                "Show campers based on counselor",
                "Exit"
            };

            Console.Clear();

            int selectedOption = showMenuManager.ShowMenu("Welcome to Camp Sleepaway Management System", menuOptions);

            switch (selectedOption)
            {
                case 0:
                    HandleCRUDSubMenu(crudCabin, crudCamper, crudCouncelor, crudNextOfKin, showMenuManager);
                    break;
                case 1:
                    ShowAllCampers();
                    break;
                case 2:
                    SearchCampersBasedOnCabin();
                    break;
                case 3:
                    SearchCampersBasedOnCounselor();
                    break;
                case 4:
                    Environment.Exit(0);
                    return;
                    
            }

        }
    }

    static void HandleCRUDSubMenu(SP2.Managers.CRUDCabin crudCabin,
                                SP2.Managers.CRUDCamper crudCamper,
                                SP2.Managers.CRUDCouncelor crudCouncelor,
                                SP2.Managers.CRUDNextOfKin crudNextOfKin,
                                SP2.Managers.ShowMenuManager showMenuManager)
    {
        while (true)
        {
            
            List<string> crudOptions = new List<string>
            {
                "CABIN",
                "CAMPER",
                "COUNSELOR",
                "NEXTOFKIN",
                "Tillbaka"
            };

            Console.Clear();

            int selectedCRUDOption = showMenuManager.ShowMenu("Choose: ", crudOptions);

            switch (selectedCRUDOption)
            {
                case 0:
                    crudCabin.Cabin();
                    break;
                case 1:
                    crudCamper.Camper();
                    break;
                case 2:
                    crudCouncelor.Councelor();
                    break;
                case 3:
                    crudNextOfKin.NextOfKin();
                    break;
                case 4:
                    return;

            }

            Console.ReadKey();
        }
    }
    static void ShowAllCampers()
    {
        Console.Clear();
        using (var context = new CampDbContext())
        {
            var campers = context.Campers
                .Include(camper => camper.Cabin)
                .Include(camper => camper.NextOfKins)
                .ToList();

            if (campers.Count > 0)
            {
                var campersTable = new ConsoleTable("Camper", "Cabin", "Next of Kin");

                foreach (var camper in campers)
                {
                    
                    if (camper.Cabin?.Counselor != null)
                    {
                        continue;
                    }

                    var nextOfKinNames = string.Join(", ", camper.NextOfKins.Select(nextOfKin => $"{nextOfKin.FirstName} {nextOfKin.LastName}"));
                    campersTable.AddRow($"{camper.FirstName} {camper.LastName}", camper.Cabin?.CabinName, nextOfKinNames);
                }

                campersTable.Write(Format.Minimal);
            }
            else
            {
                Console.WriteLine("No campers found in the database.");
            }
        }

        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();
    }
    static void SearchCampersBasedOnCabin()
    {
        Console.Clear();
        using (var context = new CampDbContext())
        {
            List<string> cabinNames = context.Cabins.Select(cabin => cabin.CabinName).ToList();
            int selectedCabinIndex = showMenuManager.ShowMenu("Choose a Cabin:", cabinNames);

            if (selectedCabinIndex < 0 || selectedCabinIndex >= cabinNames.Count)
            {
                Console.WriteLine("Invalid selection. Returning to main menu.");
                return;
            }

            string selectedCabinName = cabinNames[selectedCabinIndex];

            var cabin = context.Cabins
                .Include(c => c.Counselor)
                .Single(c => c.CabinName == selectedCabinName);

            var campersInCabin = context.Campers
                .Include(camper => camper.Cabin)
                .Include(camper => camper.NextOfKins)
                .Where(camper => camper.Cabin.CabinName == selectedCabinName)
                .ToList();

            if (cabin.Counselor == null)
            {
                Console.WriteLine($"Warning: {selectedCabinName} does not have a counselor assigned.");
            }

            if (campersInCabin.Count > 0)
            {
                var campersTable = new ConsoleTable("Camper", "Counselor", "Next of Kin");

                foreach (var camper in campersInCabin)
                {
                    var nextOfKinNames = string.Join(", ", camper.NextOfKins.Select(nextOfKin => $"{nextOfKin.FirstName} {nextOfKin.LastName}"));
                    campersTable.AddRow($"{camper.FirstName} {camper.LastName}", camper.Cabin?.Counselor?.FirstName ?? "No Counselor assigned", nextOfKinNames);
                }

                Console.WriteLine($"Campers in {selectedCabinName}:");
                campersTable.Write(Format.Minimal);
            }
            else
            {
                Console.WriteLine($"No campers found in {selectedCabinName}.");
            }
        }

        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();
    }
    static void SearchCampersBasedOnCounselor()
    {
        Console.Clear();
        using (var context = new CampDbContext())
        {
            List<string> counselorNames = context.Counselors.Select(counselor => $"{counselor.FirstName} {counselor.LastName}").ToList();
            int selectedCounselorIndex = showMenuManager.ShowMenu("Choose a Counselor:", counselorNames);

            if (selectedCounselorIndex < 0 || selectedCounselorIndex >= counselorNames.Count)
            {
                Console.WriteLine("Invalid selection. Returning to main menu.");
                return;
            }

            string selectedCounselorFullName = counselorNames[selectedCounselorIndex];
            string[] selectedCounselorParts = selectedCounselorFullName.Split(' ');
            string selectedCounselorFirstName = selectedCounselorParts[0];
            string selectedCounselorLastName = selectedCounselorParts[1];

            var campersForCounselor = context.Campers
                .Include(camper => camper.Cabin)
                .Include(camper => camper.NextOfKins)
                .Where(camper => camper.Cabin.Counselor.FirstName == selectedCounselorFirstName && camper.Cabin.Counselor.LastName == selectedCounselorLastName)
                .ToList();

            if (campersForCounselor.Count > 0)
            {
                var campersTable = new ConsoleTable("Camper", "Cabin", "Next of Kin");

                foreach (var camper in campersForCounselor)
                {
                    var nextOfKinNames = string.Join(", ", camper.NextOfKins.Select(nextOfKin => $"{nextOfKin.FirstName} {nextOfKin.LastName}"));
                    campersTable.AddRow($"{camper.FirstName} {camper.LastName}", camper.Cabin?.CabinName, nextOfKinNames);
                }

                Console.WriteLine($"Campers assigned to {selectedCounselorFullName}:");
                campersTable.Write(Format.Minimal);
            }
            else
            {
                Console.WriteLine($"No campers found for {selectedCounselorFullName}.");
            }
        }

        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();
    }




}