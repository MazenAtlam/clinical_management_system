using CCMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IWorkingSlotRepo
    {
        bool Create(WorkingSlot workingSlot);
        WorkingSlot GetById(int id);
        List<WorkingSlot> GetAll();
        bool Delete(int id);
        bool Update(WorkingSlot workingSlot);
    }
}
