using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public DateTime MemberDateOfBirth { get; set; }
        public PlayerSelction PlayerSelection { get; set; }
        public int PlayerSelectionId { get; set; }

    }
}
