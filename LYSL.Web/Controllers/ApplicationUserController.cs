using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LYSL.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LYSL.Web.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly IApplicaionUser _user;

        //빨간줄이 왜뜰까? user에 마우스호버링 해서 알아보기
        //힌트 : 왜 type을 컨버트 할 수 없다고 나올까?
        //힌트2 : 파일 경로 자세히 보기
        public ApplicationUserController(IApplicationUser user)
        {
            _user = user;
        }

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
            var user = _user.GetUserById(UserId); GetUserById(UserId)

            return Ok(pet);
        }

        [HttpDelete("/pet/{id}", Name = "DeletePetById")]
        public IActionResult DeletePetById(int id)
        {
            var pet = _pet.DeletePetById(id);

            return Ok(pet);
        }

        [HttpPut("/pet/{id}", Name = "UpdatePetById")]
        public IActionResult UpdatePetById([FromBody] Pet pet)
        {
            var updatedPet = _pet.UpdatePet(pet);

            return Ok(updatedPet);
        }
    }

    internal interface IApplicaionUser
    {
        object GetAllUsers();
    }
}