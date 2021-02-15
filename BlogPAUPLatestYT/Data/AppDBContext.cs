using BlogPAUPLatestYT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPAUPLatestYT.Data
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext>options)
            :base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        //public DbSet<SmjeroviFaksa> SmjeroviFaksas { get; set; }
        
        
        
    }
}
