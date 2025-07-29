using CCMS.DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("WorkingSlot", Schema = "ccms")]
    public class WorkingSlot : Base
    {
        public int id { get; private set; }

        public WorkingSlotStatus status { get; private set; }
        [Required]
        public DayOfWeek day { get; set; }  // Enum: Sunday to Saturday

        [Required]
        public TimeSpan startTime { get; set; }  // Only time (e.g., 09:00)

        [Required]
        public TimeSpan endTime { get; set; }    // Only time (e.g., 17:00)

        public WorkingSlot(DayOfWeek day, TimeSpan startTime, TimeSpan endTime)
        {
            this.day = day;
            this.startTime = startTime;
            this.endTime = endTime;
            status = WorkingSlotStatus.Available;
        }
    }
}