using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        
            string connctionstring = @"Server=DESKTOPPC\DEVSQL;Database=StudentSystem;Integrated Security=True";
        
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer (connctionstring);
            }
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Homework> HomeworkSubmissions{ get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().Property(s => s.Name).IsUnicode(true);
            modelBuilder.Entity<Resource>().Property(s => s.Name).IsUnicode(true);
            modelBuilder.Entity<Resource>().Property(s => s.Url).IsUnicode(true);
            modelBuilder.Entity<Course>().Property(s => s.Name).IsUnicode(true);
            modelBuilder.Entity<Course>().Property(s => s.Description).IsUnicode(true);
            modelBuilder.Entity<Student>().Property(s => s.PhoneNumber).IsUnicode(false);
            modelBuilder.Entity<Homework>().Property(s => s.Content).IsUnicode(false);

            modelBuilder
                .Entity<StudentCourse>().HasKey(sc => new
                {
                    sc.StudentId,
                    sc.CourseId
                });
        }
    }
}
