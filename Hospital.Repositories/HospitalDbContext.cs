using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Repositories
{
    public class HospitalDbContext:IdentityDbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options):base(options)
        {

        }
    }
}
