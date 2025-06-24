using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Data.Entities
{
    public class Company : BaseEntity<int>
    {
        public string CompanyName { get; set; }
       
        public ApplicationUser? AppUser { get; set; }
      
    }
}
