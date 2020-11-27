using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroupProject.Data;
using GroupProject.Models;

namespace GroupProject.Pages.PlayerSelections
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
            return Page();
        }

        [BindProperty]
        public PlayerSelction PlayerSelction { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PlayerSelction.Add(PlayerSelction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
