using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CCMS.DAL.Entities
{
    public abstract class Person : Base
    {
        [Key]
        public int Id { get;protected set; }

        [Required]
        [MaxLength(50)]
        public string FName { get;protected set; }

        [MaxLength(50)]
        public string? MidName { get;protected set; }

        [Required]
        [MaxLength(50)]
        public string LName { get;protected set; }

        [Required]
        [StringLength(14, MinimumLength = 14)] 
        public string SSN { get;protected set; }

        [Required]
        public Gender Gender { get;protected set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get;protected set; }

        [Required]
        public PersonType PType { get;protected set; }
    }
}
