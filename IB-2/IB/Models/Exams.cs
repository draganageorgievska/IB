using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IB.Models
{
    public class Exams
    {
        [Key]
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser AppUser { get; set; }
        public virtual ICollection<StudentExam> StudentExams { get; set; }
    }
}
