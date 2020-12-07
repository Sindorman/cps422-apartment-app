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
            // Cannot have no name.
            if (newProperty.Name == null || newProperty.Name == string.Empty)
            {
                return false;
            }

            // Cannot have empty address.
            if (newProperty.AddressLine1 == null || newProperty.AddressLine1 == string.Empty)
            {
                return false;
            }

            // Rent cannot be negative or more than max integer.
            if (newProperty.Rent <= -1 || newProperty.Rent > 10000000)
            {
                return false;
            }

            // ID cannot be negative or more than max integer.
            if (newProperty.ID <= -1 || newProperty.ID > 10000000)
            {
                return false;
            }

            // Spaces available cannot be negative or more than max integer.
            if (newProperty.SpacesAvailable <= -1 || newProperty.SpacesAvailable > 10000000)
            {
                return false;
            }

            // Total spaces cannot be negative or more than max integer.
            if (newProperty.TotalSpaces <= -1 || newProperty.TotalSpaces > 10000000)
            {
                return false;
            }

            // Available spaces cannot be greater than total spaces, since that won't make sense.
            if (newProperty.SpacesAvailable > newProperty.TotalSpaces)
            {
                newProperty.SpacesAvailable = newProperty.TotalSpaces;
            }

            // Check if we already contain property with given name or the address.
            if (context.Property.Any(e => ((e.ID == newProperty.ID) || (e.Name == newProperty.Name) || (e.AddressLine1 == newProperty.AddressLine1))))
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
            // Cannot have no name.
            if (newProperty.Name == null || newProperty.Name == string.Empty)
            {
                return false;
            }

            // Cannot have empty address.
            if (newProperty.AddressLine1 == null || newProperty.AddressLine1 == string.Empty)
            {
                return false;
            }

            // Rent cannot be negative or more than max integer.
            if (newProperty.Rent <= -1 || newProperty.Rent > 10000000)
            {
                return false;
            }

            // ID cannot be negative or more than max integer.
            if (newProperty.ID <= -1 || newProperty.ID > 10000000)
            {
                return false;
            }

            // Spaces available cannot be negative or more than max integer.
            if (newProperty.SpacesAvailable <= -1 || newProperty.SpacesAvailable > 10000000)
            {
                return false;
            }

            // Total spaces cannot be negative or more than max integer.
            if (newProperty.TotalSpaces <= -1 || newProperty.TotalSpaces > 10000000)
            {
                return false;
            }

            // Available spaces cannot be greater than total spaces, since that won't make sense.
            if (newProperty.SpacesAvailable > newProperty.TotalSpaces)
            {
                newProperty.SpacesAvailable = newProperty.TotalSpaces;
            }

            // Check if we already contain property with given name or the address. But avoid comparing to itself.
            if (context.Property.Any(e => ((e.ID != newProperty.ID) && ((e.Name == newProperty.Name) || (e.AddressLine1 == newProperty.AddressLine1)))))
            {
                return false;
            }

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
