
using BadgesPOCO;
using BadgesRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    class BadgesProgramUI
    {
        private BadgesRepos badgesRepos = new BadgesRepos();
        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool running = true;
            while(running)
            {
                Console.WriteLine("\n\n\n Welcome to the Komodo Badge App! What would you like to do?\n\n\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        ViewAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Thanks for using the Komodo Badge App! Goodbye.");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private void AddNewBadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();
            List<string> doors = new List<string>();
            newBadge.Doors = doors;
                Console.WriteLine("Enter Badge ID number:");
                string idString = Console.ReadLine();
                int idInt;
                int.TryParse(idString, out idInt);
                if (!int.TryParse(idString, out idInt))
                {
                    Console.WriteLine("Please Enter a valid ID number");
                    Console.ReadLine();
                }
                newBadge.BadgeID = idInt;

            bool addDoor = true;
            while (addDoor)
            {
                Console.WriteLine("Enter door this badge needs access to:");
                string doorInput = Console.ReadLine();
                newBadge.Doors.Add(doorInput);
                Console.WriteLine("Would you like to add another door? (y/n)");
                string option = Console.ReadLine().ToLower();
                if (option.StartsWith("y"))
                {
                    Console.WriteLine("Enter next door:");
                    string doorInput2 = Console.ReadLine();
                    newBadge.Doors.Add(doorInput2);
                }
                else if (option.StartsWith("n"))
                {
                    Console.WriteLine("Doors have been added!");
                    Console.ReadLine();
                    addDoor = false;
                }
                else Console.WriteLine("Enter a valid option");
            }
           badgesRepos.CreateBadge(newBadge);
        }
        public void UpdateBadge()
        {
            Dictionary<int, Badge> badgeDictionary1 = badgesRepos.GetKeyValuePairs();
            Badge updateBadge = new Badge();
            List<string> doors = new List<string>();
            updateBadge.Doors = doors;
            Console.Clear();
            Console.WriteLine("Enter the ID of badge you'd like to update:");
            string inputString = Console.ReadLine();
            int inputInt;
            int.TryParse(inputString, out inputInt);
            if (!int.TryParse(inputString, out inputInt))
            {
                Console.WriteLine("Please enter a valid ID.");
                Console.ReadLine();
            }
            foreach (KeyValuePair<int, Badge> kvp1 in badgeDictionary1)
            {
                Console.WriteLine($"This Badge has access to doors: {kvp1.Value}");
            }
            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door");
            string doorOption = Console.ReadLine();
            switch(doorOption) 
            {
                case "1":
                    Console.WriteLine("What doors would you like to remove?");
                    string removeDoor = Console.ReadLine();
                    bool wasDeleted = badgesRepos.RemoveDoorFromBadge(inputInt, removeDoor);
                    if(wasDeleted)
                    {
                        Console.WriteLine("Door has been removed from this badge.");
                    }
                    else { Console.WriteLine("Door could not be removed."); }
                        break;
                case "2":
                    Console.WriteLine("Enter name of door you'd like to add:");
                    string doorToAdd = Console.ReadLine();
                    updateBadge.Doors.Add(doorToAdd);
                    break;
            }


        }
        public void ViewAllBadges()
        {
            Console.Clear();
            Dictionary<int, Badge> badgeDictionary = badgesRepos.GetKeyValuePairs();
            
            foreach (Badge kvp in badgeDictionary.Values)
            {
                Console.WriteLine($"Badge ID {kvp.BadgeID}\n" +
                    $"Doors this badge has access to: {kvp.Doors}\n" +
                    $"--------------------------------------------");
            }
            

        }
    }
   
}
