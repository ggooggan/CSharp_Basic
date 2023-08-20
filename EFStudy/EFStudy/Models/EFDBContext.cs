using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Models
{
    public class EFDBContext : DbContext
    {
        //DbSet 설정
        public DbSet<Class>? Classes { get; set; }
        public DbSet<School>? Schools { get; set; }
        public DbSet<Student>? Students { get; set; }



        public EFDBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQLite일때//
            string path = Path.Combine(Environment.CurrentDirectory, "Classes.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Class class1 = new Class { Name = "Class 01", Id = 1, SchoolID = 123 };
            Class class2 = new Class { Name = "Class 02", Id = 2 };
            Class class3 = new Class { Name = "Class 03", Id = 3 };

            Student student01 = new Student { Name = "Student 01", Age = 1, ClassId = 1, Id = 1 };
            Student student02 = new Student { Name = "Student 02", Age = 2, ClassId = 2, Id = 2 };
            Student student03 = new Student { Name = "Student 03", Age = 3, ClassId = 3, Id = 3 };

            School school01 = new School { Name = "School01", Id = 1 };
            School school02 = new School { Name = "School02", Id = 2 };
            School school03 = new School { Name = "School03", Id = 3 };

            modelBuilder.Entity<Class>().HasData(class1, class2, class3);
            modelBuilder.Entity<Student>().HasData(student01, student02, student03);
            modelBuilder.Entity<School>().HasData(school01, school02, school03);

            modelBuilder.Entity<Class>()
                .HasMany(c => c.Students)
                .WithOne(s => s.Class);

            modelBuilder.Entity<School>()
                .HasMany(s => s.Classes)
                .WithOne(c => c.School)
                .HasForeignKey(s => s.SchoolID);

        }
    }
}
