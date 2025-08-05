using Riok.Mapperly.Abstractions;
using CCMS.DAL.Entities;
using CCMS.BLL.ModelVM.MedicalHistory;
using System.Collections.Generic;

namespace CCMS.BLL.Mapping
{
    [Mapper]
    public partial class MedicalHistoryMapper
    {
        public partial MedicalHistoryDTO ToDTO(MedicalHistory history);
        public partial List<MedicalHistoryDTO> ToDTOList(List<MedicalHistory> histories);
        // Reverse mapping
        public partial MedicalHistory ToEntity(MedicalHistoryDTO dto);
        public partial List<MedicalHistory> ToEntityList(List<MedicalHistoryDTO> dtos);
    }
}
