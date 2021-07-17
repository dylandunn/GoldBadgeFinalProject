using ClaimsPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsRepo
{
    public class ClaimRepos
    {
        Queue<ClaimsItems>  queueOfClaimsItems = new Queue<ClaimsItems>();
        List<ClaimsItems> listOfClaimItems = new List<ClaimsItems>();

        public bool AddClaimToQueueAndList(ClaimsItems claimItem)
        {
            if(claimItem is null)
            {
                return false;
            }
            listOfClaimItems.Add(claimItem);
            queueOfClaimsItems.Enqueue(claimItem);
            return true;
        }
        public List<ClaimsItems> GetClaimsItemsList()
        {
            return listOfClaimItems;
        }
        public Queue<ClaimsItems> GetClaimsItemsQueue()
        {
            return queueOfClaimsItems;
        }
        public void RemoveClaimsItemFromList()
        {
            ClaimsItems claimsItems = queueOfClaimsItems.Peek();
            listOfClaimItems.Remove(claimsItems);
            
        }
        
        public ClaimsItems PeekClaimsItemFromQueue()
        {
            return queueOfClaimsItems.Peek();
            
        }
    }
}
