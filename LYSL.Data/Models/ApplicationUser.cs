using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LYSL.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        ///상속받은 IdentityUser 클래스 안에 UserId에 해당하는 property 있는지 확인. 
        ///들어갈때는 컨트롤 마우스 클릭으로
        /// </summary>
        //public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }


        // List 사용법 단순공부X 숙지 (언제든 쓸수 있게)
        // Generic T 란 문엇일까? 어떻게 쓰는걸까? 숙지!

        public virtual List<Pet> Pets { get; set; }
    }
}
