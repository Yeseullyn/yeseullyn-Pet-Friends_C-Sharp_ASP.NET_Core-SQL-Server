using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LYSL.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }

        // List 사용법 단순공부X 숙지 (언제든 쓸수 있게)
        // Generic T 란 문엇일까? 어떻게 쓰는걸까? 숙지!
        public Location location { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
