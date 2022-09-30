using IB.Data;
using IB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IB.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private DbSet<ApplicationUser> entities;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
            entities = _context.Set<ApplicationUser>();
        }
        public IActionResult Index()
        {
            string userId=User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this.Get(userId);
            var exams = user.Exams.StudentExams.ToList();
            return View(exams);
        }
        public ApplicationUser Get(string id)
        {
            return entities
               .Include(z => z.Exams)
               .Include("Exams.StudentExams")
               .Include("Exams.StudentExams.Exam")
               .SingleOrDefault(s => s.Id == id);
        }
    }
}
