using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace IndeavorChallenge.Models
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}