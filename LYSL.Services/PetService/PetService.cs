using LYSL.Data.Models;
using LYSL.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LYSL.Services.Petervice
{
    public class Petervice : IPetervice
    {
        private readonly ApplicationDbContext _db;

        public Petervice(ApplicationDbContext db)
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
                    Weight = pet.Weight,
                    User = pet.User
                };

                //var result = _db.Pet.Add(newPet);
                _db.Pet.Add(newPet);
                _db.SaveChanges();

                return new ServiceResponse<Pet>
                {
                    Data = newPet,
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

        public ServiceResponse<Pet> GetPetById(int id) 
        {
            var pet = _db.Pet.Find(id);

            try
            {
                return new ServiceResponse<Pet>
                {
                    Data = pet,
                    Time = DateTime.UtcNow,
                    Messsage = "Get pet data success.",
                    IsSuccess = false
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Pet>
                {
                    Data = pet,
                    Time = DateTime.UtcNow,
                    Messsage = "Get pet data failed.",
                    IsSuccess = false
                }; ;
            }
        }

        public List<Pet> GetAllPet()
        {
            return _db.Pet.ToList();
        }

        public ServiceResponse<Pet> DeletePet(Pet pet)
        {
            try
            {
                _db.Pet.Remove(pet);
                _db.SaveChanges();

                return new ServiceResponse<Pet>
                {
                    Data = null,
                    IsSuccess = true,
                    Messsage = "Pet data is deleted",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception)
            {
                return new ServiceResponse<Pet>
                {
                    Data = null,
                    IsSuccess = false,
                    Messsage = "Error in deleting pet",
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<Pet> DeletePetById(int id)
        {
            try
            {
                var pet = GetPetById(id);
                _db.Remove(pet.Data);
                _db.SaveChanges();
                return new ServiceResponse<Pet>
                {
                    Data = null,
                    IsSuccess = true,
                    Messsage = "Pet data is deleted",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e) 
            {
                return new ServiceResponse<Pet>
                {
                    Data = null,
                    IsSuccess = false,
                    Messsage = $"Error in deleting pet : {e}",
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<Pet> UpdatePet(Pet pet)
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
                    Weight = pet.Weight,
                    User = pet.User
                };

                _db.Pet.Update(newPet);
                _db.SaveChanges();

                return new ServiceResponse<Pet>
                {
                    Data = pet,
                    Time = DateTime.UtcNow,
                    Messsage = "Pet updated",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Pet>
                {
                    Data = pet,
                    Time = DateTime.UtcNow,
                    Messsage = "Error in updating pet",
                    IsSuccess = false
                };
            }
        }
    }
}
