using _01_KomodoCafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_KomodoCafe_UnitTests
{
    [TestClass]
    public class KomodoMenuRepo_Tests
    {
        private KomodoMenuRepo _repo;
        private KomodoMenu _meal;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new KomodoMenuRepo();
            _meal = new KomodoMenu(01, "Tex Mex Eggrolls", "Eggrolls stuffed with spicy chicken mix. Served with Avocado Cream and Pico de Gallo", "Spicy Chicken, corn, black beans, peppers, onions and melted cheese.", 12.50, FoodType.Appetizer);

            _repo.AddMealToList(_meal);
        }

        //Add Method
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            //Arrange --> Setting up the playing field
            KomodoMenu meal = new KomodoMenu();
            meal.MealNumber = 9;
            KomodoMenuRepo repository = new KomodoMenuRepo();

            //Act --> Get/run the code we want to test
            repository.AddMealToList(meal);
            KomodoMenu mealFromDirectory = repository.GetMealByMealNumber(9);

            //Assert --> Use the assert class to verify the expected outcome
            Assert.IsNotNull(mealFromDirectory);
        }

        //Update
        [TestMethod]
        public void UpdateExistingMeal_ShouldReturnTrue()
        {
            //Arrange
            //TestInitialize
            KomodoMenu newMeal = new KomodoMenu(01, "Tex Mex Eggrolls", "Eggrolls stuffed with spicy chicken mix. Served with Avocado Cream and Pico de Gallo", "Spicy Chicken, corn, black beans, peppers, onions and melted cheese.", 12.49, FoodType.Appetizer);

            //Act
            bool updateResult = _repo.UpdateExistingMeal(01, newMeal);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow(01, true)]
        [DataRow(07, false)]
        public void UpdateExistingContent_ShouldMatchGivenBool(int originalMealNumber, bool shouldUpdate)
        {
            //Arrange
            //TestInitialize
            KomodoMenu newMeal = new KomodoMenu(01, "Tex Mex Eggrolls", "Eggrolls stuffed with spicy chicken mix. Served with Avocado Cream and Pico de Gallo", "Spicy Chicken, corn, black beans, peppers, onions and melted cheese.", 12.49, FoodType.Appetizer);

            //Act
            bool updateResult = _repo.UpdateExistingMeal(originalMealNumber, newMeal);

            //Assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }
        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            //Arrange

            //Act
            bool deleteResult = _repo.RemoveMealFromList(_meal.MealNumber);

            //Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
