using _01_KomodoCafe_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Console
{
    class ProgramUI
    {
    private KomodoMenuRepo _mealRepo = new KomodoMenuRepo();
        public void Run()
        {
            SeedMealList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                //Display options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create a new meal for the menu\n" +
                    "2. View all meals on the menu\n" +
                    "3. View existing meal by 'Meal Number'\n" +
                    "4. Update an existing meal\n" +
                    "5. Delete an existing meal\n" +
                    "6. Exit");

                //Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input
                switch (input)
                {
                    case "1":
                        //Create new meal
                        CreateNewMeal();
                        break;
                    case "2":
                        //View all meals
                        DisplayAllMeals();
                        break;
                    case "3":
                        //view meal by meal number
                        DisplayMealByMealNumber();
                        break;
                    case "4":
                        //Update existing meal
                        UpdateExistingMeal();
                        break;
                    case "5":
                        //Delete a meal
                        DeleteExistingMeal();
                        break;
                    case "6":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number...");
                        break;
                }
                Console.WriteLine("\nPlease press any KEY to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Create new KomodoMeal
        private void CreateNewMeal()
        {
            Console.Clear();
            KomodoMenu newMeal = new KomodoMenu();

            //Meal Number
            Console.WriteLine("Enter the meal number for the meal:");
            newMeal.MealNumber = int.Parse(Console.ReadLine());

            //Meal Name
            Console.WriteLine("Enter the name for the meal:");
            newMeal.MealName = Console.ReadLine();

            //Meal Description
            Console.WriteLine("Enter the description for the meal:");
            newMeal.MealDescription = Console.ReadLine();

            //List of Ingredients
            Console.WriteLine("Enter the list of ingredients for the meal:");
            newMeal.ListOfIngredients = Console.ReadLine();

            //Meal Price
            Console.WriteLine("Enter the price for the meal (9.99, 16.99, 19.99)");
            newMeal.MealPrice = double.Parse(Console.ReadLine());

            //Meal type
            Console.WriteLine("Enter the Meal Type number:\n" +
                "1. Appetizer\n" +
                "2. Salad\n" +
                "3. Entree\n" +
                "4. Dessert");

            int foodAsInt = int.Parse(Console.ReadLine());
            newMeal.TypeOfFood = (FoodType)foodAsInt;

            _mealRepo.AddMealToList(newMeal);
        }

        //View current saved KomodoMeal
        private void DisplayAllMeals()
        {
            Console.Clear();

            List<KomodoMenu> listOfMeals = _mealRepo.GetMealList();

            foreach(KomodoMenu meal in listOfMeals)
            {
                Console.WriteLine($"Meal ID Number: {meal.MealNumber}\n" +
                    $"Name: {meal.MealName}\n" +
                    $"Description: {meal.MealDescription}");
            }
        }

        //View existing meal by Meal Number
        private void DisplayMealByMealNumber()
        {
            Console.Clear();
            //Prompt the user to give me an ID number
            Console.WriteLine("Enter the Meal Number for the meal that you'd like to see:");
            int mealNumber = int.Parse(Console.ReadLine());

            //Find the meal by that ID number
            KomodoMenu meal = _mealRepo.GetMealByMealNumber(mealNumber);

            //Display said meal if it isn't null
            if(meal != null)
            {
                Console.WriteLine($"Meal ID Number: {meal.MealNumber}\n" +
                    $"Name: {meal.MealName}\n" +
                    $"Description: {meal.MealDescription}\n" +
                    $"Ingredients: {meal.ListOfIngredients}\n" +
                    $"Price: {meal.MealPrice}\n" +
                    $"Type of meal: {meal.TypeOfFood}");
            }
            else
            {
                Console.WriteLine("\nNo meal by that ID Number...");
            }
        }

        //Update existing meal
        private void UpdateExistingMeal()
        {
            //Display all meals
            DisplayAllMeals();

            //Ask for the Meal Number of meal to update
            Console.WriteLine("\nEnter the 'Meal Number' of the meal you would like to update:");

            //Get that meal
            int oldMealNumber = int.Parse(Console.ReadLine());

            //build a new object
            KomodoMenu newMeal = new KomodoMenu();

            //Meal Number
            Console.WriteLine("Enter the updated meal number for the meal:");
            newMeal.MealNumber = int.Parse(Console.ReadLine());

            //Meal Name
            Console.WriteLine("Enter the updated name for the meal:");
            newMeal.MealName = Console.ReadLine();

            //Meal Description
            Console.WriteLine("Enter the updated description for the meal:");
            newMeal.MealDescription = Console.ReadLine();

            //List of Ingredients
            Console.WriteLine("Enter the updated list of ingredients for the meal:");
            newMeal.ListOfIngredients = Console.ReadLine();

            //Meal Price
            Console.WriteLine("Enter the updated price for the meal (9.99, 16.99, 19.99)");
            newMeal.MealPrice = double.Parse(Console.ReadLine());

            //Meal type
            Console.WriteLine("Enter the Meal Type number:\n" +
                "1. Appetizer\n" +
                "2. Salad\n" +
                "3. Entree\n" +
                "4. Dessert");

            int foodAsInt = int.Parse(Console.ReadLine());
            newMeal.TypeOfFood = (FoodType)foodAsInt;

            //verify the update worked
            bool wasUpdated = _mealRepo.UpdateExistingMeal(oldMealNumber, newMeal);

            if (wasUpdated)
            {
                Console.WriteLine("Meal was successfully updated!");
            }
            else
            {
                Console.WriteLine("Meal was not able to be updated...");
            }

        }

        //Delete existing meal
        private void DeleteExistingMeal()
        {
            DisplayAllMeals();

            //Get the meal they want to delete
            Console.WriteLine("\nEnter the 'Meal Number' of the meal you would like to remove:");

            int input = int.Parse(Console.ReadLine());

            //call the delete method
            bool wasDeleted = _mealRepo.RemoveMealFromList(input);

            //if the meal was deleted say so, otherwise state it could not be deleted
            if (wasDeleted)
            {
                Console.WriteLine("The meal was succesfully deleted.");
            }
            else
            {
                Console.WriteLine("The meal could not be deleted...");
            }
        }

        //Seed Method
        private void SeedMealList()
        {
            KomodoMenu texMexEggrolls = new KomodoMenu(01, "Tex Mex Eggrolls", "Eggrolls stuffed with spicy chicken mix. Served with Avocado Cream and Pico de Gallo", "Spicy Chicken, corn, black beans, peppers, onions and melted cheese.", 12.50, FoodType.Appetizer);
            KomodoMenu buffaloBlasts = new KomodoMenu(02, "Buffalo Blasts", "Deep-fried wontons stuffed with spicy buffalo chicken. Served with a side of Blu Cheese, Buffalo sauce, and celery sticks", "Chicken, cheese, our Spicy Buffalo Sauce all stuffed in a wonton Spiced Wrapper and fried until crisp.",14.50, FoodType.Appetizer );
            KomodoMenu impossibleTacoSalad = new KomodoMenu(03, "Impossible Taco Salad", "Our take on a tex-mex taco salad made with savory Impossible meat! Tossed in our vinaigrette and crispy tortilla strips.", "Plant-based seasoned taco meat, mixed greens, avocado, corn, black beans, tomato, onion, cilantro and cheese.", 16.95, FoodType.Salad);
            KomodoMenu chickenParmesanPizzaStyle = new KomodoMenu(04, "Chicken Parmesan 'Pizza Style'", "A twist on a classic, Chicken Parmesan served in the shape of a pizza!", "Chopped chicken breast coated with breadcrumbs, covered with marinara sauce, and lots of melted cheese. Topped with angel hair pasta in an alfredo cream sauce.", 16.95, FoodType.Entree);
            KomodoMenu gumbo = new KomodoMenu(05, "Shrimp and Chicken Gumbo", "Our delicous shrimp and chicken gumbo served in a spicy cajun broth with your choice of brown or white rice!", "Shrimp, chicken, andouille sausage, tomatoes, peppers, onions, and garlic simmered in a spicy cajun style broth with cream.", 19.50, FoodType.Entree);
            KomodoMenu originalCheesecake = new KomodoMenu(06, "Original Cheesecake", "The one that started it all! Served with a side of whipped cream.", "Our famous creamy cheesecake with a graham cracker crust and a sour cream glaze.", 7.95, FoodType.Dessert);
            KomodoMenu celebrationCheesecake = new KomodoMenu(07, "Celebration Cheesecake", "Birthday-cake flavored cheesecake!", "Layers of vanilla cake, cheesecake, strawberry, chocolate and vanilla mousse with cream cheese frosting.", 8.95, FoodType.Dessert);

            _mealRepo.AddMealToList(texMexEggrolls);
            _mealRepo.AddMealToList(buffaloBlasts);
            _mealRepo.AddMealToList(impossibleTacoSalad);
            _mealRepo.AddMealToList(chickenParmesanPizzaStyle);
            _mealRepo.AddMealToList(gumbo);
            _mealRepo.AddMealToList(originalCheesecake);
            _mealRepo.AddMealToList(celebrationCheesecake);
        }
    }
}
