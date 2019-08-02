using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlueBusiness.Models;

namespace BlueBusiness.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Tags> Tags { get; set; }

        public DbSet<Blogs> Blogs { get; set; }

        public DbSet<Jobs> Jobs { get; set; }

        public DbSet<Applications> Applications { get; set; }
    }
}
