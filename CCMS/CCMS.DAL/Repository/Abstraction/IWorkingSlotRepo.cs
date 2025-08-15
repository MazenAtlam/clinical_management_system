using CCMS.DAL.Entities;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IWorkingSlotRepo
    {
        public Task Add(WorkingSlot workingSlot);
        public Task<WorkingSlot> GetById(int id);
        public Task<List<WorkingSlot>> GetAll();
        public Task Save();
    }
}
