using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.Room
{
    public class RoomDTO
    {
        public string RNumber { get; private set; } // bbfrrr
        public int capacity { get; private set; }
        public Rtype rtype { get; private set; }
        public Rstatus rstatus { get; private set; }
        public int? DeptId { get; private set; }
    }
}
