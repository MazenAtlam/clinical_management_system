using Riok.Mapperly.Abstractions;
using CCMS.DAL.Entities;
using CCMS.BLL.ModelVM.Patient;
using CCMS.BLL.ModelVM.Book;
using CCMS.BLL.ModelVM.FamilyMember;

namespace CCMS.BLL.Mapping
{
    [Mapper]
    public partial class PatientMapper
    {
        public partial PatientDTO ToDTO(Patient patient);
        public partial List<PatientDTO> ToDTOList(List<Patient> patients);
        public partial Book ToBook(CreateBookDTO dto);
        public partial FamilyMember ToFamilyMember(CreateFamilyMemberDTO dto);

        // Reverse mappings
        //public partial Patient ToEntity(PatientDTO dto);
        //public partial List<Patient> ToEntityList(List<PatientDTO> dtos);
        public partial CreateBookDTO ToCreateBookDTO(Book book);
        public partial BookDTO ToBookDTO(Book book);
        public partial Book ToEntity(BookDTO dto);
        public partial FamilyMemberDTO ToFamilyMemberDTO(FamilyMember entity);
        public partial FamilyMember ToEntity(FamilyMemberDTO dto);
    }
}
