using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Xml;

namespace Master
{

    public class InputName
    {
        [Key]
        public int Num { get; set; }

        public string? InputData { get; set; }

        public InputType? InputType { get; set; }

        //[ForeignKey("Result")]
        //public int ResultFK { get; set; }
        //public Result Result { get; set; }
    }

    public class InputType
    {
        [Key]
        public int Num { get; set; }

        public string? Gram { get; set; }

        [ForeignKey(nameof(InputName))]
        public int InputNameId { get; set; }
        public InputName? InputName { get; set; }

        public Result Result { get; set; }
    }

    public class Result
    {
        [Key]
        public int Num { get; set; }

        public string? ResultData { get; set; }

        [ForeignKey("InputType")]
        public int InputTypeNum { get; set; } // 외래키
        public InputType? InputType { get; set; } // 네비게이터
    }

    public class TotalClass : DbContext
    {
        // DbSet
        public DbSet<InputName> InputNames { get; set; }
        public DbSet<InputType> InputTypes { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "sampleInfo.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<InputName>().HasData(
               new InputName() { Num = 1, InputData = "1" },
               new InputName() { Num = 2, InputData = "2" },
               new InputName() { Num = 3, InputData = "3" }
           );

            modelBuilder.Entity<InputType>().HasData(
                new InputType() { Num = 1, Gram = "GN", InputNameId = 1 },
                new InputType() { Num = 2, Gram = "GP", InputNameId = 2 },
                new InputType() { Num = 3, Gram = "GN", InputNameId = 3 }
            );

            modelBuilder.Entity<Result>().HasData(
                new Result() { Num = 1, ResultData = "Complete", InputTypeNum = 1 },
                new Result() { Num = 2, ResultData = "Broth", InputTypeNum = 2 },
                new Result() { Num = 3, ResultData = "Heating", InputTypeNum = 13 }
            );

            // ---
            modelBuilder.Entity<InputName>()
               .HasOne(ipn => ipn.InputType)
               .WithOne(ipt => ipt.InputName);

            modelBuilder.Entity<InputType>()
                .HasOne(ipt => ipt.InputName)
                .WithOne(ipn => ipn.InputType);
            //---

            modelBuilder.Entity<InputType>()
              .HasOne(ipt => ipt.Result)
              .WithOne(r => r.InputType);

            modelBuilder.Entity<Result>()
             .HasOne(r => r.InputType)
             .WithOne(ipt => ipt.Result);
        }
    }

    public class Master
    {
        public Master()
        {

        }

        public void Create()
        {
            using (var context = new TotalClass())
            {
                bool deleted = context.Database.EnsureDeleted();
                bool created = context.Database.EnsureCreated();
            }
        }
    }
}
