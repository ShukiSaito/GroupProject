using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroupProject.Data;
using GroupProject.Models;

namespace GroupProject.Pages.PlayerLists
{
    public class DetailsModel : PageModel
    {
        private readonly GroupProject.Data.GroupProjectContext _context;

        public DetailsModel(GroupProject.Data.GroupProjectContext context)
        {
            _context = context;
        }

        public PlayerList PlayerList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PlayerList = await _context.PlayerList
                .Include(p => p.PlayerSelection).FirstOrDefaultAsync(m => m.PlayerListId == id);

            if (PlayerList == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
