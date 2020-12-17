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
                "\n1. See all claims\n" +
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
                        ViewNextClaim();
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
            Console.Clear();

            //Komodo Claims claim = 

            //create variabe of type KomodoClaims

            KomodoClaims claim = _claimsRepo.GetNextClaimInQueue();
            Console.WriteLine($"Next claim in line is:\n");
            DisplayClaimInfo(claim);

            Console.WriteLine("*****************************************");

            Console.WriteLine("\nDo you wish to deal with this claim now?\n" +
                "1. Yes\n" +
                "2. No");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _claimsRepo.RemoveClaimFromQueue();
                    break;
                case "2":
                    Console.Clear();
                    Menu();
                    break;
            }
                

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

            _claimsRepo.AddClaimToQueue(newClaim);


        }

        private DateTime GetDateTime(string Message)
        {
            Console.WriteLine($"****************** {Message} *************************");
            //ask question
           
            Console.WriteLine("Please input the year(1994, 2003, 1998)");
            int inputYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input the month(6, 11, 12)");
            int inputMonth = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input the day(01, 13, 27)");
            int inputDay = int.Parse(Console.ReadLine());

            DateTime date = new DateTime(inputYear, inputMonth, inputDay);

            return date;

        }

        private void SeedClaimsQueue()
        {
            KomodoClaims claim1 = new KomodoClaims(ClaimType.Car, "Car accident on 465.", "$400.00",new DateTime(2018,4,25),new DateTime(2018,4,27), true);
            KomodoClaims claim2 = new KomodoClaims(ClaimType.Home, "House fire in kitchen.", "$4000.00",new DateTime(2018,4,11),new DateTime(2018,4,12), true);
            KomodoClaims claim3 = new KomodoClaims(ClaimType.Theft, "Stolen pancakes.", "$4.00",new DateTime(2018,4,27),new DateTime(2018,6,01), false);

            _claimsRepo.AddClaimToQueue(claim1);
            _claimsRepo.AddClaimToQueue(claim2);
            _claimsRepo.AddClaimToQueue(claim3);

        }
    }
}
