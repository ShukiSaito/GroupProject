using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class PosiblePlayer
    {
        public int PosiblePlayerId { get; set; }

        [DisplayName("Player")]
        [Required]
        [DataType(DataType.Text)]
        public string PosiblePlayerName { get; set; }

        [DisplayName("User Reviews")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string PlayerComments { get; set; }
    }
}
