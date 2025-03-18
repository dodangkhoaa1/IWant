using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Models;
using IWant.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IWant.Web.Controllers
{
    public class IdentityController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender emailSender;

        public IdentityController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender, ApplicationDbContext context)
        {
            _userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this.emailSender = emailSender;
            _context = context;
        }

        // Allow to display the signup page
        public async Task<IActionResult> Signup()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            var model = new SignupViewModel() { Role = "Member" };
            return View(model);
        }

        /*[HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, returnUrl);
            var callbackUrl = Url.Action("ExternalLoginCallback");
            properties.RedirectUri = callbackUrl;
            return Challenge(properties, provider);
        }

        // Allow to handle external login callback
        public async Task<IActionResult> ExternalLoginCallback()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            var emailClaim = info.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            var fullNameClaim = info.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
            var genderClaim = info.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Gender);
            var user = new User
            {
                Email = emailClaim.Value,
                UserName = emailClaim.Value,
                FullName = fullNameClaim.Value,
                Status = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                ImageUrl = "http://localhost:5130/images/avatar/default-avatar.png",
                ImageLocalPath = "default-avatar.png",
                Gender = true
            };
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Member");
            }
            await _userManager.AddLoginAsync(user, info);
            await _signInManager.SignInAsync(user, false);

            TempData["success"] = "Sign-in successfull!";
            return RedirectToAction("Index", "Home");
        }*/

        // Allow to handle signup form submission
        [HttpPost]
        public async Task<IActionResult> Signup(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!(await _roleManager.RoleExistsAsync(model.Role)))
                {
                    var role = new IdentityRole { Name = model.Role };
                    var roleResult = await _roleManager.CreateAsync(role);
                    if (!roleResult.Succeeded)
                    {
                        var errors = roleResult.Errors.Select(s => s.Description);
                        ModelState.AddModelError("Role", string.Join(",", errors));
                        return View(model);
                    }
                }

                if ((await _userManager.FindByEmailAsync(model.Email)) == null)
                {
                    if (model.Password != model.ConfirmPassword)
                    {
                        TempData["error"] = "Password and confirm password not match!";
                        return View(model);
                    }
                    var user = new User
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        FullName = model.FullName,
                        ImageUrl = "http://localhost:5130/images/avatar/default-avatar.png",
                        ImageLocalPath = "default-avatar.png",
                        Birthday = model.Birthday,
                        Status = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        Gender = model.Gender,
                        PhoneNumber = model.PhoneNumber,
                        //Child
                        ChildName = model.ChildName,
                        ChildNickName = model.ChildNickName,
                        ChildBirthday = model.ChildBirthday,
                        ChildGender = model.ChildGender,
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, model.Role);

                        user = await _userManager.FindByEmailAsync(model.Email);

                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        if (result.Succeeded)
                        {
                            var confirmationLink = Url.ActionLink("ConfirmEmail", "Identity", new { userId = user.Id, @token = token });
                            string emailBody = $@"
                                            <div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; padding: 20px; 
                                                        border: 1px solid #ddd; border-radius: 10px; background-color: #f9f9f9;'>
                                                <h2 style='color: #333; text-align: center;'>Confirm Your Email Address</h2>
                                                <p style='color: #555; font-size: 16px;'>Hello <strong>{user.Email}</strong>,</p>
                                                <p style='color: #555; font-size: 16px;'>
                                                    Thank you for signing up! To complete your registration, please confirm your email address by clicking the button below:
                                                </p>
                                                <div style='text-align: center; margin: 20px 0;'>
                                                    <a href='{confirmationLink}' 
                                                       style='display: inline-block; padding: 12px 20px; font-size: 16px; 
                                                              color: white; background-color: #007bff; text-decoration: none; 
                                                              border-radius: 5px; font-weight: bold;'>
                                                        ✅ Confirm Email
                                                    </a>
                                                </div>
                                                <p style='color: #555; font-size: 14px;'>If you did not create this account, please ignore this email.</p>
                                                <hr style='border: 0; height: 1px; background-color: #ddd;' />
                                                <p style='color: #777; font-size: 12px; text-align: center;'>
                                                    If you are unable to click the button above, use the following link:
                                                </p>
                                                <p style='word-break: break-all; color: #007bff; text-align: center; font-size: 12px;'>
                                                    <a href='{confirmationLink}' style='color: #007bff;'>{confirmationLink}</a>
                                                </p>
                                                <p style='color: #777; font-size: 12px; text-align: center;'>© 2024 IWant. All Rights Reserved.</p>
                                            </div>";


                            await emailSender.SendEmailAsync("nhathmce170171@fpt.edu.vn", user.Email, "Confirm your email address", emailBody);

                            TempData["ConfirmationEmail"] = user.FullName;
                            TempData["success"] = "Sign Up successfully.";
                            return RedirectToAction("ConfirmEmailPage");
                        }
                        else
                        {
                            TempData["error"] = "Failed to send email!";
                            return View(model);
                        }
                    }

                    TempData["error"] = "Create Failed!";
                    return View(model);
                }
                else
                {
                    TempData["error"] = "Account already exists";
                    return View(model);
                }
            }
            return View(model);
        }

        // Allow to display the email confirmation page
        [HttpGet]
        public async Task<IActionResult> ConfirmEmailPage()
        {
            ViewBag.ConfirmationEmail = TempData["ConfirmationEmail"];
            return View();
        }

        // Allow to confirm email
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                TempData["success"] = "Confirm Email successfully.";
                return RedirectToAction("Signin");
            }
            return new NotFoundResult();
        }

        // Allow to display the signin page
        public IActionResult Signin()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View(new SigninViewModel());
        }

        // Allow to handle signin form submission
        [HttpPost]
        public async Task<IActionResult> Signin(SigninViewModel model)
        {
            /*if (ModelState.IsValid)
             * 
            {*/

            var user = await _userManager.FindByEmailAsync(model.Username);

            if (user == null)
            {
                TempData["error"] = "Username does not exist.";
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
            

            if (!result.Succeeded)
            {
                if (result.IsLockedOut || (user != null && user.Status == false))
                {
                    TempData["error"] = "Account has been banned.";
                    Console.WriteLine("Sign-in failed: Account is locked out.");
                }
                else if (result.IsNotAllowed)
                {
                    TempData["error"] = "Not allowed (e.g., email not confirmed).";
                    Console.WriteLine("Sign-in failed: Not allowed (e.g., email not confirmed).");
                }
                else if (result.RequiresTwoFactor)
                {
                    ModelState.AddModelError("Login", "Two-factor authentication is required.");
                    Console.WriteLine("Sign-in failed: Requires two-factor authentication.");
                    return RedirectToAction("MFACheck");
                }
                else
                {
                    TempData["error"] = "Invalid credentials.";
                    Console.WriteLine("Sign-in failed: Invalid credentials.");
                }
            }
            else
            {
                Console.WriteLine("Sign-in successful.");
                TempData["success"] = "Sign In successfully.";
                return RedirectToAction("Index", "Home");
            }
            /*}*/
            return View(model);
        }

        // Allow to display the forgot password page
        [HttpGet]
        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }

        // Allow to handle forgot password form submission
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            /*if (ModelState.IsValid)
            {*/
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    TempData["error"] = "Email does not exist.";
                    return View(model);
                }
                Random random = new Random();

                var codeOTP = random.Next(1000, 9999).ToString();
                model.Otp = codeOTP;

                await emailSender.SendEmailAsync(
                    "nhathmce170171@fpt.edu.vn",
                    user.Email,
                    "\"I Want\" Recover Password Verification",
                    $@"
                    <html>
                    <head>
                        <style>
                            body {{
                                font-family: Arial, sans-serif;
                                color: #333;
                                line-height: 1.5;
                            }}
                            .verification-box {{
                                text-align: center;
                                padding: 20px;
                                background-color: #f5f5f5;
                                border-radius: 8px;
                            }}
                            .verification-box img {{
                                width: 300px;
                                height: 90px;
                            }}
                            .otp-code {{
                                font-size: 30px;
                                font-weight: bold;
                                color: #a3745e;
                                margin-top: 20px;
                            }}
                            .resend-button {{
                                display: inline-block;
                                margin-top: 20px;
                                padding: 10px 20px;
                                background-color: #007bff;
                                color: white;
                                border: none;
                                border-radius: 5px;
                                text-decoration: none;
                                font-size: 16px;
                            }}
                            .resend-button:hover {{
                                background-color: #0056b3;
                            }}
                        </style>
                    </head>
                    <body>
                        <div class='verification-box'>
                            <h2>RESET PASSWORD OTP VERIFICATION</h2>
                            <p>A verification email has been sent to your email <strong>{user.FullName}</strong>.</p>
                            <p>Please check your email and verify the OTP code to recover your password.</p>
                            <p class='otp-code'>OTP: {codeOTP}</p>
                        </div>
                    </body>
                    </html>"
                    );

                TempData["success"] = $"OTP was sent to {user.FullName}'s mail!";
                TempData["Otp"] = model.Otp;
                TempData["email"] = model.Email;

                return RedirectToAction("VerifyOtp");
            /*}
            return View();*/
        }

        // Allow to display the OTP verification page   
        [HttpGet]
        public async Task<IActionResult> VerifyOtp()
        {
            TempData.Keep("email");
            return View();
        }

        // Allow to handle OTP verification form submission
        [HttpPost]
        public async Task<IActionResult> VerifyOtp(string otp)
        {
            var email = TempData["email"]?.ToString();
            var otpCode = TempData["Otp"]?.ToString();
            if (otp == otpCode)
            {
                TempData["email"] = email;
                TempData["success"] = "OTP verification successfull!";
                return RedirectToAction("ResetPassword");
            }
            TempData["error"] = "OTP verification failed!";
            TempData.Keep("email");
            TempData.Keep("Otp");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResendOtp()
        {
            var email = TempData["email"]?.ToString();
            if (string.IsNullOrEmpty(email))
            {
                TempData["error"] = "Session expired! Please request a new OTP.";
                return RedirectToAction("ForgotPassword");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                TempData["error"] = "Session expired! Please request a new OTP.";
                return RedirectToAction("ForgotPassword");
            }

            Random random = new Random();

            var codeOTP = random.Next(1000, 9999).ToString();
            TempData["Otp"] = codeOTP;

            await emailSender.SendEmailAsync(
                    "nhathmce170171@fpt.edu.vn",
                    user.Email,
                    "\"I Want\" Recover Password Verification",
                    $@"
                    <html>
                    <head>
                        <style>
                            body {{
                                font-family: Arial, sans-serif;
                                color: #333;
                                line-height: 1.5;
                            }}
                            .verification-box {{
                                text-align: center;
                                padding: 20px;
                                background-color: #f5f5f5;
                                border-radius: 8px;
                            }}
                            .verification-box img {{
                                width: 300px;
                                height: 90px;
                            }}
                            .otp-code {{
                                font-size: 30px;
                                font-weight: bold;
                                color: #a3745e;
                                margin-top: 20px;
                            }}
                            .resend-button {{
                                display: inline-block;
                                margin-top: 20px;
                                padding: 10px 20px;
                                background-color: #007bff;
                                color: white;
                                border: none;
                                border-radius: 5px;
                                text-decoration: none;
                                font-size: 16px;
                            }}
                            .resend-button:hover {{
                                background-color: #0056b3;
                            }}
                        </style>
                    </head>
                    <body>
                        <div class='verification-box'>
                            <h2>RESET PASSWORD OTP VERIFICATION</h2>
                            <p>A verification email has been sent to your email <strong>{user.FullName}</strong>.</p>
                            <p>Please check your email and verify the OTP code to recover your password.</p>
                            <p class='otp-code'>OTP: {codeOTP}</p>
                        </div>
                    </body>
                    </html>"
                    );

            TempData["success"] = $"New OTP has been sent to {user.FullName}'s email.";
            TempData.Keep("email");
            return RedirectToAction("VerifyOtp");
        }

        [HttpPost]
        public IActionResult ExpireOtp()
        {
            TempData.Remove("Otp");
            return Json(new { success = true });
        }


        // Allow to display the reset password page
        [HttpGet]
        public async Task<IActionResult> ResetPassword()
        {
            var emailTemp = TempData["email"];
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == emailTemp);
            if (user == null)
            {
                TempData.Keep("email");
                TempData["error"] = "Email does not exist.";
                return RedirectToAction("ForgotPassword");
            }
            TempData["email"] = emailTemp;
            return View();
        }

        // Allow to handle reset password form submission
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            /*if (ModelState.IsValid)
            {*/
                var emailTemp = TempData["email"];
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == emailTemp);
                if (user == null)
                {
                    TempData["error"] = "Email does not exist.";
                    TempData.Keep("email");
                    return View(model);
                }
                if (model.Password != model.ConfirmPassword)
                {
                    TempData["error"] = "Password and confirm password not match!";
                    TempData.Keep("email");
                    return View(model);
                }
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                user.UpdatedAt = DateTime.Now;
                try
                {
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Reset Password successfully.";
                    return RedirectToAction("Signin");
                }
                catch (Exception)
                {
                    TempData["error"] = "Failed to reset password.";
                    TempData.Keep("email");
                    return View(model);
                }
            /*}
            return View(model);*/
        }

        // Allow to display the access denied page
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }

        // Allow to sign out the user
        public async Task<IActionResult> Signout()
        {
            await _signInManager.SignOutAsync();

            TempData["success"] = "Sign Out successfully.";
            return RedirectToAction("Signin");
        }
    }
}
