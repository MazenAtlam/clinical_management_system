using CCMS.DAL.Entities;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IDepartmentRepo
    {
        public Task Add(Department department);
        public Task<Department> GetById(int id);
        public Task<List<Department>> GetAll();
        public Task Save();
    }
}
