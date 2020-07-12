using LYSL.Data.Models;
using LYSL.Services.PetService;
using Microsoft.AspNetCore.Mvc;

namespace LYSL.Web.Controllers
{
    [ApiController]
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
    }
}