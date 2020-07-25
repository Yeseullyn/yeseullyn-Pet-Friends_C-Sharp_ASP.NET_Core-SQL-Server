using AutoMapper;
using LYSL.Data.Models;
using LYSL.Services;
using LYSL.Services.Petervice;
using LYSL.Web.Models;
using LYSL.Web.ViewModels.Pet;
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
        private readonly IPetervice _pet;
        private readonly IMapper _mapper;

        public PetController(IPetervice pet, IMapper mapper)
        {
            _pet = pet;
            _mapper = mapper;
        }

        public PetListViewModel GetAllPet()
        {
            var petList = _pet.GetAllPet();

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
            var viewModel = GetAllPet();
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
        public ActionResult<PetCreateDto> CreatePet([FromBody] PetCreateDto petCreateDto)
        {
            var createdPet = _mapper.Map<Pet>(petCreateDto);
            var result = _pet.CreatePet(createdPet);

            var readPet = _mapper.Map<PetViewModel>(result.Data);

            //return Ok(createdPet);
            return CreatedAtRoute(nameof(GetPetById), new { Id = readPet.Id }, readPet);
        }

        public IActionResult Create()
        {
            return View(new PetCreateDto());
        }
    }
}