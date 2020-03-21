using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ByTraveller.EntityFramework;
using System.IO;
using Microsoft.Extensions.Configuration;
using System;
using ByTravellerUI.Utilities;

namespace ByTravellerUI.Pages.Card
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _config;

        public CreateModel(ApplicationContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public IActionResult OnGet()
        {
            ViewData["SubMenuItemId"] = new SelectList(_context.SubMenuItems, "SubMenuItemId", "Name");
            return Page();
        }

        [BindProperty]
        public ByTraveller.Model.Models.Card Card { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid && ImageUtility.ValidateImageName(Card?.ImageFile))
            {
                return Page();
            }

            var fileName = Path.GetFileNameWithoutExtension(Card.ImageFile.FileName);
            var fileExtension = Path.GetExtension(Card.ImageFile.FileName);
            var fileDirectory = _config.GetSection("AppSettings").GetValue<string>("ImageUploadPath") + Card.Name + "/ProfileImages/";

            fileName = DateTime.Now.ToString("yyyyMMdd") + fileName.Trim()+ fileExtension;

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

            _context.Cards.Add(Card);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}