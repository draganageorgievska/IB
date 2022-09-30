using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IB.Models
{
    public class StudentExam
    {
        [Key]
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int ExamsId { get; set; }
        public Exam Exam { get; set; }
        public Exams Exams { get; set; }
    }
}
