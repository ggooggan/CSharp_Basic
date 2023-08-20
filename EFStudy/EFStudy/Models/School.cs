using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Models
{
    [Table("school")]
    public class School
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name", TypeName = "VARCHAR")]
        [Required] // Not Null
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        // virtual키워드가 포함된 속성은 가상 속성으로 지정
        // EF에서 지원하는 지우너 로딩 기능을 사용할 수 있음
        public virtual ICollection<Class>? Classes { get; set; }
    }
}
