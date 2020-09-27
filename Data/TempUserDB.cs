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
        public static List<Property> Properties = new List<Property>();

        public static Dictionary<string, GeneralUser> GeneralUsers = new Dictionary<string, GeneralUser>();

        public static Dictionary<string, Landlord> LandLordUsers = new Dictionary<string, Landlord>();

        public static Dictionary<string, Admin> AdminUsers = new Dictionary<string, Admin>();

    }
}
