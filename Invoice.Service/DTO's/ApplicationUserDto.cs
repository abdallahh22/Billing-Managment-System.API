using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.DTO_s
{
    public class ApplicationUserDto
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? TaxID { get; set; }
        public string? CommercialRegistration { get; set; }

    }
}
