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
    }

    class Program
    {
        public void TEST()
        {
            using (var context = new SchoolDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Department 추가
                var department = new Department
                {
                    Name = "Computer Science"
                };
                context.Departments.Add(department);
                var department01 = new Department
                {
                    Name = "Out Side Science"
                };
                context.Departments.Add(department01);


                // Student 추가
                var student1 = new Student
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Age = 20,
                    Department = department // 외래 키 설정
                };
                context.Students.Add(student1);

                var student2 = new Student
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Age = 22,
                    Department = department // 외래 키 설정
                };
                context.Students.Add(student2);

                var student3 = new Student
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Age = 22,
                    Department = department01 // 외래 키 설정
                };
                context.Students.Add(student3);

                context.SaveChanges();
            }
        }
    }
}
