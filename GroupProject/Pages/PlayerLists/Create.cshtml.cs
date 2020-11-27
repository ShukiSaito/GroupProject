using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroupProject.Data;
using GroupProject.Models;

namespace GroupProject.Pages.PlayerLists
{
    public class CreateModel : PageModel
    {
        private readonly GroupProject.Data.GroupProjectContext _context;

        public CreateModel(GroupProject.Data.GroupProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PlayerSelectionId"] = new SelectList(_context.Set<PlayerSelction>(), "PlayerSelctionId", "PlayerSelctionId");
            return Page();
        }

        [BindProperty]
        public PlayerList PlayerList { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PlayerList.Add(PlayerList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
