using Microsoft.EntityFrameworkCore;
using ModelBuilderStudy.Model2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

public class Student
{
    public int StudentID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public int DepartmentId { get; set; } // 외래 키
    public Department Department { get; set; } // 내비게이션 속성
}

public class Department
{
    public int DepartmentID { get; set; }
    public string Name { get; set; }

    public Student Students { get; set; } // 역방향 내비게이션 속성
}


public class ApplicationDbContext : DbContext
{
    public DbSet<Student>? Students { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // SQLite일때//
        string path = Path.Combine(Environment.CurrentDirectory, "ApplicationDBContext.db");
        optionsBuilder.UseSqlite($"Filename={path}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Student 엔터티와 Department 엔터티의 관계 설정
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Department) // Student 엔터티가 Department 엔터티와 일대다 관계 설정
            .WithOne(d => d.Students); // Department 엔터티가 Students 내비게이션 속성을 가지고 있음을 설정 (역방향 관계)
    }
}

public class DBConextStudy
{
    ApplicationDbContext _context = new ApplicationDbContext();

    public DBConextStudy()
    {
        {
            //기존 DB가 존재할 경우 삭제
            bool deleted = _context.Database.EnsureDeleted();

            //Model로 부터 DB를 만들고 필요한 SQL Script를 생성
            bool created = _context.Database.EnsureCreated();

            
            // 학과 추가
            var department = new Department { Name = "Computer Science" };
            _context.Departments.Add(department);
            _context.SaveChanges();

            // 학생 추가
            var student = new Student
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 20,
                DepartmentId = department.DepartmentID // 학생을 위에서 추가한 학과에 소속시킴
            };
            _context.Students.Add(student);
            _context.SaveChanges();

            var updateField = _context.Students.Find(1);
            updateField.Age = 150;
            _context.SaveChanges();

            // 학생 정보 조회
            var retrievedStudent = _context.Students
            .Include(s => s.Department) // 내비게이션 속성을 로드하기 위해 Include 사용
            .FirstOrDefault();

            Console.WriteLine($"Student Name: {retrievedStudent?.FirstName} {retrievedStudent?.LastName}");
            Console.WriteLine($"Department: {retrievedStudent.Department.Name}");
        }

    }


    public void ReadDBFile()
    {
        {
            _context.Students.Load();

            // 학생 정보 조회
            var retrievedStudent = _context.Students
            .Include(s => s.Department); // 내비게이션 속성을 로드하기 위해 Include 사용


            Console.WriteLine("다시 읽기");
            foreach (var value in retrievedStudent)
            {
                Console.WriteLine(value.FirstName); 
                Console.WriteLine(value.LastName);
            }
            Console.WriteLine("끝");

        }

    }
}
