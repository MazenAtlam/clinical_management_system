using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.WorkingSlot
{
    public class WorkingSlotDTO
    {
        public int id { get; set; }
        public WorkingSlotStatus status { get; set; }
        public DayOfWeek day { get; set; }  // Enum: Sunday to Saturday
        public TimeSpan startTime { get; set; }  // Only time (e.g., 09:00)
        public TimeSpan endTime { get; set; }    // Only time (e.g., 17:00)
    }
}
