using AutoMapper;
using LYSL.Data.Models;
using LYSL.Services;
using LYSL.Services.PetService;
using LYSL.Web.Models;
using LYSL.Web.ViewModels.Pets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace LYSL.Web.Controllers
{
    //[ApiController]
    public class PetController : Controller
    {
        private readonly IPetService _pet;
        private readonly IMapper _mapper;

        public PetController(IPetService pet, IMapper mapper)
        {
            _pet = pet;
            _mapper = mapper;
        }

        public PetListViewModel GetAllPets()
        {
            var petList = _pet.GetAllPets();

            return new PetListViewModel
            {
                PetViewList = petList.Select(pet => new PetViewModel
                {
                    Id = pet.Id,
                    Age = pet.Age,
                    Location = pet.Location,
                    Breed = pet.Breed,
                    ApplicationUser = pet.User,
                    IsNeutralized = pet.IsNeutralized,
                    SerialNumber = pet.SerialNumber,
                    Weight = pet.Weight
                })
            };
        }

        public IActionResult Index()
        {
            var viewModel = GetAllPets();
            return View(viewModel);
        }

        [HttpGet("/pet/{id}", Name = "GetPetById")]
        public IActionResult GetPetById(int id)
        {
            var pet = _pet.GetPetById(id).Data;

            if (pet != null)
            {
                var model = new PetViewModel
                {
                    Id = pet.Id,
                    Age = pet.Age,
                    Breed = pet.Breed,
                    Weight = pet.Weight,
                    SerialNumber = pet.SerialNumber,
                    IsNeutralized = pet.IsNeutralized,
                    ApplicationUser = pet.User,
                    Location = pet.Location
                };
                return View(model);
            }
            else
            {
                return BadRequest();
            }
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

        [HttpPost("/pet")]
        public IActionResult CreatePet([FromBody] Pet pet)
        {
            var createdPet = _pet.CreatePet(pet);

            return Ok(createdPet);
        }
    }
}