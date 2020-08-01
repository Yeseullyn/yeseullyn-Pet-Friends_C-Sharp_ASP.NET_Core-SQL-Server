using AutoMapper;
using LYSL.Data.Models;
using LYSL.Services.Petervice;
using LYSL.Web.ViewModels.Pet;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        public PetListDto GetAllPets()
        {
            var petList = _pet.GetAllPet();

            return new PetListDto
            {
                PetViewList = petList.Select(pet => new PetDto
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
        public IActionResult GetPetById(int id) // Id를 못받네?
        {
            var pet = _pet.GetPetById(id).Data; // 그냥 타이포였던걸로..

            if (pet != null)
            {
                var viewModel = new PetDto
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
                return View(viewModel);
            }
            else
            {
                return BadRequest();
            }
        }

        //[HttpDelete("/pet/DeletePetById/{id}", Name = "DeletePetById")]
        public ActionResult DeletePetById(PetDto model)
        {
            if (model != null)
            {
                _pet.DeletePetById(model.Id);
                return RedirectToAction("Index");
            }

            return BadRequest();
        }

        [HttpPut("/pet/{id}", Name = "UpdatePetById")]
        public IActionResult UpdatePetById([FromBody]Pet pet)
        {
            var updatedPet = _pet.UpdatePet(pet);

            return Ok(updatedPet);
        }

        /// <summary>
        /// 계속해서 FromBody로 해서 문제가 생겼던 것이었음
        /// 415 Error는 media type 에러인데, 이건 endpoint에서 post 하는 타입이 Controller가 받을 수 있는 타입이
        /// 아니라는 것을 의미함(바보멍충이). 그렇기 때문에 Postman을 이용하거나 Javascript JSON으로 POST 하는 경우
        /// ([FromBody] ; 자바스트림트는 body에 데이터를 담아 전달하기 때문) Frombody가 맞지만 지금처럼 Razor로
        /// ASP를 쓰는 경우에는 FromForm을 써야함
        /// </summary>
        /// <param name="petCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<PetCreateDto> CreatePet([FromForm] PetCreateDto petCreateDto)
        {
            var createdPet = _mapper.Map<Pet>(petCreateDto);
            var result = _pet.CreatePet(createdPet);

            var readPet = _mapper.Map<PetDto>(result.Data);

            //return Ok(createdPet);
            //왜 작동을 안하지?
            //return CreatedAtRoute(nameof(GetPetById), new { Id = readPet.Id }, readPet);
            return RedirectToAction("GetPetById", "Pet", readPet); // 뭔가 이상하지만 일단 진행
        }

        [HttpPost]
        public ActionResult<PetUpdateDto> UpdatePet(PetUpdateDto model)
        {
            var updatedPet = _mapper.Map<Pet>(model);   
            var result = _pet.UpdatePet(updatedPet);

            var readPet = _mapper.Map<PetDto>(result.Data);

            //return Ok(createdPet);
            //return CreatedAtRoute(nameof(GetPetById), new { Id = readPet.Id }, readPet);
            return RedirectToAction("GetPetById", "Pet", readPet); // 뭔가 이상하지만 일단 진행
        }

        public IActionResult CreatePetPage(PetCreateDto model)
        {
            return View(model);
        }

        public IActionResult UpdatePetPage(PetUpdateDto model)
        {
            var dto = _pet.GetPetById(model.Id).Data;
            var updateDto = new PetUpdateDto()
            {
                Id = dto.Id,
                Age = dto.Age,
                Breed = dto.Breed,
                IsNeutralized = dto.IsNeutralized,
                SerialNumber = dto.SerialNumber,
                Weight = dto.Weight
            };

            return View(updateDto);
        }

        public IActionResult DeletePet(PetDto model)
        {
            var pet = _pet.GetPetById(model.Id).Data; // 그냥 타이포였던걸로..

            if (model != null)
            {
                var viewModel = new PetDto
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
                return View(viewModel);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}