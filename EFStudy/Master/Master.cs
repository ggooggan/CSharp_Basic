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

        [ForeignKey("InputType")]
        public int InputTypeNum { get; set; }

        public InputType InputType { get; set; }
    }

    public class InputType
    {
        [Key]
        public int Num { get; set; }

        public string? Gram { get; set; }

        [ForeignKey("InputName")]
        public int InputNameId { get; set; }
        public ICollection<InputName>? InputNames { get; set; }
    }


    public class TotalClass : DbContext
    {
        // DbSet
        public DbSet<InputName> InputNames { get; set; }
        public DbSet<InputType> InputTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "sampleInfo.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<InputName>().HasData(
               new InputName() { Num = 1, InputData = "1", InputTypeNum = 1 },
               new InputName() { Num = 2, InputData = "2", InputTypeNum = 2 },
               new InputName() { Num = 3, InputData = "3", InputTypeNum = 3 }
           );

            modelBuilder.Entity<InputType>().HasData(
                new InputType() { Num = 1, Gram = "GN", InputNameId = 1, },
                new InputType() { Num = 2, Gram = "GP", InputNameId = 1 },
                new InputType() { Num = 3, Gram = "GN", InputNameId = 3 }
            );


            // ---
            modelBuilder.Entity<InputName>()
               .HasOne(ipn => ipn.InputType)
               .WithMany(ipt => ipt.InputNames);

            modelBuilder.Entity<InputType>()
                .HasMany(ipt => ipt.InputNames)
                .WithOne(ipn => ipn.InputType);
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
