using _02_KomodoClaims_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaims_Console
{
    class ProgramUI
    {
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                "1. See all claims\n" +
                "2. Take care of next claim\n" +
                "3. Enter a new Claim\n" +
                "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // See all claims
                        break;
                    case "2":
                        // Take care of next claim
                        break;
                    case "3":
                        // Enter a new claim
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                }
                Console.WriteLine("\nPlease press any KEY to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // See all claims

        // Take care of next claim

        // Enter a new claim
        private void CreateNewClaim()
        {
            Console.Clear();
            KomodoClaims newClaim = new KomodoClaims();

            Console.WriteLine("Enter the number for the claim type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            int claimAsInt = int.Parse(Console.ReadLine());
            newClaim.TypeOfClaim = (ClaimType)claimAsInt;

            Console.WriteLine("Enter the claim description:");
            newClaim.Description = Console.ReadLine();
        }
    }
}
