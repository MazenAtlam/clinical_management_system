using CCMS.BLL.ModelVM.Scan;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using CCMS.BLL.Services.Abstraction;

namespace CCMS.BLL.Services.Implementation
{
    public class ScanService : IScanService
    {
        // Compile-time only implementation aligned with async repos

        public ScanService(IScanRepo scanRepo, IPatientRepo patientRepo, ILabDoctorRepo labDoctorRepo/*, INotificationService notificationService*/) { }

        public bool Create(ScanDTO scan)
        {
            return false;
        }

        public bool Update(ScanDTO scan)
        {
            return false;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public Scan GetById(int id)
        {
            return null;
        }

        public List<Scan> GetAll()
        {
            return new List<Scan>();
        }

        public List<Scan> GetByPatient(int patientId)
        {
            return new List<Scan>();
        }

        public List<Scan> GetByLabDoctor(int labDoctorId)
        {
            return new List<Scan>();
        }

        public bool UploadScanResult(int scanId, string resultPath)
        {
            return false;
        }

        public bool SendScanToPatient(int scanId)
        {
            return false;
        }
    }
}
