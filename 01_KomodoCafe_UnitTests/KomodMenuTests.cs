using _01_KomodoCafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_KomodoCafe_UnitTests
{
    [TestClass]
    public class KomodMenuTests
    {

        [TestMethod]
        public void SetMealName_ShouldSetCorrectString()
        {
            KomodoMenu meal = new KomodoMenu();

            meal.MealName = "Avocado Rolls";

            string expected = "Avocado Rolls";
            string actual = meal.MealName;

            Assert.AreEqual(expected, actual);

            meal.MealNumber = 9;

            int expected1 = 9;
            int actual1 = meal.MealNumber;

            Assert.AreEqual(expected1, actual1);
        }
    }
}
