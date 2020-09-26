//using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apartment_app.Data
{
    public class Admin : GeneralUser
    {
        /// <summary>
        /// Method to approve the property of a landlord
        /// </summary>
        /// <param name="landlord">the landlord</param>
        /// <param name="property">the landlord's property</param>
        public void ApproveLandlordProperty(string landlord, Property property)
        {
        }
    }
}
