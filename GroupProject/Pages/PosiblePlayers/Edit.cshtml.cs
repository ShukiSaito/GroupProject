using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupProject.Data;
using GroupProject.Models;

namespace GroupProject.Pages.PosiblePlayers
{
    public class EditModel : PageModel
    {
        private readonly GroupProject.Data.GroupProjectContext _context;

        public EditModel(GroupProject.Data.GroupProjectContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PosiblePlayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosiblePlayerExists(PosiblePlayer.PosiblePlayerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PosiblePlayerExists(int id)
        {
            return _context.PosiblePlayer.Any(e => e.PosiblePlayerId == id);
        }
    }
}
