using Login.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.API.Data
{
    public class LoginContext : IdentityDbContext<ApplicationUser>
    {
        public LoginContext(DbContextOptions<LoginContext> options)
            : base(options)
        {

        }
    }
}
