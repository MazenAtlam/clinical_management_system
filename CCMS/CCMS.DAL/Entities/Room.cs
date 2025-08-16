using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("Room", Schema = "ccms")]
    public class Room : Base
    {
        [Key]
        [MaxLength(6)]
        [MinLength(6)]
        public string RNumber { get; private set; } // bbfrrr
        public int capacity { get; private set; }
        public Rtype rtype { get; private set; }
        public Rstatus rstatus { get; private set; }
        // FOREIGN KEY DEP ID
        [ForeignKey("Department")]
        public int? DeptId { get; private set; }
        public virtual Department? Department { get; private set; }
        public virtual List<MedicalDevice> MedicalDevices { get; private set; } = new List<MedicalDevice>();
        //ternary relationship book
        public virtual List<Book> Books { get; private set; } = new List<Book>();

        //public Room() : base() { }
        public Room(string rNumber, int capacity, Rtype rtype, Rstatus rstatus, int? deptId, string createdBy)
            : base(createdBy)
            => Set(rNumber, capacity, rtype, rstatus, deptId);

        private void Set(string rNumber, int capacity, Rtype rtype, Rstatus rstatus, int? deptId)
        {
            RNumber = rNumber;
            this.capacity = capacity;
            this.rtype = rtype;
            this.rstatus = rstatus;
            DeptId = deptId;
        }

        public void Edit(string rNumber, int capacity, Rtype rtype, Rstatus rstatus, int? deptId, string modifiedBy)
        {
            Set(rNumber, capacity, rtype, rstatus, deptId);
            SaveModification(modifiedBy);
        }
        
    }
}