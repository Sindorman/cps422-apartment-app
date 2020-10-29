using Microsoft.Extensions.Localization.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using BlazorInputFile;                              // for IFileEntry

namespace apartment_app.Data
{
    /// <summary>
    /// Class representing a property.
    /// </summary>
    public class Property 
    {
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Owner.
        /// </summary>
        public Landlord Owner { get; set; }

        /// <summary>
        /// Gets or sets Address line 1.
        /// </summary>
        [Required]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets Address line 2.
        /// </summary>
        [Required]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets Rent.
        /// </summary>
        [Required]
        public int Rent { get; set; }

        /// <summary>
        /// Gets or sets number of total occupant spaces.
        /// </summary>
        [Required]
        public int TotalSpaces { get; set; }

        /// <summary>
        /// Gets or sets spaces available.
        /// </summary>
        [Required]
        public int SpacesAvailable { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets list of files.
        /// </summary>
        public List<ImagePath> FileNames { get; set; }
    }
}