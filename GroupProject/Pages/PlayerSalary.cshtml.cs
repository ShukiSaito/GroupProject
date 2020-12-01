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
using QuickTypeSalary;
using QuickTypeSalary2;

namespace GroupProject.Pages
{
    public class PlayerSalaryModel : PageModel
    {
        public string SearchString { get; set; }

        public string TeamString { get; set; }
        public void OnGet()
        {
            String SearchString = HttpContext.Request.Query["SearchString"];
            String TeamString = HttpContext.Request.Query["TeamString"];
            using (var webClient = new WebClient())
            {
                string SalaryString = webClient.DownloadString("https://api.sportsdata.io/v3/soccer/projections/json/PlayerGameProjectionStatsByCompetition/EPL/2020-11-21?key=bc49021bad1943008414c5a75e665961");
                JSchema SalarySchema = JSchema.Parse(System.IO.File.ReadAllText("PlayerSalarySchema.json"));
                JArray SalaryArray = JArray.Parse(SalaryString);
                IList<string> validationSalary = new List<string>();
                if (SalaryArray.IsValid(SalarySchema, out validationSalary))
                {
                    var playerSalary = PlayerSalary.FromJson(SalaryString);

                    ViewData["PlayerSalary"] = playerSalary;
                    var players = from m in playerSalary
                                  select m;
                    if (!string.IsNullOrEmpty(TeamString))
                    {
                        var seachple = players.Where(s => s.Team.Contains(TeamString));



                        ViewData["PlayerSalary"] = seachple.ToArray();
                    }
                }
                else
                {
                    foreach (string evtSalary in validationSalary)
                    {
                        Console.WriteLine(evtSalary);
                    }
                    ViewData["PlayerSalary"] = new List<PlayerSalary>();
                }




                string Salary2String = webClient.DownloadString("https://api.sportsdata.io/v3/soccer/projections/json/PlayerGameProjectionStatsByCompetition/EPL/2020-11-22?key=bc49021bad1943008414c5a75e665961");

                JSchema Salary2Schema = JSchema.Parse(System.IO.File.ReadAllText("PlayerSalary2Schema.json"));
                JArray Salary2Array = JArray.Parse(Salary2String);
                IList<string> validationSalary2 = new List<string>();
                if (Salary2Array.IsValid(Salary2Schema, out validationSalary2))
                {
                    var playerSalary2 = PlayerSalary2.FromJson(Salary2String);

                    ViewData["PlayerSalary2"] = playerSalary2;
                    var players = from m in playerSalary2
                                  select m;
                    if (!string.IsNullOrEmpty(TeamString))
                    {
                        var seachple = players.Where(s => s.Team.Contains(TeamString));



                        ViewData["PlayerSalary2"] = seachple.ToArray();
                    }
                }
                else
                {
                    foreach (string evtSalary2 in validationSalary2)
                    {
                        Console.WriteLine(evtSalary2);
                    }
                    ViewData["PlayerSalary2"] = new List<PlayerSalary2>();
                }




                string StatsString = webClient.DownloadString("https://api.sportsdata.io/v3/soccer/scores/json/MembershipsByCompetition/EPL?key=bc49021bad1943008414c5a75e665961");
                JSchema Statsschema = JSchema.Parse(System.IO.File.ReadAllText("PlayerStatsSchema.json"));
                JArray StatArray = JArray.Parse(StatsString);
                IList<string> validationStats = new List<string>();
                if (StatArray.IsValid(Statsschema, out validationStats))
                {
                    var playerStats = PlayerStats.FromJson(StatsString);

                    ViewData["PlayerStats"] = playerStats;
                    var players = from m in playerStats
                                  select m;
                    if (!string.IsNullOrEmpty(SearchString))
                    {
                        var seachple = players.Where(s => s.PlayerName.Contains(SearchString));



                        ViewData["PlayerStats"] = seachple.ToArray();
                    }
                }
                else
                {
                    foreach (string evtStats in validationStats)
                    {
                        Console.WriteLine(evtStats);
                    }
                    ViewData["PlayerStats"] = new List<PlayerStats>();
                }
                string InfoString = webClient.DownloadString("https://api.sportsdata.io/v3/soccer/stats/json/PlayerSeasonStats/383?key=bc49021bad1943008414c5a75e665961");

                JSchema InfoSchema = JSchema.Parse(System.IO.File.ReadAllText("PlayerInfoSchema.json"));
                JArray InfoArray = JArray.Parse(InfoString);
                IList<string> validationInfo = new List<string>();
                if (InfoArray.IsValid(InfoSchema, out validationInfo))
                {
                    var playerInfo = PlayerInfo.FromJson(InfoString);

                    ViewData["PlayerInfo"] = playerInfo;
                    var players = from m in playerInfo
                                  select m;
                    if (!string.IsNullOrEmpty(SearchString))
                    {
                        var seachple = players.Where(s => s.Name.Contains(SearchString));



                        ViewData["PlayerInfo"] = seachple.ToArray();
                    }
                }
                else
                {
                    foreach (string evtInfo in validationInfo)
                    {
                        Console.WriteLine(evtInfo);
                    }
                    ViewData["PlayerInfo"] = new List<PlayerInfo>();
                }

            }
        }
    }
}
