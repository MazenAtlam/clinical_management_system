using CCMS.DAL.Enums;
using Microsoft.AspNetCore.Http;

namespace CCMS.BLL.ModelVM.User
{
    public class RegisterVM
    {
        public IFormFile? File { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FName { get; set; }
        public string? MidName { get; set; }
        public string LName { get; set; }
        public string Ssn { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public BloodType BloodType { get; set; }
    }
}
