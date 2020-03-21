using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ByTraveller.EntityFramework;
using ByTraveller.Model.Models;

namespace ByTravellerUI.Pages.Card
{
    public class DetailsModel : PageModel
    {
        private readonly ByTraveller.EntityFramework.ApplicationContext _context;

        public DetailsModel(ByTraveller.EntityFramework.ApplicationContext context)
        {
            _context = context;
        }

        public ByTraveller.Model.Models.Card Card { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Card = await _context.Cards
                .Include(c => c.SubMenuItem).FirstOrDefaultAsync(m => m.CardId == id);

            if (Card == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
