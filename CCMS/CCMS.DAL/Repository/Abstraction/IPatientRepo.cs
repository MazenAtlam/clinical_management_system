using CCMS.DAL.Entities;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IPatientRepo
    {
        bool Create(Patient patient);
        Patient GetById(int id);
        List<Patient> GetAll();
        bool Delete(int id);
        bool Update(Patient patient);
    }
}
