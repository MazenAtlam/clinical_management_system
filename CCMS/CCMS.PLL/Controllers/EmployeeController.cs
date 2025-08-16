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
            return View();
        }
    }
}
