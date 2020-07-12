using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LYSL.Data.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        public string Breed { get; set; }
        public int Size { get; set; }
        public int Age { get; set; }
        // Bool type이란?
        public bool IsNeutralized { get; set; }
        public string SerialNumber { get; set; }

        //Foregin Key
        public virtual ApplicationUser User { get; set; }
    }
}
