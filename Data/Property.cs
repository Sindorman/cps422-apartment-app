using Microsoft.Extensions.Localization.Internal;
using System;
using System.Collections.Generic;

namespace apartment_app.Data
{
    public class Property 
    {

        public string Owner { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public int Rent { get; set; }

        public int Spaces { get; set; }

        public int SpacesAvailable { get; set; }

        public string Description { get; set; }

        public List<string> FileNames { get; set; } // list of images
    }
}