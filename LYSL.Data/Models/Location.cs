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
        public int id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        // Location time 있으면 좋을듯?

        public virtual ApplicationUser applicationUser { get; set; }
    }
}
