using Riok.Mapperly.Abstractions;
using CCMS.DAL.Entities;
using CCMS.BLL.ModelVM.Scan;

namespace CCMS.BLL.Mapping
{
    [Mapper]
    public partial class ScanMapper
    {
        public partial ScanDTO ToDTO(Scan scan);
        public partial List<ScanDTO> ToDTOList(List<Scan> scans);
        // Reverse mapping
        public partial Scan ToEntity(ScanDTO dto);
        public partial List<Scan> ToEntityList(List<ScanDTO> dtos);
    }
}
