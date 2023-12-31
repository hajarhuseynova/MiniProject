﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Parfume.App.Services.İnterfaces;
using Parfume.App.ViewModels;
using Parfume.Core.Entities;
using System.Text.RegularExpressions;

namespace Parfume.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailService _mailService;
        private readonly SignInManager<AppUser> _signinManager;
        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, IMailService mailService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signinManager = signinManager;
            _mailService = mailService;
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(registerViewModel.UserName == null|| registerViewModel.Password == null|| registerViewModel.ConfirmPassword == null|| registerViewModel.Email == null
                || registerViewModel.Name == null|| registerViewModel.Surname == null)
            {
                return RedirectToAction("register", "account");
            }

            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            Regex regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!regex.IsMatch(registerViewModel.Email))
            {
             
                return RedirectToAction("register", "account");
            }

            AppUser appUser = new AppUser();
            appUser.Email = registerViewModel.Email;
            appUser.Name = registerViewModel.Name;
            appUser.Surname = registerViewModel.Surname;
            appUser.UserName = registerViewModel.UserName;

            IdentityResult identityResult = await _userManager.CreateAsync(appUser, registerViewModel.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerViewModel);
            }
            await _userManager.AddToRoleAsync(appUser, "User");

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

            var link = Url.Action(action: "VerifyEmail", controller: "account",
              values: new { token = token, email = appUser.Email },
              protocol: Request.Scheme);

            await _mailService.Send("hajarih@code.edu.az", appUser.Email, link, "Emaili təsdiqlə");

            TempData["register"] = "Zəhmət olmasa emailinizi təsdiqləyin!";
            return RedirectToAction("index", "home");
        }
        public async Task<IActionResult> VerifyEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                NotFound();
            }
            await _userManager.ConfirmEmailAsync(user, token);
            await _signinManager.SignInAsync(user, true);
            return RedirectToAction(nameof(Info));

        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

            if (loginViewModel.UserName==null||loginViewModel.Password==null)
            {
                return RedirectToAction("login", "account");
            }
           
            AppUser appUser = await _userManager.FindByNameAsync(loginViewModel.UserName);


            if (appUser == null)
            {
                ModelState.AddModelError("", "İstifadəçi adı və ya şifrə yanlışdır");
                return View();
            }
         
            var role = await _userManager.GetRolesAsync(appUser);
            foreach (var roles in role)
            {
                if (roles != "User")
                {
                    ModelState.AddModelError("", "Səhv!");
                    return View();
                }

            }
            var result = await _signinManager.PasswordSignInAsync(appUser, loginViewModel.Password, loginViewModel.isRememberMe, true);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "5 dəqiqəlik kilidlənmə!");
                    return View();
                }
                ModelState.AddModelError("", "İstifadəçi adı və ya şifrə yanlışdır");
                return View();
            }
            TempData["Login"] = "Daxil oldunuz!";
            return RedirectToAction("index", "home");

        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            TempData["Logout"] = "Səhifədən ayrıldınız!";

            return RedirectToAction("index", "home");
        }
        [Authorize]
        public async Task<IActionResult> Info()
        {
            string UserName = User.Identity.Name;
            AppUser appUser = await _userManager.FindByNameAsync(UserName);

            return View(appUser);
        }
        [Authorize]
        public async Task<IActionResult> Update()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }
            UserUpdateViewModel userUpdateView = new UserUpdateViewModel
            {
                Name = user.UserName,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName
            };
            return View(userUpdateView);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (user == null)
            {
                return NotFound();
            }
            user.Name = model.UserName;
            user.Surname = model.Surname;
            user.UserName = model.UserName;
            user.Email = model.Email;
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
            if (!string.IsNullOrWhiteSpace(model.NewPassword))
            {
                result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
            }
            await _signinManager.SignInAsync(user, true);

            return RedirectToAction(nameof(Info));
        }
        [HttpGet]
        public async Task<IActionResult> ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(string? email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                TempData["EmailNotFound"] = "Email tapılmadı!";
                return RedirectToAction("forgetpassword", "account");
            }
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);

            UriBuilder uriBuilder = new UriBuilder();

            var link = Url.Action(action: "resetpassword", controller: "account",
                values: new { token = token, email = email },
                protocol: Request.Scheme);
            await _mailService.Send("hajarih@code.edu.az", user.Email, link, "Reset password");
            TempData["Forget"] = "Zəhmət olmasa emailinizi yoxlayın!";
            return RedirectToAction("index", "home");
        }
        [HttpGet]
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            ResetPasswordViewModel resetPasswordViewModel = new ResetPasswordViewModel
            {
                Token = token,
                Email = email
            };
            return View(resetPasswordViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPassword)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPassword);
            }
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user == null)
            {
                return NotFound();

            }
            if (resetPassword.Password == null || resetPassword.ConfirmPassword == null)
            {
                return NotFound();
            }
            var result = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
            if (!result.Succeeded)
            {
                TempData["FalsePassword"] = "Uyğun deyil!";
                return View();

            }
            TempData["TruePassword"] = "Uğurlu!";
            return RedirectToAction("login", "account");

        }
       
        #region Roles
        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole identityRole1 = new IdentityRole { Name = "SuperAdmin" };
        //    IdentityRole identityRole2 = new IdentityRole { Name = "Admin" };
        //    IdentityRole identityRole3 = new IdentityRole { Name = "User" };

        //    await _roleManager.CreateAsync(identityRole1);

        //    await _roleManager.CreateAsync(identityRole2);

        //    await _roleManager.CreateAsync(identityRole3);

        //    return Json("OK");
        //}
        #endregion
    }
}
