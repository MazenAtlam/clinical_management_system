using CCMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IRoomRepo
    {
        public Task Add(Room room);
        public Task<Room> GetById(string rNumber);
        public Task<List<Room>> GetAll();
        public Task Save();
    }
}
