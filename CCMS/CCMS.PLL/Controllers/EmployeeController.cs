using CCMS.BLL.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.PLL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService service) => employeeService = service;

        public async Task<IActionResult> Index()
        {
            //Test Repo
            //// Add
            //EmployeeDTO employee = new EmployeeDTO()
            //{
            //    FName = "Test",
            //    LName = "Test",
            //    Ssn = "33333333333333",
            //    BirthDate = new DateOnly(2004, 5, 5),
            //    Salary = 200000,
            //    YearsOfExperience = 10,
            //    HiringDate = DateTime.Now,
            //    Gender = DAL.Enums.Gender.Male,
            //    CreatedBy = "Test"
            //};
            //await employeeService.CreateEmployeeAsync(employee);

            //// Get All
            //var employees = await employeeService.GetAllEmployees();

            //// GetByID
            //var employee = await employeeService.GetEmployeeById(3);

            return View();
        }
    }
}
