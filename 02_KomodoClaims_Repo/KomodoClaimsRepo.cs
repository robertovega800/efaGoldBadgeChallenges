using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaims_Repo
{
    class KomodoClaimsRepo
    {
        private List<KomodoClaims> _listOfClaims = new List<KomodoClaims>();

        // Create
        public void AddMealToList(KomodoClaims claim)
        {
            _listOfClaims.Add(claim);
        }

        // Read
        public List<KomodoClaims> GetClaimsList()
        {
            return _listOfClaims;
        }

        // Update
        public bool UpdateExistingClaim(int originalClaimID, KomodoClaims newClaim)
        {
            KomodoClaims oldClaim = GetClaimByID(originalClaimID);

            if(oldClaim != null)
            {
                oldClaim.ClaimID = newClaim.ClaimID;
                oldClaim.TypeOfClaim = newClaim.TypeOfClaim;
                oldClaim.Description = newClaim.Description;
                oldClaim.ClaimAmount = newClaim.ClaimAmount;
                oldClaim.DateOfIncident = newClaim.DateOfIncident;
                oldClaim.DateOfClaim = newClaim.DateOfClaim;
                oldClaim.IsValid = newClaim.IsValid;
                return true;
            }
            else
            {
                return false;
            }
        }
        
        // Delete
        public bool RemoveClaimFromList(int claimID)
        {
            KomodoClaims claim = GetClaimByID(claimID);

            if(claim == null)
            {
                return false;
            }

            int initialCount = _listOfClaims.Count;
            _listOfClaims.Remove(claim);

            if(initialCount > _listOfClaims.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public KomodoClaims GetClaimByID(int claimID)
        {
            foreach(KomodoClaims claim in _listOfClaims)
            {
                if(claim.ClaimID == claimID)
                {
                    return claim;
                }
            }

            return null;
        }
    }
}
