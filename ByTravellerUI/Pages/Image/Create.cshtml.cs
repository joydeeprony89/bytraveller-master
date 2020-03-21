using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ByTraveller.EntityFramework;
using ByTraveller.Model.Models;

namespace ByTravellerUI.Pages.Image
{
    public class CreateModel : PageModel
    {
        private readonly ByTraveller.EntityFramework.ApplicationContext _context;

        public CreateModel(ByTraveller.EntityFramework.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ByTraveller.Model.Models.Image Image { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Images.Add(Image);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}