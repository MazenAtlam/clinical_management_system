using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IDoctorRepo
    {
        bool Create(Doctor doctor);
        Doctor GetById(int id);
        List<Doctor> GetAll();
        List<Doctor> GetAllByMajor(Specialization major);
        List<Doctor> GetAllByName(string name);
        List<Doctor> GetAllByRating(Rating rating);
        bool Delete(int id);
        bool Update(Doctor doctor);
    }
}
