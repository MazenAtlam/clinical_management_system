using CCMS.DAL.Entities;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IAdministratorRepo
    {
        public void Add(Employee admin);

        public List<Employee> GetAllAdmins();

        //// From Doctor service
        //public List<Employee> GetAllDoctors();

        //// From LabDoctor service
        //public List<Employee> GetAllLabDoctors();

        //// From BiomedicalEngineer service
        //public List<Employee> GetAllBiomedicalEngineers();

        public Employee GetAdminByID(int id);

        public List<Employee> GetAllEmployeesCrearedBy(int id);

        public void Save();
    }
}
