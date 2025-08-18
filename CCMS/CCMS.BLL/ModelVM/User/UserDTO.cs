using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.User
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public UserType UType { get; set; }
    }
}
