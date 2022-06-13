using Services.UserManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.UserManagement.Services
{
    public interface ITokenService
    {
        string CreatedToken(User userdetails);
    }
}
