using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Repo
{
   public class KomodoMenuRepo
    {
        private List<KomodoMenu> _listOfMeals = new List<KomodoMenu>();

        //Create
        public void AddMealToList(KomodoMenu meal)
        {
            _listOfMeals.Add(meal);
        }

        //Read
        public List<KomodoMenu> GetMealList()
        {
            return _listOfMeals;
        }

        //Update
        public bool UpdateExistingMeal(int originalMealNumber, KomodoMenu newMeal)
        {
            //Find the meal
            KomodoMenu oldMeal = GetMealByMealNumber(originalMealNumber);

            //Update the meal
            if(oldMeal != null)
            {
                oldMeal.MealNumber = newMeal.MealNumber;
                oldMeal.MealName = newMeal.MealName;
                oldMeal.MealDescription = newMeal.MealDescription;
                oldMeal.ListOfIngredients = newMeal.ListOfIngredients;
                oldMeal.MealPrice = newMeal.MealPrice;
                oldMeal.TypeOfFood = newMeal.TypeOfFood;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveMealFromList(int mealNumber)
        {
            KomodoMenu meal = GetMealByMealNumber(mealNumber);

            if(meal == null)
            {
                return false;
            }

            int initialCount = _listOfMeals.Count;
            _listOfMeals.Remove(meal);

            if(initialCount > _listOfMeals.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public KomodoMenu GetMealByMealNumber(int mealNumber)
        {
            foreach(KomodoMenu meal in _listOfMeals)
            {
                if(meal.MealNumber == mealNumber)
                {
                    return meal;
                }
            }

            return null;
        }
    }
}
