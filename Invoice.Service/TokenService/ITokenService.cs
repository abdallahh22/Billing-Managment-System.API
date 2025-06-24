using Invoice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.TokenService
{
    public interface ITokenService
    {
        public string CreateToken(ApplicationUser user); 
    }
}
