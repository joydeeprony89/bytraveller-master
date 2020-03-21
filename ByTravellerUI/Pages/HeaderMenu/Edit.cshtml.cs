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

namespace ByTravellerUI.Pages.HeaderMenu
{
    public class EditModel : PageModel
    {
        private readonly ByTraveller.EntityFramework.ApplicationContext _context;

        public EditModel(ByTraveller.EntityFramework.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HeaderMainMenu HeaderMainMenu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HeaderMainMenu = await _context.HeaderMainMenus.FirstOrDefaultAsync(m => m.HeaderMainMenuId == id);

            if (HeaderMainMenu == null)
            {
                return NotFound();
            }
            return Page();
        }

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

            _context.Attach(HeaderMainMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeaderMainMenuExists(HeaderMainMenu.HeaderMainMenuId))
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

        private bool HeaderMainMenuExists(int id)
        {
            return _context.HeaderMainMenus.Any(e => e.HeaderMainMenuId == id);
        }
    }
}
