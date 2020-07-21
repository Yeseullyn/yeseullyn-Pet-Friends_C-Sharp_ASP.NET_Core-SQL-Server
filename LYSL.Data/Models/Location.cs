using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LYSL.Data.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual Pet Pet { get; set; }
    }
}
