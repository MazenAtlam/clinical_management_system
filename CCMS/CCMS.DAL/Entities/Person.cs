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
        public string FName { get; private set; }

        [MaxLength(50)]
        public string MidName { get; private set; }

        [Required]
        [MaxLength(50)]
        public string LName { get; private set; }

        [Required]
        [StringLength(14, MinimumLength = 14)] 
        public string SSN { get; private set; }

        [Required]
        public Gender Gender { get; private set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; private set; }

        [Required]
        public PersonType PType { get; private set; }
    }
}
