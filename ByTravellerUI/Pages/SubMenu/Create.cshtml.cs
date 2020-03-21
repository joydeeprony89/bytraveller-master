using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ByTraveller.EntityFramework;
using ByTraveller.Model.Models;

namespace ByTravellerUI.Pages.SubMenu
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
        ViewData["HeaderMainMenuId"] = new SelectList(_context.HeaderMainMenus, "HeaderMainMenuId", "Name");
            return Page();
        }

        [BindProperty]
        public HeaderSubMenu HeaderSubMenu { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            DateTime todayDate = DateTime.Today;
            DateTime createdOn = HeaderSubMenu.CreatedOn;
            int result = DateTime.Compare(createdOn, todayDate);

            if (result < 0)
            {
                HeaderSubMenu.CreatedOn = todayDate;
                HeaderSubMenu.ModifiedOn = todayDate;
            }

            _context.HeaderSubMenus.Add(HeaderSubMenu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}