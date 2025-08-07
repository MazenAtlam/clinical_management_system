using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("Person_Address", Schema = "ccms")]
    [PrimaryKey("UID", "address")]
    public class Address : Base
    {
        [Required]
        [ForeignKey("Person")]
        public int UID { get; private set; }
        public Person Person { get; private set; }
        [Required]
        [MaxLength(200)]
        public string address { get; private set; }

        public Address() : base() { }
        public Address(int id, string address, string createdBy)
            : base(createdBy)
            => Set(id, address);

        private void Set(int id, string address)
        {
            UID = id;
            this.address = address;
        }

        public void Edit(int id, string address, string modifiedBy)
        {
            Set(id, address);
            SaveModification(modifiedBy);
        }
    }
}
