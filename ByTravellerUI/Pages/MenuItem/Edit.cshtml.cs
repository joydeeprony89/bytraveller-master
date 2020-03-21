namespace ByTravellerUI.Pages.MenuItem
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using ByTraveller.Model.Models;

    public class EditModel : PageModel
    {
        private readonly ByTraveller.EntityFramework.ApplicationContext _context;

        public EditModel(ByTraveller.EntityFramework.ApplicationContext context)
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
           ViewData["HeaderSubMenuId"] = new SelectList(_context.HeaderSubMenus, "HeaderSubMenuId", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SubMenuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubMenuItemExists(SubMenuItem.SubMenuItemId))
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

        private bool SubMenuItemExists(int id)
        {
            return _context.SubMenuItems.Any(e => e.SubMenuItemId == id);
        }
    }
}
