using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("Person_Address", Schema = "ccms")]
    [PrimaryKey("PersonId", "address")]
    public class Address : Base
    {
        [Required]
        [ForeignKey("Person")]
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
        [Required]
        [MaxLength(200)]
        public string address { get; private set; }

        //public Address() : base() { }
        public Address(int personId, string address, string createdBy)
            : base(createdBy)
            => Set(personId, address);

        private void Set(int personId, string address)
        {
            PersonId = personId;
            this.address = address;
        }

        public void Edit(int personId, string address, string modifiedBy)
        {
            Set(personId, address);
            SaveModification(modifiedBy);
        }
    }
}
