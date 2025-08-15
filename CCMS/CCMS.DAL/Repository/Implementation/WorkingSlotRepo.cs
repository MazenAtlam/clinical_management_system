using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
     public class WorkingSlotRepo : IWorkingSlotRepo
    {
        private readonly CcmsDbContext db;

        public WorkingSlotRepo(CcmsDbContext db) => this.db = db;

        public async Task Add(WorkingSlot workingSlot) => db.workingSlots.Add(workingSlot);

        // In WorkingSlotService
        //public bool Delete(int id)
        //{
        //    try
        //    {
        //        var slot = db.workingSlots.Where(a => a.id == id).FirstOrDefault();
        //        if (slot == null)
        //            return false;
        //        //add modifiing user
        //        slot.Delete("admin");
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public async Task<List<WorkingSlot>> GetAll() => db.workingSlots.Where(a => !a.IsDeleted).ToList();

        public async Task<WorkingSlot> GetById(int id)
        {
            WorkingSlot? slot = db.workingSlots.Where(a => a.id == id && !a.IsDeleted).FirstOrDefault();
            
            return slot == null
                ? throw new ArgumentException($"There is no slot with the ID = {id}", nameof(id))
                : slot;
        }

        public async Task Save() => db.SaveChanges();

        // In WorkingSlotService
        //public bool Update(WorkingSlot workingSlot, string modifiedBy)
        //{
        //    try
        //    {
        //        var slt = db.workingSlots.Where(a => a.id == workingSlot.id).FirstOrDefault();
        //        if (slt == null)
        //            return false;

        //        slt.Edit(workingSlot.status, workingSlot.day,workingSlot.startTime,workingSlot.endTime, modifiedBy);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
