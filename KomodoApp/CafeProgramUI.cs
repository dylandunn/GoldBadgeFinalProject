using CafeMenuPOCO;
using CafeMenuRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenu
{
    class CafeProgramUI
    {
        private Repo repo = new Repo();
        
        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n\n\n\n Welcome to the KomodoCafe App. What Would you like to do?\n\n\n\n" +
                    "1.View Menu Items\n" +
                    "2.Create New Menu Item\n" +
                    "3.Delete Menu Item\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewAllMenuItems();
                        break;
                    case "2":
                        CreateNewMenuItem();
                        break;
                    case "3":
                        RemoveMenuItem();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye, Thanks for using the KomodoCafe App!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Enter a valid Option Number");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private void ViewAllMenuItems()
        {
            Console.Clear();
            List<MenuItems> listOfMenuItems = repo.GetMenuItemsList();
            foreach (MenuItems menuItem in listOfMenuItems)
            {
                Console.WriteLine($"Meal Number: {menuItem.MealNumber}\n" +
                    $"Meal Name: {menuItem.MealName}\n" +
                    $"Ingredients: {menuItem.Ingredients}\n" + 
                    $"Price: {menuItem.Price}");
            }
        }
        private void CreateNewMenuItem()
        {
            Console.Clear();
            MenuItems newMenuItem = new MenuItems();
            List<string> ingredients = new List<string>();
            newMenuItem.Ingredients = ingredients;

            Console.WriteLine("Enter Meal Number:");
            string mealNumberString = Console.ReadLine();
            newMenuItem.MealNumber = int.Parse(mealNumberString);

            Console.WriteLine("Enter Name of the Meal: ");
            newMenuItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter a Description for the Meal:");
            newMenuItem.Description = Console.ReadLine();

            Console.WriteLine("Enter 1st Ingredient for the Meal");
            string ingredient1 = Console.ReadLine();
            newMenuItem.Ingredients.Add(ingredient1);
            Console.WriteLine("Enter Next Ingredient:");
            string ingreident2 = Console.ReadLine();
            newMenuItem.Ingredients.Add(ingreident2);
            Console.WriteLine("Enter Next Ingredient:");
            string ingreident3 = Console.ReadLine();
            newMenuItem.Ingredients.Add(ingreident3);
            bool addIngredients = true;
            while (addIngredients)
            {

                Console.WriteLine("Would you like to add additional ingreidents? (y/n)");
                string option = Console.ReadLine().ToLower(); ;
                if (option.StartsWith("y"))
                {
                    Console.WriteLine("Enter next ingredient:");
                    string ingreident4 = Console.ReadLine();
                    newMenuItem.Ingredients.Add(ingreident4);
                }
                else if (option.StartsWith("n"))
                {
                    Console.WriteLine("Ingreidents have been added!");
                    Console.ReadLine();
                    addIngredients = false;
                }
                else Console.WriteLine("Enter a valid option (y or n)");
            }
            repo.AddMenuItemToList(newMenuItem);
        }
        private void RemoveMenuItem()
        {
            Console.Clear();
            ViewAllMenuItems();
            Console.WriteLine("Enter Meal Number of Menu Item you would like to remove:");
            string mealNumberAsString = Console.ReadLine();
            int mealNumberAsInt = int.Parse(mealNumberAsString);
            bool wasDeleted = repo.RemoveMenuItemFromList(mealNumberAsInt);
            if (wasDeleted)
            {
                Console.WriteLine("The Item was deleted!");
            }
            else
            {
                Console.WriteLine("The Item could not be removed.");
            }
            
                
        }
    }
}
