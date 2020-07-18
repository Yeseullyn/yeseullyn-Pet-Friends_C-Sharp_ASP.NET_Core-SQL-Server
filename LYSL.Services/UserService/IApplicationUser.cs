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

        //ById는 int id에 해당하니 네이밍을 다른것으로 해보도록
        ServiceResponse<ApplicationUser> DeleteApplicationUser(ApplicationUser user);
        ServiceResponse<ApplicationUser> DeleteUserById(int UserId);
        ServiceResponse<ApplicationUser> CreateUser(ApplicationUser user);
        ServiceResponse<ApplicationUser> UpdateUser(ApplicationUser user);
    }
}
