using IB.Data;
using IB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IB.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private DbSet<ApplicationUser> entities;
        private DbSet<StudentExam> exams1;
        public TeacherController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            entities = _context.Set<ApplicationUser>();
            exams1 = _context.Set<StudentExam>();
        }
        public async Task<IActionResult> Index()
        {
            var allUsers = await _userManager.GetUsersInRoleAsync("Student");
            return View(allUsers.ToList());
        }
        public IActionResult AddExam(string id)
        {
            ViewBag.StudentId= id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddExm([Bind("Id,Teacher,Subject,Grade,Date")] Exam exam, string StudentId)
        {

            if (ModelState.IsValid)
            {
                _context.Add(exam);
                await _context.SaveChangesAsync();
                var student = this.Get(StudentId);
                var exams = student.Exams;
                if (!exam.Id.Equals(null) && exams != null)
                {
                    if (exam != null)
                    {
                        StudentExam itemToAdd = new StudentExam
                        {
                            Id = new int(),
                            Exam = exam,
                            ExamId = exam.Id,
                            Exams = exams,
                            ExamsId = exams.Id,
                        };
                        exams1.Add(itemToAdd);
                        _context.SaveChanges();
                        return RedirectToAction("Index", "Teacher");
                    }
                    return RedirectToAction("Index", "Teacher");
                }
                return RedirectToAction("Index", "Teacher");
            }
                return RedirectToAction("Index", "Teacher");
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
