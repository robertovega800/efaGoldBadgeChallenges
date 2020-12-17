using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_Console
{
    class ProgramUI
    {
        public void Run()
        {
            SeedBadges();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Hello Security Admin, what would you like to do?\n" +
                "\n1. Add a badge\n" +
                "2. Edit a badge\n" +
                "3. List all badges\n" +
                "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //Add a badge
                        CreateABadge();
                        break;
                    case "2":
                        //Edit a badge
                        EditABadge();
                        break;
                    case "3":
                        // List all badges
                        break;
                    case "4":
                        //exit
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                }
            }
        }

        // Add a badge
        private void CreateABadge()
        {

        }

        // Edit a badge
        private void EditABadge()
        {

        }

        // List all badges
        private void ListAllBadges()
        {

        }

        // Seed Method
        private void SeedBadges()
        {

        }
    }
}
