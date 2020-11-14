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
    public class DeleteModel : PageModel
    {
        private readonly GroupProject.Data.GroupProjectContext _context;

        public DeleteModel(GroupProject.Data.GroupProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PosiblePlayer PosiblePlayer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PosiblePlayer = await _context.PosiblePlayer.FirstOrDefaultAsync(m => m.PosiblePlayerId == id);

            if (PosiblePlayer == null)
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

            PosiblePlayer = await _context.PosiblePlayer.FindAsync(id);

            if (PosiblePlayer != null)
            {
                _context.PosiblePlayer.Remove(PosiblePlayer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
