using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.WriteDTO
{
    public class AuthorDTOW
    {
        [Required(ErrorMessage ="You should fill out the firstName field")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName field also required")]
        public string LastName { get; set; }

        [Required]
        public DateTime dateOfBirth { get; set; }

        [Required(ErrorMessage = "You should fill out the mainCategory field")]
        public string MainCategory { get; set; }

        public ICollection<createCourseForAuthorDTOW> Courses { get; set; }
        = new List<createCourseForAuthorDTOW>();

    }
}
