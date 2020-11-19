using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using QuickType;
using QuickTypePlayerDetails;
//using QuickTypePlayerDetails;

namespace GroupProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            using(var webClient = new WebClient())
            {
                IDictionary<long, QuickTypePlayerDetails.PlayerStats> allinfo = new Dictionary<long, QuickTypePlayerDetails.PlayerStats>();
                String playersStats = webClient.DownloadString("https://api.sportsdata.io/v3/soccer/stats/json/PlayerSeasonStats/383?key=bc49021bad1943008414c5a75e665961");

               var playersStats1 = QuickTypePlayerDetails.PlayerStats.FromJson(playersStats);
               //var detailed = playersStats1.;
                
                
                foreach (var player in playersStats1)
                {
                    allinfo.Add(player.PlayerId, player);

                }
                ViewData["allinfo"] = allinfo;



                string Membership = webClient.DownloadString("https://api.sportsdata.io/v3/soccer/scores/json/MembershipsByCompetition/EPL?key=bc49021bad1943008414c5a75e665961");
                JSchema schema = JSchema.Parse(System.IO.File.ReadAllText("PlayerInfoSchema.json"));
                JArray jarray = JArray.Parse(Membership);
                
                
                IList<string> validationEvents = new List<string>();
                if (jarray.IsValid(schema, out validationEvents))
                {
                    var playerinfo = PlayerInfo.FromJson(Membership);
                    List<PlayerInfo> Playergather = new List<PlayerInfo>();
                    foreach (var playerin in playerinfo)
                    {
                        if (allinfo.ContainsKey(playerin.PlayerId))
                        {
                            Playergather.Add(playerin);
                        }
                            
                    }

                    ViewData["PlayerInfo"] = Playergather;
                    
                }
                else
                {
                    foreach(string evt in validationEvents)
                    {
                        Console.WriteLine(evt);

                    }
                    ViewData["PlayerInfo"] = new List<PlayerInfo>();
                }
                
            }

        }
    }
}
