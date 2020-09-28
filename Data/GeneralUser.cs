using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apartment_app.Data
{
    /// <summary>
    /// Class representing general user.
    /// </summary>
    public class GeneralUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets value of FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets value of LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets value of Current property.
        /// </summary>
        public Property CurrentProperty { get; set; }

        /// <summary>
        /// User chats represented as key = email, value = chat object.
        /// </summary>
        private Dictionary<string, UserChat> userChats;


        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralUser"/> class.
        /// </summary>
        public GeneralUser()
        {
            this.FirstName = null;
            this.LastName = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralUser"/> class.
        /// </summary>
        /// <param name="firstName">first name of user</param>
        /// <param name="lastName">last name of user</param>
        public GeneralUser(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
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
        /// <param name="user">User to contact</param>
        /// <returns>The Chat</returns>
        public UserChat ContactUser(GeneralUser user)
        {
            return null;
        }
    }
}
