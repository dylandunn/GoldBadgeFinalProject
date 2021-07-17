using CafeMenuPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenuRepo
{
    public class Repo
    {
        private List<MenuItems> _listOfMenuItems = new List<MenuItems>();
        private int _idCounter = default;
        public bool AddMenuItemToList(MenuItems menuItem)
        {
            if(menuItem is null)
            {
                return false;
            }
            menuItem.MealNumber = ++_idCounter;
            _listOfMenuItems.Add(menuItem);

            return true;
        }
     
        public List<MenuItems> GetMenuItemsList()
        {
            return _listOfMenuItems;
        }
       
        public bool RemoveMenuItemFromList(int mealNumber)
        {
            MenuItems menuItem = GetMenuItemByMealNumber(mealNumber);
            if (menuItem == null)
            {
                return false;
            }
            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(menuItem);
            if(initialCount > _listOfMenuItems.Count) { return true; }
            else { return false; }
        }
        public MenuItems GetMenuItemByMealNumber(int mealNumber)
        {
            foreach(MenuItems menuItem in _listOfMenuItems)
            {
                if(menuItem.MealNumber == mealNumber)
                {
                    return menuItem;
                }
            }
            return null;
        }
    }
}
