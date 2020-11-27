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
    public class DetailsModel : PageModel
    {
        private readonly GroupProject.Data.GroupProjectContext _context;

        public DetailsModel(GroupProject.Data.GroupProjectContext context)
        {
            _context = context;
        }

        public PlayerSelction PlayerSelction { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PlayerSelction = await _context.PlayerSelction.FirstOrDefaultAsync(m => m.PlayerSelctionId == id);

            if (PlayerSelction == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
