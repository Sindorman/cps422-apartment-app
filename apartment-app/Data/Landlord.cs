using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        [InverseProperty("Owner")]
        public List<Property> Properties { get; set; }

        /// <summary>
        /// Method to add property
        /// </summary>
        /// <param name="property">Property to add</param>
        public async Task<bool> AddProperty(Property newProperty, PropertiesContext context)
        {
            if (context.Property.Any(e => ((e.Name == newProperty.Name) || (e.AddressLine1 == newProperty.AddressLine1))))
            {
                return false;
            }
            else
            {
                context.Property.Add(newProperty);
                await context.SaveChangesAsync();
                return true;
            }
        }

        /// <summary>
        /// Method to edit the property
        /// </summary>
        /// <param name="property">property landlord wants to manage.</param>
        public async Task<bool> ManageProperties(Property newProperty, PropertiesContext context)
        {
            context.Attach(newProperty).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (context.Property.Any(e => e.ID == newProperty.ID))
                {
                }
                else
                {
                    throw;
                }
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method to delete property
        /// </summary>
        /// <param name="property">property to delete</param>
        public async Task<bool> DeleteProperty(Property property, PropertiesContext context)
        {
            if (property != null)
            {
                context.Property.Remove(property);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
