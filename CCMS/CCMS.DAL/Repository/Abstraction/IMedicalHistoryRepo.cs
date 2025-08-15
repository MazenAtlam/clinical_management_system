using CCMS.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IMedicalHistoryRepo
    {
        public Task Add(MedicalHistory medicalHistory);
        public Task<MedicalHistory> GetById(int id);
        public Task<List<MedicalHistory>> GetAll();
        public Task Save();
    }
}