﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.UserService.Dto_s
{
    public class UserDto
    {
        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
