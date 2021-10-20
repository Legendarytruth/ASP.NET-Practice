using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCApplication.Models;

namespace MVCApplication.DataAccess
{
    public class RouxAcademyDbContext: DbContext
    {
        public RouxAcademyDbContext() : base("RouxAcademyDatabase")
        {

        }
        public DbSet<Course> Courses { get; set; }
    }
}