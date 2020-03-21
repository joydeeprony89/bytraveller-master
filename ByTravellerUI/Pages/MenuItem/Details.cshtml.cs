namespace ByTravellerUI.Pages.MenuItem
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using ByTraveller.Model.Models;

    public class DetailsModel : PageModel
    {
        private readonly ByTraveller.EntityFramework.ApplicationContext _context;

        public DetailsModel(ByTraveller.EntityFramework.ApplicationContext context)
        {
            _context = context;
        }

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
    }
}
