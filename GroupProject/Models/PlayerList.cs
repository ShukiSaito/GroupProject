using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class PlayerList
    {
        public int PlayerListId { get; set; }
        public PlayerSelection PlayerSelection { get; set; }
        public int PlayerSelectionId { get; set; }
        public string Goalkeeper1 { get; set; }
        public string Goalkeeper2 { get; set; }
        public string Defender1 { get; set; }
        public string Defender2 { get; set; }
        public string Defender3 { get; set; }
        public string Defender4 { get; set; }
        public string Midfield1 { get; set; }
        public string Midfield2 { get; set; }
        public string Midfield3 { get; set; }
        public string Forward1 { get; set; }
        public string Forward2 { get; set; }
        public string Forward3 { get; set; }
        public string DefenderMidfieldForward1 { get; set; }
        public string DefenderMidfieldForward2 { get; set; }
        public string DefenderMidfieldForward3 { get; set; }

    }
}
