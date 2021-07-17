using BadgesPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesRepo
{
    public class BadgesRepos
    {
        private Dictionary<int, Badge> badgesDictionary = new Dictionary<int, Badge>();
        private int _idCounter = default;
        
        public bool CreateBadge(Badge badgesItems)
        {
            if (badgesItems == null)
            {
                return false;
            }
            badgesItems.BadgeID = ++_idCounter;
            badgesDictionary.Add(badgesItems.BadgeID,badgesItems);
            return true;
        }
        
        public Dictionary<int, Badge> GetKeyValuePairs()
        {
            return badgesDictionary;
        }
        
        
        public bool UpdateBadge(int originalID, Badge newBadge)
        {
            Badge oldBadge = GetBadgeByKey(originalID);
            if (oldBadge != null)
            {
                oldBadge.Doors = newBadge.Doors;
                return true;
            }
            else { return false; }
            
        }
       
        public bool RemoveDoorFromBadge(int userKeyInput, string doorName)
        {
            Badge badge = GetBadgeByKey(userKeyInput);
           
            if (badge == null)
            {
                return false;
            }

            foreach (var door in badge.Doors)
            {
                if (door==doorName)
                {
                    badge.Doors.Remove(door);
                    return true;
                }
            }
            return false;
        }


        
        public Badge GetBadgeByKey(int userKeyInput)
        {
            foreach (var item in badgesDictionary)
            {
                if (item.Key==userKeyInput)
                {
                    return item.Value;
                }
            }

            return null;
        }
    }
   
}
