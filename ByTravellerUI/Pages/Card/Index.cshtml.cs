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
    public class IndexModel : PageModel
    {
        private readonly ByTraveller.EntityFramework.ApplicationContext _context;

        public IndexModel(ByTraveller.EntityFramework.ApplicationContext context)
        {
            _context = context;
        }

        public IList<ByTraveller.Model.Models.Card> Card { get;set; }

        public async Task OnGetAsync()
        {
            Card = await _context.Cards
                .Include(c => c.SubMenuItem).ToListAsync();

            foreach (var cardItem in Card)
            {
                if (!string.IsNullOrWhiteSpace(cardItem.ImagePath))
                {
                    cardItem.ImageUploaded = true;
                }
            }
           


            //Card = await _context.Cards
            //    .Include(c => c.Image)
            //    .Include(c => c.SubMenuItem).ToListAsync();
        }
    }
}
