using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaims_Repo
{
   public class KomodoClaimsRepo
    {
        private Queue<KomodoClaims> queueOfClaims = new Queue<KomodoClaims>();
        private int _claimIdCounter = 0;

        // Create
        public void AddClaimToQueue(KomodoClaims claim)
        {
           
            _claimIdCounter++;
            claim.ClaimID = _claimIdCounter;
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
        public bool RemoveClaimFromQueue(KomodoClaims _claim)
        {
            if (queueOfClaims.Count>0)
            {
                queueOfClaims.Dequeue();
                return true;

            }
            return false;
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

        public bool CalculateIsValid(DateTime dateOfInc, DateTime dateOfClaim)
        {
            var ans = dateOfInc - dateOfClaim;
            var comparison = TimeSpan.FromDays(ans.Days);
            Console.WriteLine(ans);
            if (comparison.Days<=30 && comparison.Days>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public KomodoClaims GetNextClaimInQueue()
        {
            if (queueOfClaims.Count > 0)
            {
                KomodoClaims nextClaim = queueOfClaims.Peek();
                return nextClaim;
            }
            return null;
        }
    }
}
