using _02_KomodoClaims_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_KomodoClaims_UnitTesting
{
    [TestClass]
    public class KomodoClaimsRepoTests
    {
        private KomodoClaimsRepo _repo;
        private KomodoClaims _claim;

            [TestInitialize]
            public void Arrange()
            {
                _repo = new KomodoClaimsRepo();
                _claim = new KomodoClaims(ClaimType.Car, "Car on fire.", "$400.00", new DateTime(2020, 4, 01), new DateTime(2020, 4, 02), true);

                _repo.AddClaimToQueue(_claim);
            }
        //Add Method
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {

            // Arrange
            KomodoClaims claim = new KomodoClaims();
            claim.ClaimID = int.Parse("01");
            KomodoClaimsRepo repo = new KomodoClaimsRepo();

            // Act
            repo.AddClaimToQueue(claim);
            KomodoClaims claimFromQueue = repo.GetClaimByID(01);

            // Assert
            Assert.IsNotNull(claimFromQueue);
        }

        // Update Method
        [TestMethod]
        public void UpdateExistingMethod_ShouldReturnTrue()
        {
            // Arrange
            //TestInitialize
            KomodoClaims newClaim = new KomodoClaims(ClaimType.Car, "Car engine flooded with water.", "$567.00", new DateTime(2020, 4, 01), new DateTime(2020, 4, 02), true);

            // Act
            bool updateResult = _repo.UpdateExistingClaim(01, newClaim);

            // Assert
            Assert.IsTrue(updateResult);
        }

        // Dequeue method
        [TestMethod]
        public void DequeueClaim_ShouldReturnTrue()
        {
            bool dequeueResult = _repo.RemoveClaimFromQueue(_claim);

            //Assert
            Assert.IsTrue(dequeueResult);
        }

    }
}
