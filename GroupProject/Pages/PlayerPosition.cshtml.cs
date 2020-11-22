using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickTypePlayerStats;
using QuickTypePosition;

namespace GroupProject.Pages
{
    public class PlayerPositionModel : PageModel
    {
        public void OnGet()
        {
            using (var webClient = new WebClient())
            {
                string playerPositionJson = webClient.DownloadString("https://api.sportsdata.io/v3/soccer/scores/json/CompetitionDetails/EPL?key=bc49021bad1943008414c5a75e665961");


                var playerPosition = PlayerPosition.FromJson(playerPositionJson);
                
                ViewData["PlayerPosition"] = playerPosition;

                string playerall = webClient.DownloadString("https://api.sportsdata.io/v3/soccer/scores/json/MembershipsByCompetition/EPL?key=bc49021bad1943008414c5a75e665961");


                var playeralls = PlayerStats.FromJson(playerall);

                ViewData["PlayerStats"] = playeralls;


            }
        }
    }
}
