﻿using LYSL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LYSL.Web.ViewModels.Pets
{
    public class PetViewModel
    {
        public int Id { get; set; }
        public string Breed { get; set; }
        public int Size { get; set; }
        public int Age { get; set; }
        public bool IsNeutralized { get; set; }
        public string SerialNumber { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
