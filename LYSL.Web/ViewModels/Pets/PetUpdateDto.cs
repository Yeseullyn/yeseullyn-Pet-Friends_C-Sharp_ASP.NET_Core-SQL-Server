using System.ComponentModel.DataAnnotations;

namespace LYSL.Web.ViewModels.Pet
{
    public class PetUpdateDto
    {
        public int Id { get; set; }
        public string Breed { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public bool IsNeutralized { get; set; }
        public string SerialNumber { get; set; }
    }
}
