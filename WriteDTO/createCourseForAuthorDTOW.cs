using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.WriteDTO
{
    public class createCourseForAuthorDTOW
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Title { get; set; }

       // public int AuthorId { get; set; }
    }
}
