using LYSL.Data.Models;
using System.Collections.Generic;

namespace LYSL.Services.Petervice
{
    public interface IPetervice
    {
        List<Pet> GetAllPet();
        ServiceResponse<Pet> GetPetById(int id);

        ServiceResponse<Pet> DeletePet(Pet pet);
        ServiceResponse<Pet> DeletePetById(int id);
        ServiceResponse<Pet> CreatePet(Pet pet);
        ServiceResponse<Pet> UpdatePet(Pet pet);
    }
}
