using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ByTraveller.EntityFramework;
using ByTraveller.Model.Models;

namespace ByTravellerUI.Pages.HeaderMenu
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
        public HeaderMainMenu HeaderMainMenu { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            DateTime todayDate = DateTime.Today;
            DateTime createdOn = HeaderMainMenu.CreatedOn;
            int result = DateTime.Compare(createdOn, todayDate);

            if (result < 0)
            {
                HeaderMainMenu.CreatedOn = todayDate;
                HeaderMainMenu.ModifiedOn = todayDate;
            }

            _context.HeaderMainMenus.Add(HeaderMainMenu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}