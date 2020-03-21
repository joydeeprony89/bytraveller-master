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
    public class DetailsModel : PageModel
    {
        private readonly ByTraveller.EntityFramework.ApplicationContext _context;

        public DetailsModel(ByTraveller.EntityFramework.ApplicationContext context)
        {
            _context = context;
        }

        public ByTraveller.Model.Models.Image Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Image = await _context.Images.FirstOrDefaultAsync(m => m.ImageId == id);

            if (Image == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
