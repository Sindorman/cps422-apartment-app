using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apartment_app.Data
{
    /// <summary>
    /// Temporary static class acting as DB for now. TODO: remove it once DB is integrated.
    /// </summary>
    public static class TempUserDB
    {
        public static int selectedProperty = 0;

        public static List<Property> Properties = new List<Property>() { 
            new Property() { 
                Name = "Chief Joseph", AddressLine1 = "2025, NE Terre View, Pullman, WA, 99163", AddressLine2 = "C26",
                SpacesAvailable = 10, TotalSpaces = 350, Rent = 1200, Owner = new Landlord(){ FirstName = "WSU" }, Description = "Nice college apartments"
            },
            new Property() {
                Name = "Columbia", AddressLine1 = "Blah Blah", AddressLine2 = "C26",
                SpacesAvailable = 15, TotalSpaces = 350, Rent = 1050, Owner = new Landlord(){ FirstName = "WSU" }, Description = "Okay college apartments"
            }
        };

        public static Dictionary<string, GeneralUser> GeneralUsers = new Dictionary<string, GeneralUser>();

        public static Dictionary<string, Landlord> LandLordUsers = new Dictionary<string, Landlord>();

        public static Dictionary<string, Admin> AdminUsers = new Dictionary<string, Admin>();

    }
}
