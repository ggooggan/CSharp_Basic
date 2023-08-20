using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Models
{
    [Table("class")]
    public class Class
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("school_id")]
        public int SchoolID { get; set; }

        [ForeignKey("SchoolId")]
        public virtual School? School { get; set; }

        public virtual ICollection<Student>? Students { get; set; }
    }
}
