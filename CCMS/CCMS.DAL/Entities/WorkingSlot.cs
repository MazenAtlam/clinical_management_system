using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("WorkingSlot", Schema = "ccms")]
    public class WorkingSlot : Base
    {
        public int id { get; private set; }
        [Required]
        public WorkingSlotStatus status { get; private set; }
        [Required]
        public DayOfWeek day { get; private set; }  // Enum: Sunday to Saturday
        [Required]
        public TimeSpan startTime { get; private set; }  // Only time (e.g., 09:00)
        [Required]
        public TimeSpan endTime { get; private set; }    // Only time (e.g., 17:00)
        public List<Employee> Employees { get; private set; } = new List<Employee>();

        //public WorkingSlot() : base() { }
        public WorkingSlot(WorkingSlotStatus status, DayOfWeek day, TimeSpan startTime, TimeSpan endTime, string createdBy)
            : base(createdBy)
            => Set(status, day, startTime, endTime);

        private void Set(WorkingSlotStatus status, DayOfWeek day, TimeSpan startTime, TimeSpan endTime)
        {
            this.status = status;
            this.day = day;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        // Remove of not neccessary
        public void EditStatus(WorkingSlotStatus status, string modifiedBy)
        {
            this.status = status;
            SaveModification(modifiedBy);
        }

        // Remove of not neccessary
        public void EditTime(TimeSpan startTime, TimeSpan endTime, string modifiedBy)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            SaveModification(modifiedBy);
        }

        public void Edit(WorkingSlotStatus status, DayOfWeek day, TimeSpan startTime, TimeSpan endTime, string modifiedBy)
        {
            Set(status, day, startTime, endTime);
            SaveModification(modifiedBy);
        }
    }
}