using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using apartment_app.Data;

namespace apartment_app.Areas.Identity.Pages.Properties
{
    public class IndexModel : PageModel
    {
        private readonly apartment_app.Data.PropertiesContext _context;

        public IndexModel(apartment_app.Data.PropertiesContext context)
        {
            _context = context;
        }

        public IList<Property> Property { get;set; }

        public async Task OnGetAsync()
        {
            Property = await _context.Property.ToListAsync();
        }
    }
}
