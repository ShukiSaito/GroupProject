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

namespace GroupProject.Pages.PlayerLists
{
    public class EditModel : PageModel
    {
        private readonly GroupProject.Data.GroupProjectContext _context;

        public EditModel(GroupProject.Data.GroupProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["PlayerSelectionId"] = new SelectList(_context.Set<PlayerSelction>(), "PlayerSelctionId", "PlayerSelctionId");
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

            _context.Attach(PlayerList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerListExists(PlayerList.PlayerListId))
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

        private bool PlayerListExists(int id)
        {
            return _context.PlayerList.Any(e => e.PlayerListId == id);
        }
    }
}
