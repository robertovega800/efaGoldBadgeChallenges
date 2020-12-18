using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_Repo
{
    public class KomodoBadgeRepo
    {
    private Dictionary<int, KomodoBadge> _dictionaryBadges = new Dictionary<int, KomodoBadge>();
        private int Count;

        // Create
        public void AddToDatabase(KomodoBadge badge)
        {
            Count++;
            _dictionaryBadges.Add(Count, badge);
        }
        // Read
        public Dictionary<int, KomodoBadge> GetBadgeDictionary()
        {
            return _dictionaryBadges;
        }

        // Update
        public bool UpdateExistingBadge(int originalBadgeID, KomodoBadge newBadge)
        {
            KomodoBadge oldBadge = GetBadgeByDictKey(originalBadgeID);

            if (oldBadge != null)
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.DoorsAvailable = newBadge.DoorsAvailable;
                    return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        /*public bool RemoveBadge(KomodoBadge)
        {

        }*/


        public KomodoBadge GetBadgeByDictKey(int dictKey)
        {
            foreach (KeyValuePair<int,KomodoBadge> pair in _dictionaryBadges)
            {
                if (pair.Key == dictKey)
                {
                    return pair.Value;
                }
            }

            return null;
        }

        public bool RemoveDoor(int dictKey, string doorName)
        {
            KomodoBadge badge = GetBadgeByDictKey(dictKey);
            if (badge == null)
            {
                return false;
            }
            foreach (var door in badge.DoorsAvailable)
            {
                if (door == doorName)
                {
                    badge.DoorsAvailable.Remove(door);
                    return true;
                }
            }
            return false;
        }

        public bool AddDoor(int dictKey, string doorName)
        {
            KomodoBadge badge = GetBadgeByDictKey(dictKey);
            if (badge != null)
            {
                badge.DoorsAvailable.Add(doorName);
                return true;
            }
          
            return false;
        }
    }
}

