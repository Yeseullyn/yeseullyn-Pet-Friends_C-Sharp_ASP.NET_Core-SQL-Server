using System;
using System.Collections.Generic;
using System.Text;
using LYSL.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LYSL.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Location> Location { get; set; }
        //Location DB 셋 추가해주세요
    }
}
