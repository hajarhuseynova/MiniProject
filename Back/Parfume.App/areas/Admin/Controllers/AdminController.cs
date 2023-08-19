using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.App.ViewModels;
using Parfume.Core.Entities;

namespace Parfume.App.areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class AdminController : Controller
    {
        private readonly ParfumeDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(ParfumeDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            List<AppUser> admins = new List<AppUser>();
            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    admins.Add(user);
                }
            }
            return View(admins);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            AppUser Admin = new AppUser
            {
                Name = registerViewModel.Name,
                Surname = registerViewModel.Surname,
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,
                EmailConfirmed = true
            };
            await _userManager.CreateAsync(Admin, registerViewModel.Password);
            await _userManager.AddToRoleAsync(Admin, "Admin");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var users = await _context.Users.ToListAsync();
            List<AppUser> Admins = new List<AppUser>();
            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    Admins.Add(user);
                }
            }
            var updateuser = Admins.FirstOrDefault(x => x.Id == id);
            UserUpdateViewModel userUpdateViewModel = new UserUpdateViewModel()
            {
                Name = updateuser.Name,
                Surname = updateuser.Surname,
                UserName = updateuser.UserName,
                Email = updateuser.Email,
            };
            return View(userUpdateViewModel);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Update(string id, UserUpdateViewModel userUpdateViewModel)
        {
            var users = await _context.Users.ToListAsync();
            List<AppUser> admins = new List<AppUser>();
            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    admins.Add(user);
                }
            }
            var updateuser = admins.FirstOrDefault(x => x.Id == id);
            if (!ModelState.IsValid)
            {
                return View(userUpdateViewModel);
            }
            if (updateuser is null)
            {
                return NotFound();
            }
            updateuser.Name = userUpdateViewModel.Name;
            updateuser.Surname = userUpdateViewModel.Surname;
            updateuser.UserName = userUpdateViewModel.UserName;
            updateuser.Email = userUpdateViewModel.Email;
            var result = await _userManager.UpdateAsync(updateuser);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(userUpdateViewModel);
            }
            if (!string.IsNullOrWhiteSpace(userUpdateViewModel.NewPassword))
            {
                result = await _userManager.ChangePasswordAsync(updateuser, userUpdateViewModel.CurrentPassword, userUpdateViewModel.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(userUpdateViewModel);
                }

            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var users = await _context.Users.ToListAsync();
            List<AppUser> admins = new List<AppUser>();
            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    admins.Add(user);
                }
            }
            var remove = admins.FirstOrDefault(x => x.Id == id);
            if (remove is null)
            {
                return NotFound();
            }
            _context.Users.Remove(remove);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
    }
