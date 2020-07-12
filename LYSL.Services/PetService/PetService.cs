using LYSL.Data.Models;
using LYSL.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LYSL.Services.PetService
{
    public class PetService : IPetService
    {
        private readonly ApplicationDbContext _db;

        public PetService(ApplicationDbContext db)
        {
            _db = db;
        }

        public ServiceResponse<Pet> CreatePet(Pet pet)
        {
            try
            {
                var newPet = new Pet
                {
                    //Id = pet.Id,
                    Age = pet.Age,
                    Breed = pet.Breed,
                    IsNeutralized = pet.IsNeutralized,
                    SerialNumber = pet.SerialNumber,
                    Size = pet.Size,
                    User = pet.User
                };

                _db.Pets.Add(newPet);
                _db.SaveChanges();

                return new ServiceResponse<Pet>
                {
                    Data = pet,
                    Time = DateTime.UtcNow,
                    Messsage = "New pet added",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Pet>
                {
                    Data = pet,
                    Time = DateTime.UtcNow,
                    Messsage = "Pet is not added",
                    IsSuccess = false
                };
            }
        }

        public Pet GetPetById(int id) 
        {
            return _db.Pets.Find(id);
        }

        public List<Pet> GetAllPets()
        {
            return _db.Pets.ToList();
        }
    }
}
