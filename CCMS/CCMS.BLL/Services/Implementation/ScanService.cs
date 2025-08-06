using CCMS.BLL.ModelVM.Scan;
using CCMS.DAL.Repository.Abstraction;
using CCMS.BLL.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<List<ScanDTO>> GetAllScansAsync()
        {
            var scans = await _scanRepo.GetAllAsync();
            return _scanMapper.ToDTOList(scans);
        }
    }
}
