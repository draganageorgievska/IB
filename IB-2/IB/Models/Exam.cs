using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IB.Models
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Teacher { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [Range(6, 10, ErrorMessage = "Value for Grade must be between 6 and 10.")]
        public int Grade { get; set; }
        [Required]
        public string Date { get; set; }
        public virtual ICollection<StudentExam> StudentExams { get; set; }
    }
}
