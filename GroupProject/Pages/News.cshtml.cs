using System;
using System.Collections.Generic;
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
                var newsjson = webClient.DownloadString("http://newsapi.org/v2/everything?q=premierleague&from=2020-10-29&sortBy=publishedAt&apiKey=726ac5e8862347578fff7442d755adda");
                var newstring = Welcome9.FromJson(newsjson);
                var newstring2 = newstring.Articles;
                ViewData["News"] = newstring2;

            }
        
        }

        
    }
}
