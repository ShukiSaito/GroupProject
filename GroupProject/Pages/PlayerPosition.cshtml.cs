using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using QuickTypePlayerStats;
using QuickTypePosition;

namespace GroupProject.Pages
{
    public class PlayerPositionModel : PageModel
    {
        public string SearchString { get; set; }

        public void OnGet()

        {
            String SearchString = HttpContext.Request.Query["SearchString"];
            using (var webClient = new WebClient())
            {
                

                string positionString = webClient.DownloadString("https://raw.githubusercontent.com/ShukiSaito/GroupProject/master/GroupProject/PlayersTeamAndSalary.json");

                //JObject jsonObject = JObject.Parse(playerPositionJson);
                // var myDeserializedClass = JsonConvert.DeserializeObject<Root>(jsonObject);
                
                JSchema PositionSchema = JSchema.Parse(System.IO.File.ReadAllText("PlayerPositionSchema.json"));
                JArray PositionArray = JArray.Parse(positionString);
                IList<string> validationPosition = new List<string>();
                if (PositionArray.IsValid(PositionSchema, out validationPosition))
                {
                    var playerPosition = PlayerPosition.FromJson(positionString);
                    
                    ViewData["PlayerPosition"] = playerPosition;
                    var players = from m in playerPosition
                                  select m;
                    if (!string.IsNullOrEmpty(SearchString))
                    {
                        var seachple = players.Where(s => s.CommonName.Contains(SearchString));
                       
                        ViewData["PlayerPosition"] = seachple.ToArray();
                    }
                    
                }
                else
                {
                    foreach (string evtPosition in validationPosition)
                    {
                        Console.WriteLine(evtPosition);
                    }
                    ViewData["PlayerPosition"] = new List<PlayerPosition>();
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
