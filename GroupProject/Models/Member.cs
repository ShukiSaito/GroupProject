using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class Member
    {
        [DisplayName("Your ID")]
        public int MemberId { get; set; }

        [DisplayName("Your Name")]
        public string MemberName { get; set; }

        [DisplayName("Email Address")]
        public string MemberEmail { get; set; }

        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime MemberDateOfBirth { get; set; }

        [DisplayName("Your Selection")]
        public PlayerSelction PlayerSelection { get; set; }



    }
}
