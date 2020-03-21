using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ByTraveller.Model.Models;

namespace ByTravellerUI.Pages.MenuItem
{
    public class DeleteModel : PageModel
    {
        private readonly ByTraveller.EntityFramework.ApplicationContext _context;

        public DeleteModel(ByTraveller.EntityFramework.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SubMenuItem SubMenuItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SubMenuItem = await _context.SubMenuItems
                .Include(s => s.HeaderSubMenu).FirstOrDefaultAsync(m => m.SubMenuItemId == id);

            if (SubMenuItem == null)
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

            SubMenuItem = await _context.SubMenuItems.FindAsync(id);

            if (SubMenuItem != null)
            {
                _context.SubMenuItems.Remove(SubMenuItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
