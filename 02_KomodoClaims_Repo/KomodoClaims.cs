using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaims_Repo
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }

    public class KomodoClaims
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public int ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public KomodoClaims() { }

        public KomodoClaims(int claimID, ClaimType typeClaim, string description, int claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid )
        {
            ClaimID = claimID;
            TypeOfClaim = typeClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;

        }
    }
}
