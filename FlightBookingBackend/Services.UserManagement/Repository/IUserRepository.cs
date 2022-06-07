using Services.UserManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.UserManagement.Repository
{
    public interface IUserRepository
    {
        bool AddNewUser(User objUser);

        bool DeleteExistingUser(int UserID);

        bool UpdateUserDetails(User objUser);

        bool ChangePassword(Password objPassword);

        List<User> GetUserList();

        User Login(User UserCred);
    }
}
