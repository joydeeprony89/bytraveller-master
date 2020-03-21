namespace ByTravellerUI.Pages.MenuItem
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using ByTraveller.Model.Models;

    public class CreateModel : PageModel
    {
        private readonly ByTraveller.EntityFramework.ApplicationContext _context;

        public CreateModel(ByTraveller.EntityFramework.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["HeaderSubMenuId"] = new SelectList(_context.HeaderSubMenus, "HeaderSubMenuId", "Name");
            return Page();
        }

        [BindProperty]
        public SubMenuItem SubMenuItem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SubMenuItems.Add(SubMenuItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}