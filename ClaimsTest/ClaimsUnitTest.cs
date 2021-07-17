using ClaimsPOCO;
using ClaimsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace ClaimsTest
{
    [TestClass]
    public class ClaimsUnitTest
    {
        private readonly ClaimRepos _claimRepo = new ClaimRepos();
        [TestInitialize] 
        public void Arrange()
        {
            ClaimsItems claimsItems = new ClaimsItems(123, ClaimType.Car, "wrecked", 200.99m, new DateTime { }, new DateTime { }, true);
            _claimRepo.AddClaimToQueueAndList(claimsItems);
        }
        [TestMethod]
        public void AddClaimToListAndQueue_ClaimIsNull_ReturnFalse()
        {
            ClaimsItems claimsItems = null;
            ClaimRepos claimRepos = new ClaimRepos();

            bool result = _claimRepo.AddClaimToQueueAndList(claimsItems);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void AddClaimToQueueAndList_NotNull_ReturnTrue()
        {
            ClaimsItems claimsItems = new ClaimsItems(123, ClaimType.Car, "wrecked", 200.99m, new DateTime { }, new DateTime { }, true);

            bool result = _claimRepo.AddClaimToQueueAndList(claimsItems);

            Assert.IsTrue(result);
        }
        [TestMethod] //Ask
        public void RemoveClaimFromList_ClaimDoesNotExist_ReturnFalse()
        {
            
        }
    }
}
