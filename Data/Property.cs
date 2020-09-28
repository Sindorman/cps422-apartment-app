using Microsoft.Extensions.Localization.Internal;
using System;
using System.Collections.Generic;
//using BlazorInputFile;                              // for IFileEntry

namespace apartment_app.Data
{
    /// <summary>
    /// Class representing a property.
    /// </summary>
    public class Property 
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Owner.
        /// </summary>
        public Landlord Owner { get; set; } = new Landlord();

        /// <summary>
        /// Gets or sets Address line 1.
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets Address line 2.
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets Rent.
        /// </summary>
        public int Rent { get; set; }

        /// <summary>
        /// Gets or sets number of total occupant spaces.
        /// </summary>
        public int TotalSpaces { get; set; }

        /// <summary>
        /// Gets or sets spaces available.
        /// </summary>
        public int SpacesAvailable { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets list of files.
        /// </summary>
        public List<string> FileNames { get; set; }
    }
}