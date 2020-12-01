using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroupProject.Data;
using GroupProject.Models;

namespace GroupProject.Pages.PlayerSelections
{
    public class IndexModel : PageModel
    {
        private readonly GroupProject.Data.GroupProjectContext _context;

        public IndexModel(GroupProject.Data.GroupProjectContext context)
        {
            _context = context;
        }

        public IList<PlayerSelction> PlayerSelction { get;set; }

        public async Task OnGetAsync()
        {
            PlayerSelction = await _context.PlayerSelction
                .Include(p => p.Member).ToListAsync();
        }
    }
}
