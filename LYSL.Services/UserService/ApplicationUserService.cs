using LYSL.Data.Models;
using LYSL.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LYSL.Services.UserService
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public ServiceResponse<ApplicationUser> CreateUser(ApplicationUser user)
        {
            try
            {
                var newApplicationUser = new ApplicationUser
                {
                    //Id = UserId.Id,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    Pet = user.Pet
                };

                _db.ApplicationUser.Add(newApplicationUser);
                _db.SaveChanges();

                return new ServiceResponse<ApplicationUser>
                {
                    Data = user,
                    Time = DateTime.UtcNow,
                    Messsage = "New User added",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<ApplicationUser>
                {
                    Data = user,
                    Time = DateTime.UtcNow,
                    Messsage = "User is not added",
                    IsSuccess = false
                };
            }
        }

        public ApplicationUser GetUserById(int UserId)
        {
            return _db.ApplicationUser.Find(UserId);
        }

        public List<ApplicationUser> GetAllUsers()
        {
            return _db.ApplicationUser.ToList();
        }

        /// <summary>
        /// 네이밍을 유저로
        /// 이것도 ById 지우기
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ServiceResponse<ApplicationUser> DeleteApplicationUser(ApplicationUser user)
        {
            try
            {
                _db.ApplicationUser.Remove(user);
                _db.SaveChanges();

                return new ServiceResponse<ApplicationUser>
                {
                    Data = null,
                    IsSuccess = true,
                    Messsage = "User data is deleted",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception)
            {
                return new ServiceResponse<ApplicationUser>
                {
                    Data = null,
                    IsSuccess = false,
                    Messsage = "Error in deleting User",
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<ApplicationUser> DeleteUserById(int UserId)
        {
            try
            {
                var user = GetUserById(UserId);
                _db.Remove(user);
                _db.SaveChanges();
                return new ServiceResponse<ApplicationUser>
                {
                    Data = null,
                    IsSuccess = true,
                    Messsage = "User data is deleted",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<ApplicationUser>
                {
                    Data = null,
                    IsSuccess = false,
                    Messsage = "Error in deleting User",
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<ApplicationUser> UpdateUser(ApplicationUser user)
        {
            try
            {
                var newApplicationUser = new ApplicationUser
                {
                    //Id = UserId.Id,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    Pet = user.Pet
                };

                _db.ApplicationUser.Update(newApplicationUser);
                _db.SaveChanges();

                return new ServiceResponse<ApplicationUser>
                {
                    Data = user,
                    Time = DateTime.UtcNow,
                    Messsage = "User updated",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<ApplicationUser>
                {
                    Data = user,
                    Time = DateTime.UtcNow,
                    Messsage = "Error in updating User",
                    IsSuccess = false
                  };
              }
        }
    }
}
