using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using QuickTypePlayerStats;
using QuickTypeSalary;
using QuickTypeSalary2;

namespace GroupProject.Pages
{
    public class PlayerSalaryModel : PageModel
    {
        public void OnGet()
        {
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
                }
                else
                {
                    foreach (string evtStats in validationStats)
                    {
                        Console.WriteLine(evtStats);
                    }
                    ViewData["PlayerStats"] = new List<PlayerStats>();
                }


            }
        }
    }
}
