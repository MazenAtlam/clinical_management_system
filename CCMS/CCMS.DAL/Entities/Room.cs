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
        public Department? Department { get; private set; }
        public List<MedicalDevice> MedicalDevices { get; private set; } = new List<MedicalDevice>();
        //ternary relationship book
        public List<Book> Books { get; private set; } = new List<Book>();

        public Room() : base() { }
        public Room(string rNumber, int capacity, Rtype rtype, Rstatus rstatus, int? deptID, string createdBy)
            : base(createdBy)
            => Set(rNumber, capacity, rtype, rstatus, deptID);

        private void Set(string rNumber, int capacity, Rtype rtype, Rstatus rstatus, int? deptID)
        {
            RNumber = rNumber;
            this.capacity = capacity;
            this.rtype = rtype;
            this.rstatus = rstatus;
            DeptId = deptID;
        }

        public void Edit(string rNumber, int capacity, Rtype rtype, Rstatus rstatus, int? deptID, string modifiedBy)
        {
            Set(rNumber, capacity, rtype, rstatus, deptID);
            SaveModification(modifiedBy);
        }
        
    }
}