using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LYSL.Data.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public int Age { get; set; }
        // Bool type이란?
        [Required]
        public bool IsNeutralized { get; set; }
        [Required]
        public string SerialNumber { get; set; }

        public virtual Location Location { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
