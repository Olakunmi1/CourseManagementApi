using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.WriteDTO
{
    public class AuthorDTOW
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime dateOfBirth { get; set; }

        [Required]
        public string MainCategory { get; set; }

        public ICollection<createCourseForAuthorDTOW> Courses { get; set; }
        = new List<createCourseForAuthorDTOW>();

    }
}
