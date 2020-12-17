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
        //need to make a private readonly reference to the KomodoClaimsRepo
        private readonly KomodoClaimsRepo _claimsRepo = new KomodoClaimsRepo();

        public void Run()
        {
            SeedClaimsQueue();
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
                        DisplayAllClaims();
                        break;
                    case "2":
                        // Take care of next claim
                        break;
                    case "3":
                        CreateNewClaim();
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
        private void DisplayAllClaims()
        {
            Console.Clear();
            foreach (var element in _claimsRepo.GetClaimsQueue())
            {
                DisplayClaimInfo(element);
            }
        }

        //helper method
        private void DisplayClaimInfo(KomodoClaims claim)
        {
            Console.WriteLine($"ClaimId: {claim.ClaimID}\n" +
                $"TypeOfClaim: {claim.TypeOfClaim}\n" +
                $"ClaimDescription: {claim.Description}\n" +
                $"Claim Amount: {claim.ClaimAmount}\n" +
                $"DateOfInident:{claim.DateOfIncident}\n" +
                $"DateOfCliam:{claim.DateOfClaim}\n" +
                $"IsValid: {claim.IsValid}\n");
            Console.WriteLine("************************************");
        }

        // Take care of next claim
        private void ViewNextClaim()
        {
            //clear console
            //create variabe of type KomodoClaims 
            //set it = to _claimsRepo.(methodToPeek)

            //call displayClaimInfo(variable of type komodoClaims)
        }

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

            Console.WriteLine("Enter the claim amount ($1,000, $650, $125):");
            newClaim.ClaimAmount = Console.ReadLine();


            var IncidentDate = GetDateTime("Incident Data");
            newClaim.DateOfIncident = IncidentDate;


            var claimDate = GetDateTime("Claim Data");
            newClaim.DateOfClaim = claimDate;

            newClaim.IsValid = _claimsRepo.CalculateIsValid(newClaim.DateOfIncident, newClaim.DateOfClaim);

            if (newClaim.IsValid)
            {
                Console.WriteLine("Valid Cliam");
            }
            else
            {
                Console.WriteLine("InValid Calim");
            }

            _claimsRepo.AddClaimlToQueue(newClaim);


        }

        private DateTime GetDateTime(string OpeningMessage)
        {
            Console.WriteLine($"****************** {OpeningMessage} *************************");
            //ask question
           
            Console.WriteLine("Please input the year");
            int inputYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input the month");
            int inputMonth = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input the day");
            int inputDay = int.Parse(Console.ReadLine());

            DateTime date = new DateTime(inputYear, inputMonth, inputDay);

            return date;

        }

        private void SeedClaimsQueue()
        {
            KomodoClaims claim1 = new KomodoClaims(ClaimType.Car, "Car accident on 465.", "$400.00",new DateTime(2020,12,12),new DateTime(2020,12,14), true);
            KomodoClaims claim2 = new KomodoClaims(ClaimType.Home, "Home Invasion.", "$400.00",new DateTime(2020,12,12),new DateTime(2021,12,14), false);
            KomodoClaims claim3 = new KomodoClaims(ClaimType.Theft, "...IDK?", "$400.00",new DateTime(2020,12,12),new DateTime(2020,12,18), true);

            _claimsRepo.AddClaimlToQueue(claim1);
            _claimsRepo.AddClaimlToQueue(claim2);
            _claimsRepo.AddClaimlToQueue(claim3);

        }
    }
}
