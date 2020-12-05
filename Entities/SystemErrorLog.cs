using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.Entities
{
    public class SystemErrorLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Transdate { get; set; }
        [Required]
        public string error_messg { get; set; } //come form the ex 
        [Required]
        public string error_source { get; set; }
    }
}
