using CCMS.BLL.ModelVM.User;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace CCMS.BLL.Services.Implementation
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

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
                ApplicationUser user = new ApplicationUser(usr.UType, createdBy)
                {
                    UserName = usr.UserName,
                    Email = usr.Email,
                };

                IdentityResult result = await _userManager.CreateAsync(user, usr.Password);
                if (!result.Succeeded)
                    return (null, result);
                
                IdentityResult roleResult = await _userManager.AddToRoleAsync(user, usr.UType.ToString());

                return roleResult.Succeeded ? (user.Id, roleResult) : (null, roleResult);
            }
            catch (Exception ex) { return (ex.Message, null); }
        }

        public async Task<(string?, SignInResult?)> Login(LoginVM login)
        {
            try
            {
                ApplicationUser? user;

                user = await _userManager.FindByEmailAsync(login.EmailOrUserName);
                user ??= await _userManager.FindByNameAsync(login.EmailOrUserName);

                if (user == null)
                    return ("User not found", null);

                SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, false);

                return result.Succeeded ? (user.UType.ToString(), result) : ("Invalid Password. Try again.", result);
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
