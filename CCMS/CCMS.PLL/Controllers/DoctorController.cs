using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.PLL.Controllers
{
    //[Authorize("Doctor")]
    public class DoctorController : Controller
    {
        public ActionResult Profile()
        {
            return View();
        }
    }
}
