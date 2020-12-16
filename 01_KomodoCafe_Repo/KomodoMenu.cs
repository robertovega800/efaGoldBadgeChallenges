using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Repo
{
    public enum FoodType
    {
        Appetizer = 1,
        Salad,
        Entree,
        Dessert
    }

    public class KomodoMenu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string ListOfIngredients { get; set; }
        public double MealPrice { get; set; }
        public FoodType TypeOfFood { get; set; }

        public KomodoMenu() { }

        public KomodoMenu(int mealNumber, string mealName, string mealDescription, string listOfIngredients, double mealPrice, FoodType food)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            ListOfIngredients = listOfIngredients;
            MealPrice = mealPrice;
            TypeOfFood = food;
        }

       
    }
}
