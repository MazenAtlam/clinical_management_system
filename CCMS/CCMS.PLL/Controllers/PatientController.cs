
using CCMS.BLL.ModelVM.Book;
using CCMS.BLL.ModelVM.Patient;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.PLL.Controllers
{
    public class PatientController: Controller
    {
        //ADD MAPPERS
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;

        public PatientController(IPatientService patientService, IDoctorService doctorService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
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
        public async Task<ActionResult> PatientProfile(int id)
        {
            //HENA EL MAFROOD TERAGA3 PATIENT MEN EL SERVICE BAS FE ERROR BESABAB EL MULTITHREADING (EL HETA DEH)
            Patient patient = await _patientService.GetById(id);
            PatientDTO patientDTO = new PatientDTO(patient.UID, patient.FName, patient.MidName, patient.LName, patient.Ssn, patient.Gender, patient.BirthDate, patient.BloodType, patient.PhoneNumbers, patient.Addresses);
            ViewBag.Appointment = await _patientService.GetPatientAppointments(id);
            ViewBag.Scans = await _patientService.GetScansOfPatient(id);
            ViewBag.FamilyMembers = await _patientService.GetFamilyMembersWithRelationshipOfPatient(id);
            ViewBag.MedicalHistory = await _patientService.GetMedicalHistoryOfPatient(id);
            ViewBag.Specializations = _patientService.GetAllSpecializations();
            return View(patientDTO);
        }
        public async Task<ActionResult> EditPatientProfile(PatientDTO patientDTO)
        {
            await _patientService.Update(patientDTO);
            return RedirectToAction("PatientProfile", new { id = patientDTO.UID });
        }
        //show doctors based on majors and ratings
        public ActionResult PGet_Doctors()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorsBySpecialization(string specialization)
        {
            if (string.IsNullOrEmpty(specialization))
            {
                return Json(new List<object>());
            }

            if (Enum.TryParse<Specialization>(specialization, out var spec))
            {
                var doctors = await _doctorService.GetAllByMajor(spec);
                var doctorList = doctors.Select(d => new
                {
                    id = d.UID,
                    name = d.GetFullName()
                }).ToList();

                return Json(doctorList);
            }

            return Json(new List<object>());
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorWorkingSlots(int doctorId)
        {
            if (doctorId <= 0)
            {
                return Json(new List<object>());
            }

            var workingSlots = await _doctorService.GetDoctorWorkingSlots(doctorId);
            return Json(workingSlots);
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableRooms()
        {
            var rooms = await _doctorService.GetAvailableRooms();
            var roomList = rooms.Select(r => new
            {
                id = r.RNumber,
                
            }).ToList();

            return Json(roomList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDTO bookDto)
        {
            try
            {
                var result = await _patientService.CreateBookAsync(bookDto);
                return Json(new { success = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddFamilyMember([FromBody] AddFamilyMemberRequest request)
        {
            try
            {
                var result = await _patientService.AddFamilyMemberToPatient(
                    request.PatientId,
                    request.Name,
                    request.SSN,
                    request.PhoneNumber,
                    request.Gender,
                    request.Relationship
                );
                return Json(new { success = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMedicalRecord([FromBody] AddMedicalRecordRequest request)
        {
            try
            {
                var result = await _patientService.AddMedicalHistoryToPatient(
                    request.PatientId,
                    request.DiseaseName,
                    request.FamilyHistory
                );
                return Json(new { success = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
    }

    public class AddFamilyMemberRequest
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string SSN { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Relationship { get; set; }
    }

    public class AddMedicalRecordRequest
    {
        public int PatientId { get; set; }
        public string DiseaseName { get; set; }
        public bool FamilyHistory { get; set; }
    }
}
