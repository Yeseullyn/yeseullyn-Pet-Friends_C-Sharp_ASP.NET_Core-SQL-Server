using LYSL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LYSL.Web.ViewModels.Pet
{
    public class PetDto
    {
        public int Id { get; set; }
        public string Breed { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public bool IsNeutralized { get; set; }
        public string SerialNumber { get; set; }

        public virtual Location Location { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
