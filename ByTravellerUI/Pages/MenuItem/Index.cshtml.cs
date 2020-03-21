namespace ByTravellerUI.Pages.MenuItem
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using ByTraveller.Model.Models;

    public class IndexModel : PageModel
    {
        private readonly ByTraveller.EntityFramework.ApplicationContext _context;

        public IndexModel(ByTraveller.EntityFramework.ApplicationContext context)
        {
            _context = context;
        }

        public IList<SubMenuItem> SubMenuItem { get;set; }

        public async Task OnGetAsync()
        {
            SubMenuItem = await _context.SubMenuItems
                .Include(s => s.HeaderSubMenu).ToListAsync();
        }
    }
}
