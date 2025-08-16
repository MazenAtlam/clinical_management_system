using CCMS.BLL.ModelVM.WorkingSlot;
using CCMS.DAL.Entities;
using Riok.Mapperly.Abstractions;

namespace CCMS.BLL.Mapping
{
    [Mapper]
    public partial class WorkingSlotMapper
    {
        // Map WorkingSlot -> WorkingSlotDTO
        public partial WorkingSlotDTO ToResponseDto(WorkingSlot workingSlot);
        public partial List<WorkingSlotDTO> ToListResponseDto(List<WorkingSlot> workingSlots);
    }
}
