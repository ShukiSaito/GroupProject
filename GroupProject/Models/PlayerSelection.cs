using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class PlayerSelction
    {
        public int PlayerSelctionId { get; set; }
        public List<PlayerList> PlayerLists { get; set; }
        public Member Member { get; set; }

    }
}
