using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Data.Entities
{
    public class Customer : BaseEntity<int>
    {
   
        public ApplicationUser? AppUser { get; set; }
       
    }
}
