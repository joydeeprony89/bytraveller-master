using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ByTraveller.EntityFramework;
using ByTraveller.Model.Models;

namespace ByTravellerUI.Pages.HeaderMenu
{
    public class DeleteModel : PageModel
    {
        private readonly ByTraveller.EntityFramework.ApplicationContext _context;

        public DeleteModel(ByTraveller.EntityFramework.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HeaderMainMenu HeaderMainMenu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HeaderMainMenu = await _context.HeaderMainMenus.FirstOrDefaultAsync(m => m.HeaderMainMenuId == id);

            if (HeaderMainMenu == null)
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

            HeaderMainMenu = await _context.HeaderMainMenus.FindAsync(id);

            if (HeaderMainMenu != null)
            {
                _context.HeaderMainMenus.Remove(HeaderMainMenu);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
