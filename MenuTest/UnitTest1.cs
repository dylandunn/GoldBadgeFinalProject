using CafeMenuPOCO;
using CafeMenuRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MenuTest
{
    [TestClass]
    public class RepoTests
    {
        private readonly Repo _repo = new Repo();
       [TestInitialize]
       public void Arrange()
        {
            List<string> list = new List<string>();
            MenuItems menuItems = new MenuItems(1231, "Burger", "A burger", list, 2.20m);
            _repo.AddMenuItemToList(menuItems);
        }
        [TestMethod]
        public void AddMenuItemToList_MenuItemIsNull_ReturnFalse()
        {
            MenuItems menuItems = null;
            Repo repo = new Repo();
 
            bool result = repo.AddMenuItemToList(menuItems);
            
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void AddMenuItemToList_NotNull_ReturnTrue()
        {
            List<string> list = new List<string>();
            MenuItems menuItems = new MenuItems(1231, "Burger", "A burger", list, 2.20m);
            Repo repo = new Repo();

            bool result = repo.AddMenuItemToList(menuItems);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetMenuItemByMealNumber_ReturnMenuItems()
        {
            int id = 1231;
            MenuItems result = _repo.GetMenuItemByMealNumber(id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetMenuItemByMealNumber_ReturnNull()
        {
            int id =1234;

            MenuItems result = _repo.GetMenuItemByMealNumber(id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void RemoveMenuItemFromList_MenuItemDoesNotExist_ReturnFalse()
        {
            int id = 1234;
            bool result = _repo.RemoveMenuItemFromList(id);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void RemoveMenuItemFromList_MenuItemDoesExist_ReturnTrue()
        {
            int id = 1231;
            bool result = _repo.RemoveMenuItemFromList(id);
            Assert.IsTrue(result);
        }
    }
}
