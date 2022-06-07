using Microsoft.AspNetCore.Mvc;
using Services.UserManagement.Models;
using Services.UserManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.UserManagement.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserManagementController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("AddNewUser")]
        public  bool AddNewUser([FromBody]User userDetails)
        {
            bool IsSuccess =  _userRepository.AddNewUser(userDetails);
            return IsSuccess;
        }

        [HttpPost("ChangeUserPassword")]
        public bool ChangeUserPassword([FromBody]Password objPassword)
        {
            bool IsSuccess = _userRepository.ChangePassword(objPassword);
            return IsSuccess;
        }

        [HttpPost("UpdateUserDetails")]
        public bool UpdateUserDetails([FromBody] User UserDetails)
        {
            bool IsSuccess = _userRepository.UpdateUserDetails(UserDetails);
            return IsSuccess;
        }

        [HttpGet("DeleteUser/{UserID}")]
        public bool DeleteUser(int UserID)
        {
            bool IsSuccess = _userRepository.DeleteExistingUser(UserID);
            return IsSuccess;
        }

        [HttpGet("GetUserList")]
        public List<User> GetUserList()
        {
            List<User> objUserList = _userRepository.GetUserList();

            return objUserList;
        }

        [HttpPost("Login")]
        public User Login([FromBody] User UserCredentials)
        {
            User UserProfile = _userRepository.Login(UserCredentials);
            return UserProfile;
        }
    }
}
