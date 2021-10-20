using RouxAcademyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RouxAcademyWebApi.Controllers
{
    public class StudentController : ApiController
    {
        List<Student> students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Name = "John Smith",
                Email = "jsmith@rouxacademy.com",
                DateofBirth = new DateTime(1990, 1, 1)
            },
            new Student()
            {
                Id = 2,
                Name = "Jane Will",
                Email = "jWill@rouxacademy.com",
                DateofBirth = new DateTime(1980, 1, 11)
            }
        };


        public IEnumerable<Student> GetStudents()
        {
            return students;
        }
    }
}
