using CCMS.BLL.ModelVM.BiomedicalEngineer;
using CCMS.DAL.Entities;
using Riok.Mapperly.Abstractions;

namespace CCMS.BLL.Mapping
{
    [Mapper]
    public partial class BiomedicalEngineerMapper
    {
        // Map BiomedicalEngineer -> BiomedicalEngineerDTO
        public partial BiomedicalEngineerDTO ToResponseDto(BiomedicalEngineer biomedicalEngineer);
        public partial List<BiomedicalEngineerDTO> ToListResponseDto(List<BiomedicalEngineer> biomedicalEngineers);

        // Map BiomedicalEngineerDTO -> BiomedicalEngineer
        public partial BiomedicalEngineer ToEntity(BiomedicalEngineerDTO bioEngDTO);
    }
}
