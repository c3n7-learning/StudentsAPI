using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentsAPI.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Surname { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string AdmissionNumber { get; set; }

        [Required]
        [Column(TypeName = "integer")]
        public int ClassStreamId { get; set; }

        public ClassStream? ClassStream { get; set; }
    }
}
