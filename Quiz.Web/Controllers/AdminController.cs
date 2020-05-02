using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiz.Models;
using Quiz.Models.DTO;
using Quiz.Web.ViewModels;

namespace Quiz.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public AdminController(RoleManager<Role> roleMgr, UserManager<User> userMgr)
        {
            this._roleManager = roleMgr;
            this._userManager = userMgr;
        }

        public ActionResult IndexRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult CreateRole() => View();
        [HttpPost]
        public async Task<IActionResult> CreateRole(AddRole_VM addRoleVM)
        {
            if (!ModelState.IsValid) return View(addRoleVM);
            var role = new Role()
            {
                Name = addRoleVM.RoleName
            };
            if (await _roleManager.RoleExistsAsync(role.Name))
            {
                ModelState.AddModelError("", "This role name already exists");
                return View(addRoleVM);
            }
            IdentityResult result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("IndexRoles", _roleManager.Roles);
            }
            else
            {
                return Redirect("/Error/0");
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (id == null)
            {
                return Redirect("/Error/400");
            }
            Role role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return Redirect("/Error/404");
            }
            DeleteRole_VM deleted = new DeleteRole_VM()
            {
                RoleId = role.Id,
                RoleName = role.Name
            };
            return View(deleted);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id, IFormCollection collection)
        {
            if (id == null)
            {
                return Redirect("/Error/400");
            }
            Role role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return Redirect("/Error/404");

            }
            IdentityResult result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("IndexRoles", _roleManager.Roles);
            }
            else
            {
                return Redirect("/Error/404");
            }
        }


        public ActionResult IndexUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }

        public async Task<IActionResult> User(string id)
        {
            if (id == null)
            {
                return Redirect("/Error/400");
            }
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return Redirect("/Error/404");
            }
            var userroles = await _userManager.GetRolesAsync(user);
            User_VM viewmodel = new User_VM() { Email = user.Email, Name = user.Name, Id = user.Id, Roles = userroles };
            return View(viewmodel);
        }
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (id == null)
            {
                return Redirect("/Error/400");
            }
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return Redirect("/Error/404");
            }
            User_VM viewmodel = new User_VM() { Email = user.Email, Name = user.Name, Id = user.Id };
            return View(viewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id, IFormCollection collection)
        {
            if (id == null)
            {
                return Redirect("/Error/400");
            }
            User role = await _userManager.FindByIdAsync(id);
            if (role == null)
            {
                return Redirect("/Error/404");
            }
            IdentityResult result = await _userManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("IndexUsers", _roleManager.Roles);
            }
            else
            {
                return Redirect("/Error/0");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditRoles(string id)
        {

            if (String.IsNullOrEmpty(id))
            {
                return Redirect("/Error/400");
            }
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return Redirect("/Error/404");
            }
            EditRoles_VM viewmodel = new EditRoles_VM() { Id = user.Id, Name = user.Name };

            foreach (var role in _roleManager.Roles)
            {
                viewmodel.Roles.Add(role.Name, await _userManager.IsInRoleAsync(user, role.Name));
            }
            return View(viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> EditRoles(EditRoles_VM viewmodel)
        {
            var user = await _userManager.FindByIdAsync(viewmodel.Id);
            if (user == null)
            {
                return Redirect("/Error/404");
            }
            foreach (KeyValuePair<string, bool> pair in viewmodel.Roles)
            {
                if (pair.Value)
                {
                    Role role = await _roleManager.FindByNameAsync(pair.Key);
                    if (!await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        var result = await _userManager.AddToRoleAsync(user, role.Name);
                        if (!result.Succeeded)
                        {
                            return Redirect("/Error/0");
                        }
                    }
                }
                else
                {
                    Role role = await _roleManager.FindByNameAsync(pair.Key);
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                        if (!result.Succeeded)
                        {
                            return Redirect("/Error/0");
                        }
                    }
                }
            }
            return RedirectToAction(nameof(IndexUsers));
        }
    }
}