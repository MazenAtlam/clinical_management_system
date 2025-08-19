using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("Person_PhoneNumber", Schema="ccms")]
    [PrimaryKey("PersonId", "Number")]
    public class PhoneNumber : Base
    {
        [Required]
        [ForeignKey("Person")]
        public string PersonId { get; private set; }
        public virtual Person Person { get; private set; }
        [Required]
        [MinLength(11)]
        [MaxLength(20)]
        public string Number { get; private set; }

        //public PhoneNumber() : base() { }
        public PhoneNumber(string personId, string number, string createdBy)
            : base(createdBy)
            => Set(personId, number);

        private void Set(string personId, string number)
        {
            PersonId = personId;
            Number = number;
        }

        public void Edit(string personId, string number, string modifiedBy)
        {
            Set(personId, number);
            SaveModification(modifiedBy);
        }
    }
}
