using CCMS.BLL.ModelVM.Doctor;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using CCMS.DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.BLL.Services.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo repo;

        public DoctorService(IDoctorRepo repo)
        {
            this.repo = repo;
        }
        public bool Create(CreateDoctor doctor)
        {
            throw new NotImplementedException();
            //try
            //{
            //    var doc = new Doctor(doctor.major);
            //    repo.Create(doc);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllByMajor(Specialization major)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllByRating(Rating rating)
        {
            throw new NotImplementedException();
        }

        public Doctor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(DoctorDTO doctor)
        {
            throw new NotImplementedException();
        }
    }
}
