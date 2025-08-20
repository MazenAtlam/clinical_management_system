using CCMS.BLL.ModelVM.User;
using Microsoft.AspNetCore.Identity;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IApplicationUserService
    {
        public Task<(string?, IdentityResult?)> Create(CreateUser usr, string createdBy);
        public Task<(string?, SignInResult?)> Login(LoginVM login);
        public Task<(string?, IdentityResult?)> UpdatePassword(EditUserPassword usr, string modifiedBy);
    }
}
