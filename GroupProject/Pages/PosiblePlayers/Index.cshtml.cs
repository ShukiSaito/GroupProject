using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroupProject.Data;
using GroupProject.Models;

namespace GroupProject.Pages.PosiblePlayers
{
    public class IndexModel : PageModel
    {
        private readonly GroupProject.Data.GroupProjectContext _context;

        public IndexModel(GroupProject.Data.GroupProjectContext context)
        {
            _context = context;
        }

        public IList<PosiblePlayer> PosiblePlayer { get;set; }

        public async Task OnGetAsync()
        {
            PosiblePlayer = await _context.PosiblePlayer.ToListAsync();
        }
    }
}
