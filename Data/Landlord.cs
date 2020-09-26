//using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apartment_app.Data
{
    public class Landlord : GeneralUser
    {
        List<Property> properties;

        /// <summary>
        /// Method to edit the property
        /// </summary>
        /// <param name="property">property landlord wants to manage.</param>
        public void ManageProperties(Property property)
        {
        }
    }
}
