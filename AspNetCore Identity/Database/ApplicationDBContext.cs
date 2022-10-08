using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityAPI.Database
{
    public class ApplicationDBContext : IdentityDbContext
    {
        
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> configure) : base(configure) 
        {}


    }
}