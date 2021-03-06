using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickType;
using QuickTypePlayerStats;

namespace GroupProject.Pages
{
    public class PlayerStatsModel : PageModel
    {
        public void OnGet()
        {
            using (var webClient = new WebClient())
            {
                string playersStats = webClient.DownloadString("https://api.sportsdata.io/v3/soccer/stats/json/PlayerSeasonStats/383?key=bc49021bad1943008414c5a75e665961");


                var playerstat = PlayerInfo.FromJson(playersStats);

                ViewData["PlayerInfo"] = playerstat;

                string playerall = webClient.DownloadString("https://api.sportsdata.io/v3/soccer/scores/json/MembershipsByCompetition/EPL?key=bc49021bad1943008414c5a75e665961");


                var playeralls = PlayerStats.FromJson(playerall);

                ViewData["PlayerStats"] = playeralls;


            }
        }
    }
}
