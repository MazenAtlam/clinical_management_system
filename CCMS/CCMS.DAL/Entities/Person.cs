using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CCMS.DAL.Entities
{
    public abstract class Person : Base
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FName { get; set; }

        [MaxLength(50)]
        public string MidName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LName { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 14)] 
        public string SSN { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        public PersonType PType { get; set; }
    }
}
