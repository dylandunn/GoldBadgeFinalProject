using BadgesPOCO;
using BadgesRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BadgesTest
{
    [TestClass]
    public class BadgesReposTest
    {
        private readonly BadgesRepos _badgesRepos = new BadgesRepos();
        [TestInitialize]
        public void Arrange()
        {
            List<string> doors = new List<string>();
            Badge badge = new Badge(123, doors);
            _badgesRepos.CreateBadge(badge);

        }
        [TestMethod]
        public void CreateBadge_BadgeIsNull_ReturnFalse()
        {
            Badge badge = null;
            BadgesRepos badgesRepos = new BadgesRepos();

            bool result = _badgesRepos.CreateBadge(badge);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CreateBadge_BadgeExists_ReturnTrue()
        {
            List<string> doors = new List<string>();
            Badge badge = new Badge(123, doors);
            BadgesRepos badgesRepos = new BadgesRepos();
            _badgesRepos.CreateBadge(badge);

            bool result = _badgesRepos.CreateBadge(badge);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetBadgeByKey_ReturnBadge()
        {
            int id = 123;
            Badge result = _badgesRepos.GetBadgeByKey(id);
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void GetBadgeByKey_ReturnNull()
        {
            int id = 124;
            Badge result = _badgesRepos.GetBadgeByKey(id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void RemoveDoorFromBadge_DoorExists_ReturnTrue()
        {
            int id = 123;
            string doorName = "a5";

            bool result = _badgesRepos.RemoveDoorFromBadge(id, doorName);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void RemoveDoorFromBadge_DoorDoesNotExist_ReturnFalse()
        {
            int id = 124;
            string doorName = "a4";

            bool result = _badgesRepos.RemoveDoorFromBadge(id, doorName);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void UpdateBadge_BadgeDoesNotExist_ReturnFalse()
        {
            int id = 124;
            Badge updatedBadge = new Badge();

            bool result = _badgesRepos.UpdateBadge(id, updatedBadge);

            Assert.IsFalse(result);

        }
        [TestMethod]
        public void UpdateBadge_BadgeDoesExist_ReturnTrue()
        {
            int id = 123;
            Badge updatedBadge = new Badge();

            bool result = _badgesRepos.UpdateBadge(id, updatedBadge);

            Assert.IsTrue(result);
        }
    }
}
