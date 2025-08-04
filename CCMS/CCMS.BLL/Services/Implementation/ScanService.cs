using CCMS.BLL.ModelVM.Scan;
using CCMS.DAL.Repository.Abstraction;
using CCMS.BLL.Mapping;
using System.Collections.Generic;

namespace CCMS.BLL.Services.Implementation
{
    public class ScanService
    {
        private readonly IScanRepo _scanRepo;
        private readonly ScanMapper _scanMapper;

        public ScanService(IScanRepo scanRepo, ScanMapper scanMapper)
        {
            _scanRepo = scanRepo;
            _scanMapper = scanMapper;
        }

        public List<ScanDTO> GetAllScans()
        {
            var scans = _scanRepo.GetAll();
            return _scanMapper.ToDTOList(scans);
        }
    }
}
