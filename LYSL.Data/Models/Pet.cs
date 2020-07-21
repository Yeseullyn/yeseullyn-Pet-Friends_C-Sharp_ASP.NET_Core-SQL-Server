using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LYSL.Data.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Breed { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        // Bool type이란?
        public bool IsNeutralized { get; set; }
        public string SerialNumber { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }
        
        public virtual Location Location { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
