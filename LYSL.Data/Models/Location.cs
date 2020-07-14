using System;
using System.Collections.Generic;
using System.Text;

namespace LYSL.Data.Models
{
    public class Location
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public ApplicationUser applicationUser { get; set; }
    }
}
