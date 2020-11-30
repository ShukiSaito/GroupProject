using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CodeBeautify;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroupProject.Pages
{
    public class NewsModel : PageModel
    {
        public void OnGet()
        {
            using (var webClient = new WebClient())
            {
                var DayOfWeek = DateTime.Today;
                //string date = DateTime.ParseExact(DayOfWeek, "+dd/MM/yyyy+", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                var start = DayOfWeek.AddDays(-7);
                var real = start.ToString("yyyy-MM-dd");
                var newsjson = webClient.DownloadString($"http://newsapi.org/v2/everything?q=premierleague&from={real}&sortBy=publishedAt&apiKey=726ac5e8862347578fff7442d755adda");
                var newstring = Welcome9.FromJson(newsjson);
                var newstring2 = newstring.Articles;
                ViewData["News"] = newstring2;

            }
        
        }

        
    }
}
