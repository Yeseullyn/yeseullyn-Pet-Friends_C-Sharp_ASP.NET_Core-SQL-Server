using LYSL.Data.Models;
using System.Collections.Generic;

namespace LYSL.Services.PetService
{
    public interface IPetService
    {
        List<Pet> GetAllPets();
        Pet GetPetById(int id);

        ServiceResponse<Pet> DeletePet(Pet pet);
        ServiceResponse<Pet> DeletePetById(int id);
        ServiceResponse<Pet> CreatePet(Pet pet);
        ServiceResponse<Pet> UpdatePet(Pet pet);
    }
}
