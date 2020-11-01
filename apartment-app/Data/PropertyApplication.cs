using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apartment_app.Data
{
    /// <summary>
    /// Property application class.
    /// </summary>
    public class PropertyApplication
    {
        /// <summary>
        /// Gets or sets a value indicating whether isApproved.
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets ApprovedBy.
        /// </summary>
        public string ApprovedBy { get; set; }

        /// <summary>
        /// Gets or sets Property reference.
        /// </summary>
        public Property Property { get; set; }

        /// <summary>
        /// Gets or sets Applicant.
        /// </summary>
        public Landlord Applicant { get; set; }
    }
}
