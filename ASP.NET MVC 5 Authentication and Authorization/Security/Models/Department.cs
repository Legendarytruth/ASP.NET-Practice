using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Security.Models
{
    public class Department
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Professor Professor { get; set; }
    }
}