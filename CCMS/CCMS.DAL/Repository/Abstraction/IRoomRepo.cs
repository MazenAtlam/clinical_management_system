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
        bool Create(Room room);
        Room GetById(int id);
        List<Room> GetAll();
        bool Delete(int id);
        public bool Update(Room room, string modifyingUser);
    }
}
