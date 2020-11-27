using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using QuickType;
using QuickTypePlayerStats;

namespace GroupProject.Pages
{
    public class PlayerInfoModel : PageModel
    {
        public void OnGet()
        {
            using (var webClient = new WebClient())
            {
                string InfoString = webClient.DownloadString("https://api.sportsdata.io/v3/soccer/stats/json/PlayerSeasonStats/383?key=bc49021bad1943008414c5a75e665961");

                JSchema InfoSchema = JSchema.Parse(System.IO.File.ReadAllText("PlayerInfoSchema.json"));
                JArray InfoArray = JArray.Parse(InfoString);
                IList<string> validationInfo = new List<string>();
                if (InfoArray.IsValid(InfoSchema, out validationInfo))
                {
                    var playerInfo = PlayerInfo.FromJson(InfoString);

                    ViewData["PlayerInfo"] = playerInfo;
                } 
                else
                {
                    foreach(string evtInfo in validationInfo)
                    {
                        Console.WriteLine(evtInfo);
                    }
                    ViewData["PlayerInfo"] = new List<PlayerInfo>();
                }

               

                string StatsString = webClient.DownloadString("https://api.sportsdata.io/v3/soccer/scores/json/MembershipsByCompetition/EPL?key=bc49021bad1943008414c5a75e665961");
                JSchema Statsschema = JSchema.Parse(System.IO.File.ReadAllText("PlayerStatsSchema.json"));
                JArray StatArray = JArray.Parse(StatsString);
                IList<string> validationStats = new List<string>();
                if (StatArray.IsValid(Statsschema, out validationStats))
                {
                    var playerStats = PlayerStats.FromJson(StatsString);

                    ViewData["PlayerStats"] = playerStats;
                }
                else
                {
                    foreach(string evtStats in validationStats)
                    {
                        Console.WriteLine(evtStats);
                    }
                    ViewData["PlayerStats"] = new List<PlayerStats>();
                }


            }
        }
    }
}
