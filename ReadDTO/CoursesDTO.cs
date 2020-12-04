using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.ReadDTO
{
    public class CoursesDTO
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        //public string AuthorName { get; set; }
    }
}
