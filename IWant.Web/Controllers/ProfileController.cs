using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Models;
using IWant.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Reflection.Metadata;

namespace IWant.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Allow to display the update profile page
        public async Task<IActionResult> UpdateProfile()
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (user == null || user.Status == false)
            {
                return RedirectToAction("Signin", "Identity");
            }

            var model = new UpdateProfileViewModel
            {
                //Parent
                Email = user.Email,
                FullName = user.FullName,
                Birthday = user.Birthday,
                Gender = user.Gender,
                ImageUrl = user.ImageUrl,
                PhoneNumber = user.PhoneNumber,
                //Child
                ChildName = user.ChildName,
                ChildNickName = user.ChildNickName,
                ChildGender = user.ChildGender,
                ChildBirthday = user.ChildBirthday,

            };

            return View(model);
        }

        // Allow to update the profile information
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UpdateProfileViewModel model)
        {
            ModelState.Remove(nameof(model.ImageUrl));
            ModelState.Remove(nameof(model.ImageLocalPath));
            ModelState.Remove(nameof(model.Email));
            ModelState.Remove(nameof(model.CreatedAt));
            ModelState.Remove(nameof(model.UpdatedAt));

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (user == null)
            {
                TempData["error"] = "Please Sign in to continue!";
                return RedirectToAction("Signin", "Identity");
            }

            user.FullName = model.FullName;
            user.Birthday = model.Birthday;
            user.Gender = model.Gender;
            user.UpdatedAt = DateTime.Now;
            user.PhoneNumber = model.PhoneNumber;

            user.ChildName = model.ChildName;
            user.ChildNickName = model.ChildNickName;
            user.ChildGender = model.ChildGender;
            user.ChildBirthday = model.ChildBirthday;

            if (model.Image != null && model.Image.Length > 0)
            {
                string defaultAvatar = "default-avatar.png";

                if (!string.IsNullOrEmpty(user.ImageLocalPath) && !user.ImageLocalPath.Contains(defaultAvatar))
                {
                    var oldFilePath = Path.Combine("wwwroot", "images", user.ImageLocalPath);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                // Lưu avatar mới
                string avatarFolder = Path.Combine("wwwroot", "images", "avatar");
                if (!Directory.Exists(avatarFolder))
                {
                    Directory.CreateDirectory(avatarFolder);
                }

                string fileName = $"{user.Id}{Path.GetExtension(model.Image.FileName)}";
                string filePath = Path.Combine(avatarFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fileStream);
                }

                user.ImageUrl = $"/images/avatar/{fileName}";
                user.ImageLocalPath = Path.Combine("avatar", fileName);
            }

            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                TempData["success"] = "Update Profile successfully!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                TempData["error"] = "Failed to update profile!";
                return View(model);
            }
        }


        // Allow to display the change password page
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (user == null || user.Status == false)
            {
                TempData["error"] = "Please Sign in to continue!";
                return RedirectToAction("Signin", "Identity");
            }
            return View();
        }

        // Allow to change the password
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

            // Check Current Password
            if (passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.CurrentPassword) == PasswordVerificationResult.Failed)
            {
                TempData["error"] = "Current password is incorrect!";
                return View(model);
            }

            // Check New Password with Current Password
            if (passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.NewPassword) == PasswordVerificationResult.Success)
            {
                TempData["error"] = "New password must be different from the current password!";
                return View(model);
            }

            // Check New Password with Confirm Password
            if (model.NewPassword != model.ConfirmPassword)
            {
                TempData["error"] = "New password and confirm password do not match!";
                return View(model);
            }

            // Update Password
            user.PasswordHash = passwordHasher.HashPassword(user, model.NewPassword);
            user.UpdatedAt = DateTime.Now;

            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                TempData["success"] = "Change Password successfully!";
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
