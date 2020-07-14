using LYSL.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LYSL.Services.UserService
{
    public interface IApplicationUser
    {

        List<ApplicationUser> GetAllUsers();
        ApplicationUser GetUserById(int UserId);

        ServiceResponse<ApplicationUser> DeleteUserById(ApplicationUser user);
        ServiceResponse<ApplicationUser> DeleteUserById(int UserId);
        ServiceResponse<ApplicationUser> CreateUser(ApplicationUser user);
        ServiceResponse<ApplicationUser> UpdateUser(ApplicationUser user);
    }
}
