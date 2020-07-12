using LYSL.Data.Models;
using System.Collections.Generic;

namespace LYSL.Services.PetService
{
    public interface IPetService
    {
        List<Pet> GetAllPets();
        Pet GetPetById(int id);
        ServiceResponse<Pet> CreatePet(Pet pet);
    }
}
