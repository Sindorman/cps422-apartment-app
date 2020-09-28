using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apartment_app.Data
{
    /// <summary>
    /// Class representing Land Lord.
    /// </summary>
    public class Landlord : GeneralUser
    {
        /// <summary>
        /// Gets or sets list of properties.
        /// </summary>
        public List<Property> Properties { get; set; }

        /// <summary>
        /// Method to add property
        /// </summary>
        /// <param name="property">Property to add</param>
        public void AddProperty(Property property)
        {
        }

        /// <summary>
        /// Method to edit the property
        /// </summary>
        /// <param name="property">property landlord wants to manage.</param>
        public void ManageProperties(Property property)
        {
        }

        /// <summary>
        /// Method to delete property
        /// </summary>
        /// <param name="property">property to delete</param>
        public void DeleteProperty(Property property)
        {
        }
    }
}
