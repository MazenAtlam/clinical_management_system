using CCMS.BLL.ModelVM.Patient;
using CCMS.BLL.ModelVM.User;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.PLL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IApplicationUserService _userService;
        private readonly IPatientService _patientService;
        private readonly IAdministratorService _adminService;

        public AccountController(IApplicationUserService userService, IPatientService patientService, IAdministratorService adminService)
        {
            _userService = userService;
            _patientService = patientService;
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterVM register)
        {
            if (!register.ConfirmPassword.Equals(register.Password))
            {
                // Validation Errors

                // Display the errors
                ViewBag.Error = "The passeord and Confirm password do not match.";

                return View(register);
            }

            // Create the account for the patient
            CreateUser user = new CreateUser()
            {
                UserName = register.UserName,
                Email = register.Email,
                Password = register.Password,
                ConfirmPassword = register.ConfirmPassword,
                UType = UserType.Patient
            };

            var createResult = await _userService.Create(user, user.UserName);

            if (createResult.Item2 == null)
            {
                // Exception Happened while creating the account

                // Display the error message using ViewBag
                ViewBag.Error = createResult.Item1;
                return View(register);
            }

            if (!createResult.Item2.Succeeded)
            {
                // Validation Errors

                // Display the errors
                ViewBag.ValidationErrors = createResult.Item2.Errors;

                return View(register);
            }

            // The account created successfully

            // Create the patient user
            CreatePatient patient = new CreatePatient()
            {
                FName = register.FName,
                MidName = register.MidName,
                LName = register.LName,
                Ssn = register.Ssn,
                Gender = register.Gender,
                BirthDate = register.BirthDate,
                BloodType = register.BloodType,
            };

            string? result = await _patientService.Create(patient, user.UserName);

            if (string.IsNullOrEmpty(result))
            {
                // The patient user created successfully
                return RedirectToAction("Login");
            }

            // Exception happened while creating the patient user

            // Display the error message using ViewBag
            ViewBag.Error = result;
            return View(register);
        }
    

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            var result = await _userService.Login(login);

            if (result.Item2 == null)
            {
                // Exception Happened while creating the account

                // Display the error message using ViewBag
                ViewBag.Error = result.Item1;
                return View(login);
            }

            if (!result.Item2.Succeeded)
            {
                // Login Error

                // Display the error
                ViewBag.Error = result.Item2.IsNotAllowed ? "Your email is not confirmed. The confirm message is in your inbox." : result.Item1;

                return View(login);
            }
            
            return RedirectToAction("Index", result.Item1);
        }
    }
}
