using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; } 
        public string? TaxID { get; set; }  
        public string? CommercialRegistration { get; set; }
    }
}
