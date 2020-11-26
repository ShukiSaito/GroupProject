using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class PlayerSelection
    {
        public Member MemberId { get; set; }
        public int PlayerSelectionId { get; set; }
        public List<PlayerList> PlayerIds { get; set; }
        public DateTime DateCreated { get; set; }
        public int MemberIdId { get; set; }

    }
}
