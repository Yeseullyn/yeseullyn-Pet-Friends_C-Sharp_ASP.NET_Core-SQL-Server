using System.ComponentModel.DataAnnotations;

namespace LYSL.Web.ViewModels.Pet
{
    public class PetCreateDto
    {
        [Required]
        public string Breed { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public bool IsNeutralized { get; set; }
        [Required]
        public string SerialNumber { get; set; }
    }
}
