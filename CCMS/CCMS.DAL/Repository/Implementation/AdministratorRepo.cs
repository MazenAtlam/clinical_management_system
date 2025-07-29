using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class AdministratorRepo : IAdministratorRepo
    {
        //private readonly CcmsDbContext adminCcmsDbContext = new();

        public void Add(Employee admin)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllAdmins()
        {
            throw new NotImplementedException();
        }

        //public List<Employee> GetAllDoctors()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Employee> GetAllLabDoctors()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Employee> GetAllBiomedicalEngineers()
        //{
        //    throw new NotImplementedException();
        //}

        public Employee GetAdminByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployeesCrearedBy(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
