using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCMS.DAL.Entities;


namespace CCMS.DAL.Repository.Abstraction
{
  
    public interface IEmployeeRepo
    {
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<bool> DeleteEmployee(int id);
    }

}
