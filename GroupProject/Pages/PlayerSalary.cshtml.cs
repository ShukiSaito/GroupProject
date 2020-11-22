using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickTypePlayerStats;
using QuickTypeSalary;

namespace GroupProject.Pages
{
    public class PlayerSalaryModel : PageModel
    {
        public void OnGet()
        {
            using (var webClient = new WebClient())
            {
                string playersSalary = webClient.DownloadString("https://api.sportsdata.io/v3/soccer/projections/json/UpcomingDfsSlatesByCompetition/1?key=bc49021bad1943008414c5a75e665961");


                var playerSalary = PlayerSalary.FromJson(playersSalary);

                ViewData["PlayerSalary"] = playerSalary;

                string playerall = webClient.DownloadString("https://api.sportsdata.io/v3/soccer/scores/json/MembershipsByCompetition/EPL?key=bc49021bad1943008414c5a75e665961");


                var playeralls = PlayerStats.FromJson(playerall);

                ViewData["PlayerStats"] = playeralls;


            }
        }
    }
}
