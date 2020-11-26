using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject
{


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Root
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CommonName { get; set; }
        public string ShortName { get; set; }
        public string Position { get; set; }
        public string PositionCategory { get; set; }
        public int Jersey { get; set; }
        public string Foot { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthCity { get; set; }
        public string BirthCountry { get; set; }
        public string Nationality { get; set; }
        public string InjuryStatus { get; set; }
        public string InjuryBodyPart { get; set; }
        public string InjuryNotes { get; set; }
        public object InjuryStartDate { get; set; }
        public DateTime Updated { get; set; }
        public string PhotoUrl { get; set; }
        public int RotoWirePlayerID { get; set; }
        public string DraftKingsPosition { get; set; }
        public object UsaTodayPlayerID { get; set; }
        public object UsaTodayHeadshotUrl { get; set; }
        public object UsaTodayHeadshotNoBackgroundUrl { get; set; }
        public object UsaTodayHeadshotUpdated { get; set; }
        public object UsaTodayHeadshotNoBackgroundUpdated { get; set; }
    }



}