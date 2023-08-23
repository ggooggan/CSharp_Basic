using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System;

namespace YourNamespace
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        public string Name { get; set; }

        public ICollection<Student> Students { get; set; } // 역방향 내비게이션 속성
    }

    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; } // 외래 키
        public Department Department { get; set; } // 내비게이션 속성
    }

    public class SchoolDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databasePath = Path.Combine(Environment.CurrentDirectory, "school.db");
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Department 추가
            var department01 = new Department
            {
                Name = "Computer Science",
                DepartmentID = 1
            };
            var department02 = new Department
            {
                Name = "Out Side Science",
                DepartmentID = 2
            };

            var student01 = new Student
            {
                StudentID = 1,
                FirstName = "John",
                LastName = "Doe",
                Age = 20,
                DepartmentId = department01.DepartmentID // 외래 키 설정
            };

            var student02 = new Student
            {
                StudentID = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Age = 22,
                DepartmentId = department01.DepartmentID // 외래 키 설정
            };

            var student03 = new Student
            {
                StudentID = 3,
                FirstName = "Jane",
                LastName = "Smith",
                Age = 22,
                DepartmentId = department02.DepartmentID // 외래 키 설정
            };

            modelBuilder.Entity<Department>().HasData(department01, department02);
            modelBuilder.Entity<Student>().HasData(student01, student02, student03);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId);
        }
    }

    class Program
    {
        public void TEST()
        {
            using (var context = new SchoolDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var department_ = context.Departments
                        .Include(d => d.Students) // Students 내비게이션 속성 로드
                        .FirstOrDefault(d => d.DepartmentID == 2);
                var studentsInDepartment = department_.Students.ToList();

                foreach (var value in studentsInDepartment)
                {
                    Console.WriteLine(value.StudentID.ToString());
                }
            }
        }
    }
}
