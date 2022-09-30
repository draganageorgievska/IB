using IB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IB.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Exams> Examss { get; set; }
        public virtual DbSet<StudentExam> StudentExams { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Exam>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Exams>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();



            builder.Entity<StudentExam>()
                .HasOne(z => z.Exam)
                .WithMany(z => z.StudentExams)
                .HasForeignKey(z => z.ExamsId);

            builder.Entity<StudentExam>()
                .HasOne(z => z.Exams)
                .WithMany(z => z.StudentExams)
                .HasForeignKey(z => z.ExamId);


            builder.Entity<Exams>()
                .HasOne<ApplicationUser>(z => z.AppUser)
                .WithOne(z => z.Exams)
                .HasForeignKey<Exams>(z => z.ApplicationUserId);
        }
        }
}
