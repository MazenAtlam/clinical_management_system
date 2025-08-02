using CCMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface ILabDoctorRepo
    {
        bool Create(LabDoctor labDoctor);
        LabDoctor GetById(int id);
        List<LabDoctor> GetAll();
        bool Delete(int id);
        bool Update(LabDoctor labDoctor);
    }
}
