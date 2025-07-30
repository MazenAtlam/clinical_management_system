using CCMS.DAL.Entities;
using System.Collections.Generic;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IMedicalHistoryRepo
    {
        bool Create(MedicalHistory medicalHistory);
        MedicalHistory GetById(int id);
        List<MedicalHistory> GetAll();
        bool Delete(int id);
        bool Update(MedicalHistory medicalHistory);
    }
}