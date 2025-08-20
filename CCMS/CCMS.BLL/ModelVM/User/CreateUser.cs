using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.User
{
    public class CreateUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public UserType UType { get; set; }
    }
}
