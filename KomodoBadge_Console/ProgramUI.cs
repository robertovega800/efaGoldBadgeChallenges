using KomodoBadge_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_Console
{
    class ProgramUI
    {
        private readonly KomodoBadgeRepo _badgeRepo = new KomodoBadgeRepo();
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
                        DisplayAllBadges();
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
        private void DisplayAllBadges()
        {
            Console.Clear();

            foreach (KeyValuePair<int, KomodoBadge> pair in _badgeRepo.GetBadgeDictionary())
            {
                
                DisplayBadgeInfo(pair.Value);
            }

            
        }

        //Helper Method

        private void DisplayBadgeInfo(KomodoBadge badge)
        {
            Console.WriteLine($"Badge ID: {badge.BadgeID}\n" +
                    $"Doors Available: {badge.DoorsAvailable}");
            Console.WriteLine("************************************");
        }

        // Seed Method
        private void SeedBadges()
        {
            KomodoBadge badge1 = new KomodoBadge(12345,new List<string> { "A7" });
            KomodoBadge badge2 = new KomodoBadge(22345,new List<string>{ "A1", "A4", "B1", "B2" } );
            KomodoBadge badge3 = new KomodoBadge(32345,new List<string> { "A4", "A5" });

            _badgeRepo.AddToDatabase(badge1);
            _badgeRepo.AddToDatabase(badge2);
            _badgeRepo.AddToDatabase(badge3);
        }
    }
}
