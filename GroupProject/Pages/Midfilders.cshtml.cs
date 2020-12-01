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
using QuickTypePosition;

namespace GroupProject.Pages
{
    public class MidfildersModel : PageModel
    {
        public string SearchString { get; set; }

        public string TeamString { get; set; }
        public void OnGet()
        {
            String SearchString = HttpContext.Request.Query["SearchString"];
            String TeamString = HttpContext.Request.Query["TeamString"];
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
                    var players = from m in playerInfo
                                  select m;
                    if (!string.IsNullOrEmpty(TeamString))
                    {
                        var seachple = players.Where(s => s.Team.Contains(TeamString));



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

            }
        }
    }
    
}
