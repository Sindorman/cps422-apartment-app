using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apartment_app.Data
{
    public class PropertyApplication
    {
        private bool isApproved;
        private string approvedBy;
        private Property property;
        private string applicant;

        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public Property Property { get; set; }
        public string Applicant { get; set; }
    }
}
