using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.PLL.Controllers
{
    //[Authorize("LabDoctor")]
    public class LabDoctorController : Controller
    {
        public ActionResult Profile()
        {
            return View();
        }
    }
}
