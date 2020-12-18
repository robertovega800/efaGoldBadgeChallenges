using KomodoBadge_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoBadge_UnitTests
{
    [TestClass]
    public class KomodoBadgeTests
    {
        [TestMethod]
        public void SetBadgId_ShouldSetCorrectInt()
        {
            KomodoBadge badge = new KomodoBadge();

            badge.BadgeID = int.Parse("01");

            int expected = 1;
            int actual = badge.BadgeID;

            Assert.AreEqual(expected, actual);
        }
    }
}
