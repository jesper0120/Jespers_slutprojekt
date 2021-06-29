using Jespers_slutprojekt.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jespers_slutprojekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<CoursesAndTreatments> coursesAndTreatments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
