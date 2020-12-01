using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class PlayerSelction
    {
        [DisplayName("Player Selection ID")]
        public int PlayerSelctionId { get; set; }

        [DisplayName("Name of Your Selection")]
        public string PlayerSelctionName { get; set; }

        public List<PlayerList> PlayerLists { get; set; }
        public Member Member { get; set; }

        [DisplayName("Your Member's ID")]
        public int Memberid { get; set; }

    }
}
