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
        public List<string> DoorsAvailable { get; set; } = new List<string>();

        public KomodoBadge() { }
        public KomodoBadge(int badgeID, List<string> doorsAvailable)
        {
            BadgeID = badgeID;
            DoorsAvailable = doorsAvailable;
        }
    }
}
