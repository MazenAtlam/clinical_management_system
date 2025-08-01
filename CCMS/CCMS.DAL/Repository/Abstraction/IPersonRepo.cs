using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCMS.DAL.Entities;

namespace CCMS.DAL.Repository.Abstraction
{

    public interface IPersonRepo
    {
        Task<Person> CreatePerson(Person person);
        Task<Person> UpdatePerson(Person person);
        Task<IEnumerable<Person>> GetAllPersons();
        Task<Person> GetPersonById(int id);
        Task<bool> DeletePerson(int id);
    }

}
