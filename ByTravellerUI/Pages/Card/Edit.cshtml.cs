using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ByTraveller.EntityFramework;
using System.IO;
using Microsoft.Extensions.Configuration;
using ByTravellerUI.Utilities;

namespace ByTravellerUI.Pages.Card
{
    public class EditModel : PageModel
    {
        private readonly ApplicationContext _context;

        private readonly IConfiguration _config;

        public EditModel(ApplicationContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [BindProperty]
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
           ViewData["SubMenuItemId"] = new SelectList(_context.SubMenuItems, "SubMenuItemId", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || !ImageUtility.ValidateImageName(Card?.ImageFile))
            {
                return Page();
            }
            var fileName = Path.GetFileNameWithoutExtension(Card.ImageFile.FileName);
            var fileExtension = Path.GetExtension(Card.ImageFile.FileName);
            var fileDirectory = _config.GetSection("AppSettings").GetValue<string>("ImageUploadPath") + Card.Name + "/ProfileImages/";

            //fileName = DateTime.Now.ToString("yyyyMMdd") + "$" + fileName.Trim() + fileExtension;
            fileName = fileName.Trim() + fileExtension;

            Card.ImagePath = fileDirectory + fileName;

            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(Card.ImagePath);
            }

            if (Card.ImageFile.Length > 0)
            {
                using (var stream = new FileStream(Card.ImagePath, FileMode.Create))
                {
                    await Card.ImageFile.CopyToAsync(stream);
                }
            }

            _context.Attach(Card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(Card.CardId))
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

        private bool CardExists(int id)
        {
            return _context.Cards.Any(e => e.CardId == id);
        }
    }
}
