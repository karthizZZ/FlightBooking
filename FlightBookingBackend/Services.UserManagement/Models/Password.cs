using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.UserManagement.Models
{
    public class Password
    {
        public int UserID { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
