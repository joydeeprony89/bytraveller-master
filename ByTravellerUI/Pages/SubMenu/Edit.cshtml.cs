using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ByTraveller.EntityFramework;
using ByTraveller.Model.Models;

namespace ByTravellerUI.Pages.SubMenu
{
    public class EditModel : PageModel
    {
        private readonly ByTraveller.EntityFramework.ApplicationContext _context;

        public EditModel(ByTraveller.EntityFramework.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HeaderSubMenu HeaderSubMenu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HeaderSubMenu = await _context.HeaderSubMenus
                .Include(h => h.HeaderMainMenu).FirstOrDefaultAsync(m => m.HeaderSubMenuId == id);

            if (HeaderSubMenu == null)
            {
                return NotFound();
            }
           ViewData["HeaderMainMenuId"] = new SelectList(_context.HeaderMainMenus, "HeaderMainMenuId", "Name");
            return Page();
        }

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

            _context.Attach(HeaderSubMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeaderSubMenuExists(HeaderSubMenu.HeaderSubMenuId))
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

        private bool HeaderSubMenuExists(int id)
        {
            return _context.HeaderSubMenus.Any(e => e.HeaderSubMenuId == id);
        }
    }
}
