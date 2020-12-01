using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class PlayerList
    {

        [DisplayName("ID of Your List")]
        public int PlayerListId { get; set; }

        [DisplayName("Goal Keeper 1")]
        public string GoalKeeper1 { get; set; }

        [DisplayName("Goal Keeper 2")]
        public string GoalKeeper2 { get; set; }

        [DisplayName("Defender 1")]
        public string Defender1 { get; set; }

        [DisplayName("Defender 2")]
        public string Defender2 { get; set; }

        [DisplayName("Defender 3")]
        public string Defender3 { get; set; }

        [DisplayName("Defender 4")]
        public string Defender4 { get; set; }

        [DisplayName("Midfielder 1")]
        public string Midfield1 { get; set; }

        [DisplayName("Midfielder 2")]
        public string Midfield2 { get; set; }

        [DisplayName("Midfielder 3")]
        public string Midfield3 { get; set; }

        [DisplayName("Forward 1")]
        public string Forward1 { get; set; }

        [DisplayName("Forward 2")]
        public string Forward2 { get; set; }

        [DisplayName("Forward 3")]
        public string Forward3 { get; set; }

        [DisplayName("Extra Substitution Player 1")]
        public string DefenderMidfieldForward1 { get; set; }

        [DisplayName("Extra Substitution Player 2")]
        public string DefenderMidfieldForward2 { get; set; }

        [DisplayName("Extra Substitution Player 3")]
        public string DefenderMidfieldForward3 { get; set; }

        [DisplayName("Player Selection")]
        public PlayerSelction PlayerSelection { get; set; }

        [DisplayName("Your Selection's ID")]
        public int PlayerSelectionId { get; set; }

    }
}
