using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using apartment_app.Data;

namespace apartment_app.Areas.Identity.Pages.Properties
{
    public class CreateModel : PageModel
    {
        private readonly apartment_app.Data.PropertiesContext _context;

        public CreateModel(apartment_app.Data.PropertiesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Property Property { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Property.Add(Property);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
