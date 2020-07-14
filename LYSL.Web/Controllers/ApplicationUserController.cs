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