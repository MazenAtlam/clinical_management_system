using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("Person_PhoneNumber", Schema="ccms")]
    [PrimaryKey("UID", "Number")]
    public class PhoneNumber : Base
    {
        [Required]
        [ForeignKey("Person")]
        public int UID { get; private set; }
        public Person Person { get; private set; }
        [Required]
        [MinLength(11)]
        [MaxLength(20)]
        public string Number { get; private set; }

        //public PhoneNumber() : base() { }
        public PhoneNumber(int id, string number, string createdBy)
            : base(createdBy)
            => Set(id, number);

        private void Set(int id, string number)
        {
            UID = id;
            Number = number;
        }

        public void Edit(int id, string number, string modifiedBy)
        {
            Set(id, number);
            SaveModification(modifiedBy);
        }
    }
}
