
using CCMS.BLL.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.PLL.Controllers
{
    public class PatientController: Controller
    {
        // make interface not service
        //private readonly PatientService _patientService;

        //public PatientController(PatientService patientService)
        //{
        //    _patientService = patientService;
        //}

        public ActionResult PatientLogin()
        { 
           return View();
        }
        public ActionResult PatientSignUp()
        {
            return View();
        }
        //show photo and details and give permission to edit
        public ActionResult PatientProfile()
        {
            return View();
        }
        public ActionResult EditPatientProfile()
        {
            return View();
        }
        public ActionResult PatientDashBoard()
        {
            return View();
        }
        //show doctors based on majors and ratings
        public ActionResult PGet_Doctors()
        {
            return View();
        }
    }
}
