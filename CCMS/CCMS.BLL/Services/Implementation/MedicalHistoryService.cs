using CCMS.BLL.ModelVM.MedicalHistory;
using CCMS.DAL.Repository.Abstraction;
using CCMS.BLL.Mapping;
using System.Collections.Generic;

namespace CCMS.BLL.Services.Implementation
{
    public class MedicalHistoryService
    {
        private readonly IMedicalHistoryRepo _medicalHistoryRepo;
        private readonly MedicalHistoryMapper _medicalHistoryMapper;

        public MedicalHistoryService(IMedicalHistoryRepo medicalHistoryRepo, MedicalHistoryMapper medicalHistoryMapper)
        {
            _medicalHistoryRepo = medicalHistoryRepo;
            _medicalHistoryMapper = medicalHistoryMapper;
        }

        public List<MedicalHistoryDTO> GetAllMedicalHistories()
        {
            var histories = _medicalHistoryRepo.GetAll();
            return _medicalHistoryMapper.ToDTOList(histories);
        }
    }
}
