using AutoMapper;
using LYSL.Data.Models;
using LYSL.Web.ViewModels.Pet;

namespace LYSL.Web.Mapper
{
    public class PetMapper : Profile
    {
        public PetMapper()
        {
            CreateMap<Pet, PetViewModel>().ReverseMap();
            CreateMap<PetCreateDto, Pet>();
        }

        //public int Id { get; set; }
        //public string Breed { get; set; }
        //public int Size { get; set; }
        //public int Age { get; set; }
        //public bool IsNeutralized { get; set; }
        //public string SerialNumber { get; set; }

        //public virtual Location Location { get; set; }
        //public virtual ApplicationUser User { get; set; }
    }
}
