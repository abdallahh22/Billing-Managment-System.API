using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.DTO_s
{
    public class CustomerDto : ApplicationUserDto
    {
      
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string? TaxID { get; set; }
        public string? CommercialRegistration { get; set; }
  
        public string password { get; set; }

    }

}
