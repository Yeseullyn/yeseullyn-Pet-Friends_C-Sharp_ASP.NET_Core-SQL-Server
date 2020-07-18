using LYSL.Data.Models;
using LYSL.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace LYSL.Web.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly IApplicationUser _user;

        public ApplicationUserController(IApplicationUser user)
        {
            _user = user;
        }

        //빨간줄이 왜뜰까? user에 마우스호버링 해서 알아보기
        //힌트 : 왜 type을 컨버트 할 수 없다고 나올까?
        //힌트2 : 파일 경로 자세히 보기

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/user")]
        public IActionResult GetAllUsers()
        {
            var users = _user.GetAllUsers();

            return Ok(users);
        }

        // 아래는 아직 신경 못써서 한듯? 구현 해보기
        [HttpGet("/user/{id}", Name = "GetUserById")]
        public IActionResult GetUserById(int UserId)
        {
            var user = _user.GetUserById(UserId);

            return Ok(user);
        }

        [HttpDelete("/user/{id}", Name = "DeleteUserById")]
        public IActionResult DeleteUserById(int UserId)
        {
            var user = _user.DeleteUserById(UserId);

            return Ok(user);
        }

        [HttpPut("/user/{id}", Name = "UpdateUserById")]
        public IActionResult UpdateUserById([FromBody] ApplicationUser user)
        {
            var updatedUser = _user.UpdateUser(user);

            return Ok(updatedUser);
        }
    }
}