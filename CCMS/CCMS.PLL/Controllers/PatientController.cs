
using CCMS.BLL.ModelVM.Patient;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.PLL.Controllers
{
    public class PatientController: Controller
    {
        //ADD MAPPERS
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public ActionResult PatientLogin()
        { 
           return View();
        }
        public ActionResult PatientSignUp()
        {
            return View();
        }
        //show photo and details and give permission to edit
        public ActionResult PatientProfile(int id)
        {
            Patient patient = _patientService.GetById(id);
            PatientDTO patientDTO = new PatientDTO(patient.UID, patient.FName, patient.MidName, patient.LName, patient.Ssn, patient.Gender, patient.BirthDate, patient.BloodType,patient.PhoneNumbers,patient.Addresses);
            ViewBag.Appointment = _patientService.GetPatientAppointments(id);
            ViewBag.Scans = _patientService.GetScansOfPatient(id);
            ViewBag.FamilyMembers = _patientService.GetFamilyMembersOfPatient(id);
            return View(patientDTO);
        }
        public ActionResult EditPatientProfile(PatientDTO patientDTO)
        {
            _patientService.Update(patientDTO);
            return RedirectToAction("PatientProfile",patientDTO.UID);
        }
        //show doctors based on majors and ratings
        public ActionResult PGet_Doctors()
        {
            return View();
        }
    }
}
