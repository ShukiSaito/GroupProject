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
    public class DeleteModel : PageModel
    {
        private readonly GroupProject.Data.GroupProjectContext _context;

        public DeleteModel(GroupProject.Data.GroupProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PlayerSelction PlayerSelction { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PlayerSelction = await _context.PlayerSelction
                .Include(p => p.Member).FirstOrDefaultAsync(m => m.PlayerSelctionId == id);

            if (PlayerSelction == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PlayerSelction = await _context.PlayerSelction.FindAsync(id);

            if (PlayerSelction != null)
            {
                _context.PlayerSelction.Remove(PlayerSelction);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
