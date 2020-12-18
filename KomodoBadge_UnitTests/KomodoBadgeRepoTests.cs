using KomodoBadge_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoBadge_UnitTests
{
    [TestClass]
    public class KomodoBadgeRepoTests
    {
        [TestMethod]
        public void AddToDictionary_ShouldNotGetNull()
        {
            KomodoBadge badge = new KomodoBadge();
            badge.BadgeID = int.Parse("01");
            KomodoBadgeRepo repo = new KomodoBadgeRepo();

            repo.AddToDatabase(badge);
            KomodoBadge badgeFromDatabase = repo.GetBadgeByDictKey(01);

            Assert.IsNotNull(badgeFromDatabase);
        }
    }
}
