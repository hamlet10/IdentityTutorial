using IdentityTutorial.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTutorial.Context
{
    public class AplicationDbContext : IdentityDbContext<AplicationUser>
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) 
            : base(options)
        {

        }
    }
}
