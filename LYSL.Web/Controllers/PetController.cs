using LYSL.Data.Models;
using LYSL.Services.PetService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

namespace LYSL.Web.Controllers
{
    //[ApiController]
    public class PetController : Controller
    {
        private readonly IPetService _pet;

        public PetController(IPetService pet)
        {
            _pet = pet;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/pet")]
        public IActionResult GetAllPets()
        {
            var pets = _pet.GetAllPets();

            return Ok(pets);
        }

        [HttpGet("/pet/{id}", Name = "GetPetById")]
        public IActionResult GetPetById(int id)
        {
            var pet = _pet.GetPetById(id);

            return Ok(pet);
        }

        [HttpDelete("/pet/{id}", Name = "DeletePetById")]
        public IActionResult DeletePetById(int id)
        {
            var pet = _pet.DeletePetById(id);

            return Ok(pet);
        }

        [HttpPut("/pet/{id}", Name = "UpdatePetById")]
        public IActionResult UpdatePetById([FromBody]Pet pet)
        {
            var updatedPet = _pet.UpdatePet(pet);

            return Ok(updatedPet);
        }
    }
}