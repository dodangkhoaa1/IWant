using IWant.BusinessObject.Enitities;
using IWant.Web.Models;
using IWant.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IWant.Web.Controllers
{
    public class IdentityController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender emailSender;

        public IdentityController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this.emailSender = emailSender;
        }

        public async Task<IActionResult> Signup()
        {
            var model = new SignupViewModel() { Role = "Member" };
            return View(model);
        }

        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, returnUrl);
            var callbackUrl = Url.Action("ExternalLoginCallback");
            properties.RedirectUri = callbackUrl;
            return Challenge(properties, provider);
        }

        public async Task<IActionResult> ExternalLoginCallback()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            var emailClaim = info.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            var user = new IdentityUser { Email = emailClaim.Value, UserName = emailClaim.Value };
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "MEMBER");
            }
            await _userManager.AddLoginAsync(user, info);
            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }

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
                        ModelState.AddModelError("ConfirmPassword", "Password and confirm password not match!");
                        return View(model);
                    }
                    var user = new User
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        FullName = model.FullName,
                        Avatar = "",
                        Birthday = model.Birthday,
                        Status = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, model.Role);
                        return RedirectToAction("Signin");
                    }

                    /* user = await _userManager.FindByEmailAsync(model.Email);

                     var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                     if (result.Succeeded)
                     {
                         var confirmationLink = Url.ActionLink("ConfirmEmail", "Identity", new { userId = user.Id, @token = token });

                         await emailSender.SendEmailAsync("nhathmce170171@fpt.edu.vn", user.Email, "Confirm your email address", confirmationLink);

                         return RedirectToAction("Signin");
                     }*/

                    ModelState.AddModelError("Signup", string.Join("", result.Errors.Select(x => x.Description)));
                    return View(model);
                }
                else
                {
                    ModelState.AddModelError("Signup", "Account was exist");
                    return View(model);
                }
            }
            return View(model);
        }

        /*[Authorize]
        public async Task<IActionResult> MFASetup()
        {
            const string provider = "iwant";
            var user = await _userManager.GetUserAsync(User);
            await _userManager.ResetAuthenticatorKeyAsync(user);
            var token = await _userManager.GetAuthenticatorKeyAsync(user);
            var qrCodeUrl = $"otpauth://totp/{provider}:{user.Email}?secret={token}&issuer={provider}&digits=6";

            var model = new MFAViewModel { Token = token ,QRCodeUrl = qrCodeUrl};
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> MFASetup(MFAViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var succeeded = await _userManager.VerifyTwoFactorTokenAsync(user, _userManager.Options.Tokens.AuthenticatorTokenProvider, model.Code);
                if (succeeded)
                {
                    await _userManager.SetTwoFactorEnabledAsync(user, true);
                }
                else
                {
                    ModelState.AddModelError("Verify", "Your MFA code could not be validated.");
                }
            }
            return View(model);
        }*/

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return RedirectToAction("Signin");
            }
            return new NotFoundResult();
        }

        public IActionResult Signin()
        {
            return View(new SigninViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Signin(SigninViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (!result.Succeeded)
                {
                    // Kiểm tra từng trường hợp
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("Login", "Your account is locked out.");
                        Console.WriteLine("Sign-in failed: Account is locked out.");
                    }
                    else if (result.IsNotAllowed)
                    {
                        ModelState.AddModelError("Login", "Sign-in not allowed. Email confirmation may be required.");
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
                        ModelState.AddModelError("Login", "Invalid login attempt.");
                        Console.WriteLine("Sign-in failed: Invalid credentials.");
                    }
                }
                else
                {
                    // Đăng nhập thành công
                    Console.WriteLine("Sign-in successful.");
                    return RedirectToAction("Index", "Home");
                }
                /*if (result.RequiresTwoFactor) return RedirectToAction("MFACheck");*/

                /*if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Username);

                    //Get Claim
                    var userClaim = await _userManager.GetClaimsAsync(user);
                    if (!userClaim.Any(x => x.Value == "test"))
                    {
                        ModelState.AddModelError("Claim", "User not in test department");
                        return View(model);
                    }
                    //Check role
                    if (await _userManager.IsInRoleAsync(user, "Member"))
                    {
                        return RedirectToAction("Member", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Admin", "Home");
                    }
                }*/



                /*if (!result.Succeeded)
                {
                    ModelState.AddModelError("Login", "Cannot login.");
                }
                else
                    return RedirectToAction("Index", "Home");*/
            }
            return View(model);
        }

        /*public IActionResult MFACheck()
        {
            return View(new MFACheckViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> MFACheck(MFACheckViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(model.Code, false, false);
                if (result.Succeeded) return RedirectToAction("Index", "Home", null);
            }

            return View(model);
        }*/

        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> Signout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Signin");
        }
    }
}
