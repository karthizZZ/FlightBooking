using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.UserManagement.Models.DTO
{
    public class LoginResponsedto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}
