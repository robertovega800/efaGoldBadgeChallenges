using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_Repo
{
    public class KomodoBadge
    {
        public int BadgeID { get; set; }
        public string DoorsAvailable { get; set; }

        public KomodoBadge() { }
        public KomodoBadge(int badgeID, string doorsAvailable)
        {
            BadgeID = badgeID;
            DoorsAvailable = doorsAvailable;
        }
    }
}
