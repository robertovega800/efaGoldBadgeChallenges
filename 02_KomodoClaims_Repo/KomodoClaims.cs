﻿using System;
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
        public string ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public KomodoClaims() { }

        public KomodoClaims(ClaimType typeClaim, string description, string claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid )
        {
            TypeOfClaim = typeClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;

        }
    }
}
