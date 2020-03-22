using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University_Core_MVC.Models;

namespace University_Core_MVC.Data
{
    public class University_Core_DbContext : DbContext
    {
        public University_Core_DbContext (DbContextOptions<University_Core_DbContext> options)
            : base(options)
        {
        }

        public DbSet<University_Core_MVC.Models.Allocation> Allocation { get; set; }

        public DbSet<University_Core_MVC.Models.Department> Department { get; set; }

        public DbSet<University_Core_MVC.Models.Lecturer> Lecturer { get; set; }

        public DbSet<University_Core_MVC.Models.Module> Module { get; set; }
    }
}
