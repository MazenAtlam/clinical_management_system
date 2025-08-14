using CCMS.BLL.ModelVM.Scan;
using CCMS.DAL.Entities;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IScanService
    {
        bool Create(ScanDTO scan);
        bool Update(ScanDTO scan);
        bool Delete(int id);
        Scan GetById(int id);
        List<Scan> GetAll();
        List<Scan> GetByPatient(int patientId);
        List<Scan> GetByLabDoctor(int labDoctorId);
        bool UploadScanResult(int scanId, string resultPath);
        bool SendScanToPatient(int scanId);
    }
}
