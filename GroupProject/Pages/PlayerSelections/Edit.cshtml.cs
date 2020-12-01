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

namespace GroupProject.Pages.PlayerSelections
{
    public class EditModel : PageModel
    {
        private readonly GroupProject.Data.GroupProjectContext _context;

        public EditModel(GroupProject.Data.GroupProjectContext context)
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
           ViewData["Memberid"] = new SelectList(_context.Member, "MemberId", "MemberId");
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

            _context.Attach(PlayerSelction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerSelctionExists(PlayerSelction.PlayerSelctionId))
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

        private bool PlayerSelctionExists(int id)
        {
            return _context.PlayerSelction.Any(e => e.PlayerSelctionId == id);
        }
    }
}
