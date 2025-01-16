using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Models;
using IWant.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace IWant.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender emailSender;

        public ProfileController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            this.emailSender = emailSender;
        }

        public async Task<IActionResult> UpdateProfile()
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (user == null || user.Status == false)
            {
                return RedirectToAction("Signin", "Identity");
            }

            var model = new UpdateProfileViewModel
            {
                Email = user.Email,
                FullName = user.FullName,
                Birthday = user.Birthday,
                Gender = user.Gender
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UpdateProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (user == null)
            {
                TempData["error"] = "Account not found!";
                return RedirectToAction("Signin", "Identity");
            }

            user.FullName = model.FullName;
            user.Birthday = model.Birthday;
            user.Gender = model.Gender;
            user.UpdatedAt = DateTime.Now;

            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                TempData["success"] = "Profile updated successfully.";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                TempData["error"] = "Failed to update profile!";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (user == null || user.Status == false)
            {
                return RedirectToAction("Signin", "Identity");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (user == null)
            {
                TempData["error"] = "Account not found!";
                return RedirectToAction("Signin", "Identity");
            }
            var passwordHasher = new PasswordHasher<User>();
            if (passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.CurrentPassword) == PasswordVerificationResult.Failed)
            {
                TempData["error"] = "Current password is incorrect!";
                return View(model);
            }
            var tempNewPasswordHash = passwordHasher.HashPassword(user, model.NewPassword);
            if (tempNewPasswordHash == user.PasswordHash)
            {
                TempData["error"] = "New password must be different from the current password!";
                return View(model);
            }
            if (model.NewPassword != model.ConfirmPassword)
            {
                TempData["error"] = "New password and confirm password do not match!";
                return View(model);
            }
            var newPasswordHash = passwordHasher.HashPassword(user, model.NewPassword);
            user.PasswordHash = newPasswordHash;
            user.UpdatedAt = DateTime.Now;
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                TempData["success"] = "Password changed successfully.";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                TempData["error"] = "Failed to change password!";
                return View(model);
            }
        }
    }
}
