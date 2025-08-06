using CCMS.BLL.ModelVM.Doctor;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IDoctorService
    {
        bool Create(CreateDoctor doctor);
        Doctor GetById(int id);
        List<Doctor> GetAll();
        List<Doctor> GetAllByMajor(Specialization major);
        List<Doctor> GetAllByName(string name);
        List<Doctor> GetAllByRating(Rating rating);
        bool Delete(int id);
        bool Update(DoctorDTO doctor);
    }
}
