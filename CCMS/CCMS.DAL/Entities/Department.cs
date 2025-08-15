using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("Department", Schema = "ccms")]
    public class Department : Base
    {
        public int Id { get; private set; }
        [Required]
        [MaxLength(100)]
        public string DName { get; private set; }
        public List<Room> Rooms { get; private set; } = new List<Room>();
        public List<Employee> Employees { get; private set; } = new List<Employee>();

        //public Department() : base() { }
        public Department(string dName, string createdBy)
            : base(createdBy)
            => DName = dName;

        public void Edit(string dName, string modifiedBy)
        {
            DName = dName;
            SaveModification(modifiedBy);
        }
    }
}