using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Implementation
{
     public class WorkingSlotRepo:IWorkingSlotRepo
    {
        private readonly CcmsDbContext db;

        public WorkingSlotRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public bool Create(WorkingSlot workingSlot)
        {
            try
            {
                db.workingSlots.Add(workingSlot);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var slot = db.workingSlots.Where(a => a.id == id).FirstOrDefault();
                if (slot == null)
                    return false;
                //add modifiing user
                slot.Delete("admin");
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<WorkingSlot> GetAll()
        {
            var result = db.workingSlots.Where(a => a.IsDeleted == false).ToList();
            return result;
        }

        public WorkingSlot GetById(int id)
        {
            var slot = db.workingSlots.Where(a => a.id == id).FirstOrDefault();
            return slot;
        }

        public bool Update(WorkingSlot workingSlot)
        {
            try
            {
                var slt = db.workingSlots.Where(a => a.id == workingSlot.id).FirstOrDefault();
                if (slt == null)
                    return false;

                slt.Edit(workingSlot.day,workingSlot.startTime,workingSlot.endTime,workingSlot.status);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
