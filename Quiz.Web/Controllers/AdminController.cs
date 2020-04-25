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
    //[Authorize(Roles = "Admin")]
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
            //De view ontvangt een @model IEnumerable<IdentityRole> 
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
            IdentityResult result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("IndexRoles", _roleManager.Roles);
            }
            else
            {
                ModelState.AddModelError("", $"Not Found: {result.Errors}");
                //throw new Exception("Not Found");
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Role role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
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
            try
            {
                if (id == null)
                {
                    throw new Exception("Bad Delete Request.");
                }
                Role role = await _roleManager.FindByIdAsync(id);
                //hier moet je eigenlijk nog controlere of het de rol wel degelijk kan vinden ... ma fack da
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("IndexRoles", _roleManager.Roles);
                }
                else
                {
                    ModelState.AddModelError("", $"Not Found: {result.Errors}");
                    //throw new Exception("Not Found");
                    return NotFound();
                }
            }
            catch (Exception exc)
            {
                ModelState.AddModelError(String.Empty, $"Delete failed: {exc.Message}");
                return View();
            }
        }


        public ActionResult IndexUsers()
        {
            //De view ontvangt een @model IEnumerable<User> 
            var users = _userManager.Users;
            return View(users);
        }

        //details van user
        public async Task<IActionResult> User(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            var userroles = await _userManager.GetRolesAsync(user);
            User_VM viewmodel = new User_VM() { Email = user.Email, Name = user.Name, Id = user.Id, Roles = userroles };
            return View(viewmodel);
        }
        public async Task<IActionResult> DeleteUser(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            User_VM viewmodel = new User_VM() { Email = user.Email, Name = user.Name, Id = user.Id };
            return View(viewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id, IFormCollection collection)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("Bad Delete Request.");
                }
                User role = await _userManager.FindByIdAsync(id);
                if (role == null)
                {
                    throw new Exception("Can't find user");
                }
                IdentityResult result = await _userManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("IndexUsers", _roleManager.Roles);
                }
                else
                {
                    ModelState.AddModelError("", $"Not Found: {result.Errors}");
                    //throw new Exception("Not Found");
                    return NotFound();
                }
            }
            catch (Exception exc)
            {
                ModelState.AddModelError(String.Empty, $"Delete failed: {exc.Message}");
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditRoles(string id)
        {

            if (String.IsNullOrEmpty(id))
            {
                throw new Exception("Bad Delete Request.");
            }
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new Exception("Bad Delete Request.");
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
                throw new Exception("Bad Request.");
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
                            throw new Exception("Not Found");
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
                            throw new Exception("Not Found");
                        }
                    }
                }
            }
            return RedirectToAction(nameof(IndexUsers));
        }


        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}