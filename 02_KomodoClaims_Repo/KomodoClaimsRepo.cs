using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaims_Repo
{
    class KomodoClaimsRepo
    {
        private Queue<KomodoClaims> queueOfClaims = new Queue<KomodoClaims>();
        private int _claimIdCounter = 0;

        // Create
        public void AddClaimlToQueue(KomodoClaims claim)
        {
            claim.ClaimID = _claimIdCounter + 1;
            queueOfClaims.Enqueue(claim);
            _claimIdCounter++;
            queueOfClaims.Enqueue(claim);
        }

        // Read
        public Queue<KomodoClaims> GetClaimsQueue()
        {
            return queueOfClaims;
        }

        // Update
        public bool UpdateExistingClaim(int originalClaimID, KomodoClaims newClaim)
        {
            KomodoClaims oldClaim = GetClaimByID(originalClaimID);

            if(oldClaim != null)
            {
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
        public bool RemoveClaimFromQueue(int claimID)
        {
            KomodoClaims claim = GetClaimByID(claimID);

            if(claim == null)
            {
                return false;
            }

            int initialCount = queueOfClaims.Count;
            queueOfClaims.Dequeue();

            if(initialCount > queueOfClaims.Count)
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
            foreach(KomodoClaims claim in queueOfClaims)
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
