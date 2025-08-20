using CCMS.BLL.ModelVM.User;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace CCMS.BLL.Services.Implementation
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserService(UserManager<ApplicationUser> userManager) =>_userManager = userManager;

        public async Task<(string?, IdentityResult?)> Create(CreateUser usr, string createdBy)
        {
            /**
             * Return Tuple(string?, object?, string?):
             * Item1 represents the user Id: if success the id returned,
             *      else if failed return null, else the exception message returned
             * Item2 represents the result: will be null only if there is an exception
             */

            try
            {
                ApplicationUser user = new ApplicationUser(createdBy)
                {
                    UserName = usr.UserName,
                    Email = usr.Email,
                };

                IdentityResult result = await _userManager.CreateAsync(user, usr.Password);

                return result.Succeeded ? (user.Id, result) : (null, result);
            }
            catch (Exception ex) { return (ex.Message, null); }
        }

        public async Task<(string?, IdentityResult?)> UpdatePassword(EditUserPassword usr, string modifiedBy)
        {
            try
            {
                // Retrieve the user
                ApplicationUser? user = await _userManager.FindByIdAsync(usr.Id);
                if (user == null)
                {
                    return ("User not found.", null);
                }

                // Generate a password reset token
                string token = await _userManager.GeneratePasswordResetTokenAsync(user);

                // Reset the password
                IdentityResult result = await _userManager.ResetPasswordAsync(user, token, usr.Password);

                if (result.Succeeded)
                    await _userManager.UpdateSecurityStampAsync(user);

                return (null,  result);
            }
            catch (Exception ex) { return (ex.Message, null); }
        }
    }
}
