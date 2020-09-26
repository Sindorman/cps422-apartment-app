using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apartment_app.Data
{
    public class GeneralUser : IdentityUser
    {
        private string firstName;
        private string lastName;
        // list of properties user has applied to
        private List<Property> currentProperty;
        // key = email, value = chat log
        private Dictionary<string, UserChat> userChats;

        public string FirstName { get; set; }
        public string LastName { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        public GeneralUser()
        {
            this.firstName = null;
            this.lastName = null;
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="firstName">first name of user</param>
        /// <param name="lastName">last name of user</param>
        public GeneralUser(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        
        /// <summary>
        /// Method to allow user to apply for a property.
        /// </summary>
        /// <param name="property">The property the user is applying for.</param>
        public void ApplyForProperty(Property property)
        {
        }
        

        /// <summary>
        /// Method contacts the user and returns the chatlog
        /// </summary>
        /// <param name="User">User to contact</param>
        /// <returns>The Chat</returns>
        public UserChat ContactUser(GeneralUser User)
        {
            return null;
        }


        
    }
}
