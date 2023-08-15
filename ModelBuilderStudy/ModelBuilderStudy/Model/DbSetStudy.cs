using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelBuilderStudy.Model2
{
    public class Score
    {
        public int ScoreId { get; set; }
        public string? ScoreName { get; set; }

    }

    [Table("AAAA")]
    public class Student
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }

        [NotMapped]
        public string ab { get; set; }  

    }

    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        [StringLength(60)]
        public string? CourseName { get; set; }

    }

    public class Classes : DbContext
    {
        public DbSet<Student>? Students { get; set; }
        public DbSet<Course>? Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQLite일때//
            string path = Path.Combine(Environment.CurrentDirectory, "Classes.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(s => s.StudentName).HasMaxLength(30).IsRequired();

            Student student1 = new() { StudentId = 1, StudentName = "홍길동" , ab="123"};
            Student student2 = new() { StudentId = 2, StudentName = "홍길순" , ab="345"};
            Student student3 = new() { StudentId = 3, StudentName = "홍길석", ab = "123" };

            Course csharp1 = new() { CourseId = 1, CourseName = "수학" };
            Course csharp2 = new() { CourseId = 2, CourseName = "과학" };
            Course csharp3 = new() { CourseId = 3, CourseName = "영어" };

            Score score1 = new() { ScoreId = 1, ScoreName = "C" };
            Score score2 = new() { ScoreId = 2, ScoreName = "Z" };

            modelBuilder.Entity<Student>().HasData(student1, student2, student3);
            modelBuilder.Entity<Course>().HasData(csharp1, csharp2, csharp3);
            modelBuilder.Entity<Score>().HasData(score1, score2);
          
        }
    }
}

