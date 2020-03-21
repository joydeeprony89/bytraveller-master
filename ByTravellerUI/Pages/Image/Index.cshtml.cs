using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ByTraveller.EntityFramework;
using ByTraveller.Model.Models;

namespace ByTravellerUI.Pages.Image
{
    public class IndexModel : PageModel
    {
        private readonly ByTraveller.EntityFramework.ApplicationContext _context;

        public IndexModel(ByTraveller.EntityFramework.ApplicationContext context)
        {
            _context = context;
        }

        public IList<ByTraveller.Model.Models.Image> Image { get;set; }

        public async Task OnGetAsync()
        {
            Image = await _context.Images.ToListAsync();
        }
    }
}
