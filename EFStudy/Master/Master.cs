using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace Master
{
    [Table("SlotTable")]
    public class Slot
    {
        [Key]
        public int Num { get; set; }

        public string InputData { get; set; }

        public int TypeId { get; set; } // Foreign key property

        [ForeignKey("TypeId")]
        public Type Type { get; set; }
    }

    [Table("TypeTable")]
    public class Type
    {
        [Key]
        public int Num { get; set; }

        public string Gram { get; set; }

        public ICollection<Slot>? Slots { get; set; }

        // Remove Result property from Type
    }

    public class Result
    {
        [Key]
        public int Num { get; set; }

        public string ResultData { get; set; }

        public int TypeId { get; set; } // Foreign key property

        [ForeignKey("TypeId")]
        public Type Type { get; set; }
    }

    public class TotalClass : DbContext
    {
        // DbSet
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Type> Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "sampleInfo.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slot>().HasData(
                new Slot() { Num = 1, InputData = "1", TypeId = 1 },
                new Slot() { Num = 2, InputData = "2", TypeId = 2 },
                new Slot() { Num = 3, InputData = "3", TypeId = 13 }
            );

            modelBuilder.Entity<Type>().HasData(
                new Type() { Num = 1, Gram = "GN" },
                new Type() { Num = 2, Gram = "GP" },
                new Type() { Num = 13, Gram = "GN" }
            );

            modelBuilder.Entity<Result>().HasData(
                new Result() { Num = 1, ResultData = "Complete", TypeId = 1 },
                new Result() { Num = 2, ResultData = "Broth", TypeId = 2 },
                new Result() { Num = 3, ResultData = "Heating", TypeId = 13 }
            );

            modelBuilder.Entity<Slot>()
                .HasOne(s => s.Type)
                .WithMany(t => t.Slots);

            modelBuilder.Entity<Slot>()
                .HasOne(s => s.Type)
                .WithMany(t => t.Slots)
                .HasForeignKey(s => s.TypeId) // Explicitly define the foreign key property

                .IsRequired(); // Indicate that the foreign key is required

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Type)
                .WithMany()
                .HasForeignKey(r => r.TypeId) // Explicitly define the foreign key property

                .IsRequired(); // Indicate that the foreign key is required
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
