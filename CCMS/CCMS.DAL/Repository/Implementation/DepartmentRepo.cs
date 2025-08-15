using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly CcmsDbContext departmentDbContext;

        public DepartmentRepo(CcmsDbContext db) => departmentDbContext = db;

        public async Task Add(Department department) => departmentDbContext.Departments.Add(department);

        public async Task<List<Department>> GetAll() => departmentDbContext.Departments.Where(a => !a.IsDeleted).ToList();

        public async Task<Department> GetById(int id)
        {
            Department? department = departmentDbContext.Departments
                .Where(dept => dept.Id == id && !dept.IsDeleted)
                .FirstOrDefault();

            return department == null
                ? throw new ArgumentException($"There is no department with the ID = {id}", nameof(id))
                : department;
        }

        public async Task Save() => departmentDbContext.SaveChanges();
    }
}
