using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apartment_app.Data
{
    public class DbInitializer
    {
        public static void Initialize(PropertiesContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Property.
            if (context.Property.Any())
            {
                return;   // DB has been seeded
            }

            var properties = new Property[]
            {
                new Property{Name = "Chief Joseph", AddressLine1 = "2025, NE Terre View, Pullman, WA, 99163", AddressLine2 = "C26",
                SpacesAvailable = 10, TotalSpaces = 350, Rent = 1200, Owner = new Landlord(){ FirstName = "WSU" }, Description = "Nice college apartments"},
                new Property{Name = "Columbia", AddressLine1 = "Blah Blah", AddressLine2 = "C26",
                SpacesAvailable = 15, TotalSpaces = 350, Rent = 1050, Owner = new Landlord(){ FirstName = "WSU" }, Description = "Okay college apartments"},
            };
        }
    }
}
