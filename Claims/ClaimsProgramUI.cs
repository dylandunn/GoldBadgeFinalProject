using ClaimsPOCO;
using ClaimsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public class ClaimsProgramUI
    {
        private ClaimRepos claimRepos = new ClaimRepos();
        private Queue<ClaimsItems> claimsQueue = new Queue<ClaimsItems>();
        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool appRuning = true;
            while (appRuning)
            {
                Console.WriteLine("\n\n\n\n Welcome to the Komodo Claims Department App. Select an option \n\n\n\n " +
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit Application");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        CreateNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Thanks For Using The Komodo Claims Department App!");
                        Console.ReadKey();
                        appRuning = false;
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private void ViewAllClaims()
        {
            Console.Clear();
            List<ClaimsItems> listOfClaims = claimRepos.GetClaimsItemsList();
            foreach(ClaimsItems claimsItems in listOfClaims)
            {
                Console.WriteLine($"Claim ID : {claimsItems.ClaimID}\n" +
                    $"Claim Type: {claimsItems.TypeofClaim}\n" +
                    $"Description: {claimsItems.Description}\n" +
                    $"Claim Amount: {claimsItems.ClaimAmount}\n" +
                    $"Date of Incident: {claimsItems.DateOfIncident.Date.ToString("d")}\n" +
                    $"Date of Claim: {claimsItems.DateOfClaim.Date.ToString("d")}\n" +
                    $"Is a valid claim: {claimsItems.IsValid}\n" +
                    $"------------------------------------------");
            }
        }
        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            ClaimsItems claimsItems = claimRepos.PeekClaimsItemFromQueue();
            Console.WriteLine($"Claim Id: {claimsItems.ClaimID}\n" +
                $"Type of claim: {claimsItems.TypeofClaim}\n" +
                $"Description: {claimsItems.Description}\n" +
                $"Claim Amount: {claimsItems.ClaimAmount}\n" +
                $"Date of incident: {claimsItems.DateOfIncident}\n" +
                $"Date claim was filed: {claimsItems.DateOfClaim}\n" +
                $"Valid claim: {claimsItems.IsValid}");

            Console.WriteLine($"Do you want to deal with this claim now?(y/n):");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                Console.WriteLine("Claim has been resolved!");
                claimRepos.RemoveClaimsItemFromList();
                claimsQueue.Dequeue();
            }
            else if (input == "n")
            {
                Console.WriteLine("Returning to main menu");
            }
            else { Console.WriteLine("Enter y or n to deal with this claim");}

        }
        private void CreateNewClaim()
        {
            Console.Clear();
            ClaimsItems newClaimsItems = new ClaimsItems();

            Console.WriteLine("Enter Claim ID:");
            string idString = Console.ReadLine();
            int idInt;
            int.TryParse(idString, out idInt);
            if (!int.TryParse(idString, out idInt))
            {
                Console.WriteLine("Please enter a valid Claim ID");
                Console.ReadLine();
            }
            newClaimsItems.ClaimID = idInt;

            Console.WriteLine("Enter Claim Type: (Enter 1 for Car, 2 for Home, or 3 for theft):");
            string typeClaim = Console.ReadLine();
            int typeAsInt = int.Parse(typeClaim);
            newClaimsItems.TypeofClaim = (ClaimType)typeAsInt;

            Console.WriteLine("Enter a description of the claim:");
            newClaimsItems.Description = Console.ReadLine();

            Console.WriteLine("Enter the claim amount:");
            string amountString = Console.ReadLine();
            decimal amountDec;
            decimal.TryParse(amountString, out amountDec);
            if (!decimal.TryParse(amountString, out amountDec))
            {
                Console.WriteLine("Please enter a valid claim amount");
                Console.ReadLine();
            }
           

            Console.WriteLine("Enter the date of incident (mm, dd, yyyy):");
            string dateToParse = Console.ReadLine();
            DateTime parsedDate;
            DateTime.TryParse(dateToParse, out parsedDate);
            if (!DateTime.TryParse(dateToParse, out parsedDate))
            {
                Console.WriteLine("Please enter a valid Date(mm, dd, yyyy");
                Console.ReadLine();
            }
            newClaimsItems.DateOfIncident = parsedDate;


            Console.WriteLine("Enter the date when claim was filed:");
            string dateParse = Console.ReadLine();
            DateTime parseDate;
            DateTime.TryParse(dateParse, out parseDate);
            if (!DateTime.TryParse(dateParse, out parseDate))
            {
                Console.WriteLine("Please enter a valid file date for this claim (mm,dd,yyyy)");
                Console.ReadLine();
            }
            newClaimsItems.DateOfClaim = parseDate;
            
            
            if ((parseDate.Date - parsedDate.Date).Days > 30)
            {
                Console.WriteLine("This claim is not valid");
                newClaimsItems.IsValid = false;
            }
            else if ((parseDate.Date - parsedDate.Date).Days < 30)
            {
                Console.WriteLine("This is a valid claim!");
                newClaimsItems.IsValid = true;
            }
            else Console.WriteLine("Validatiy could not be calculatd. Please try again.");

            claimRepos.AddClaimToQueueAndList(newClaimsItems);

            Console.WriteLine("Your claim has been added!");
        }
    }
}
