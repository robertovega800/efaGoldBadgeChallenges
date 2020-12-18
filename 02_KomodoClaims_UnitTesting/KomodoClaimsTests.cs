using _02_KomodoClaims_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_KomodoClaims_UnitTesting
{
    [TestClass]
    public class KomodoClaimsTests
    {
        [TestMethod]
        public void SetId_ShouldSetCorrectInt()
        {
            KomodoClaims claim = new KomodoClaims();

            claim.ClaimID = int.Parse("01");

            int expected = 1;
            int actual = claim.ClaimID;

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        
        public void SetDescription_ShouldSetCorrectString() { 
            KomodoClaims claim1 = new KomodoClaims();
            claim1.Description = "Car on fire.";

            string expected1 = "Car on fire.";
            string actual1 = claim1.Description;

            Assert.AreEqual(expected1, actual1);
        }
    }
}
