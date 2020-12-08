using CourseApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.ReadDTO
{
    public class AuhtorDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }
       
        public int Age { get; set; }

        public string MainCategory { get; set; }

        public ICollection<Course> Courses { get; set; }
            = new List<Course>();
    }
}
