using Microsoft.Extensions.Localization.Internal;
using System;
using System.Collections.Generic;
using BlazorInputFile;              // for IFileEntry

namespace apartment_app.Data
{
    public class Property 
    {
        
        public string Owner { get; set; }           // Name of the property owner

        public string AddressLine1 { get; set; }    // The first address line

        public string AddressLine2 { get; set; }    // The second address line

        public int Rent { get; set; }               // The rent number/cost per person

        public int Spaces { get; set; }             // Number of total occupant spaces in the property

        public int SpacesAvailable { get; set; }    // Number of spaces available in property

        public string Description { get; set; }     // Text description of additional property information

        public IFileListEntry[] FileNames { get; set; } // List of image file names
    }
}