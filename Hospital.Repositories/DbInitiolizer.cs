using Hospital.Libraries;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hospital.Models;
namespace Hospital.Repositories
{
    public class DbInitiolizer : IDbInitiolizer
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private HospitalDbContext _context;
        public DbInitiolizer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, HospitalDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        //handle Exceptions to Db Context
        public void Initialize()
        {
            try
            {
                if(_context.Database.GetPendingMigrations().Count()>0)
                {
                    _context.Database.Migrate();
                }
            }catch(Exception)
            {
                throw;
            }
            if(!_roleManager.RoleExistsAsync(Roles.Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(Roles.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Roles.Patient)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Roles.Doctor)).GetAwaiter().GetResult();
            }
        }
    }
}
