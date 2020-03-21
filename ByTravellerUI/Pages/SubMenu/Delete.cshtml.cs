using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ByTraveller.EntityFramework;
using ByTraveller.Model.Models;

namespace ByTravellerUI.Pages.SubMenu
{
    public class DeleteModel : PageModel
    {
        private readonly ByTraveller.EntityFramework.ApplicationContext _context;

        public DeleteModel(ByTraveller.EntityFramework.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HeaderSubMenu HeaderSubMenu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HeaderSubMenu = await _context.HeaderSubMenus
                .Include(h => h.HeaderMainMenu).FirstOrDefaultAsync(m => m.HeaderSubMenuId == id);

            if (HeaderSubMenu == null)
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

            HeaderSubMenu = await _context.HeaderSubMenus.FindAsync(id);

            if (HeaderSubMenu != null)
            {
                _context.HeaderSubMenus.Remove(HeaderSubMenu);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
