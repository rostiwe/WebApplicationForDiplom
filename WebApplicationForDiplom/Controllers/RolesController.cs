using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using System.Web.Mvc;
using WebApplicationForDiplom.Models;

//namespace WebApplicationForDiplom.Controllers
//{
//    public class RolesController : Controller
//    {
//        RoleManager<IdentityRole> _roleManager;
//        //UserManager<User> _userManager;
//        private ApplicationUserManager _userManager;
//        public ApplicationUserManager UserManager
//        {
//            get
//            {
//                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
//            }
//            private set
//            {
//                _userManager = value;
//            }
//        }
//        public RolesController(RoleManager<IdentityRole> roleManager)
//        {
//            _roleManager = roleManager;
//            //_userManager = userManager;
//        }
//        public ActionResult Index() => View(_roleManager.Roles.ToList());

//        public ActionResult Create() => View();
//        [HttpPost]
//        public async Task<ActionResult> Create(string name)
//        {
//            if (!string.IsNullOrEmpty(name))
//            {
//                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
//                if (result.Succeeded)
//                {
//                    return RedirectToAction("Index");
//                }
//                else
//                {
//                    foreach (var error in result.Errors)
//                    {
//                        ModelState.AddModelError(string.Empty, error);
//                    }
//                }
//            }
//            return View(name);
//        }

//        [HttpPost]
//        public async Task<ActionResult> Delete(string id)
//        {
//            IdentityRole role = await _roleManager.FindByIdAsync(id);
//            if (role != null)
//            {
//                IdentityResult result = await _roleManager.DeleteAsync(role);
//            }
//            return RedirectToAction("Index");
//        }

//        public ActionResult UserList() => View(_userManager.Users.ToList());

//        public async Task<ActionResult> Edit(string userId)
//        {
//            // получаем пользователя
//            User user = await _userManager.FindByIdAsync(userId);
//            if (user != null)
//            {
//                // получем список ролей пользователя
//                var userRoles = await _userManager.GetRolesAsync(user);
//                var allRoles = _roleManager.Roles.ToList();
//                ChangeRoleViewModel model = new ChangeRoleViewModel
//                {
//                    UserId = user.Id,
//                    UserEmail = user.Email,
//                    UserRoles = userRoles,
//                    AllRoles = allRoles
//                };
//                return View(model);
//            }

//            return NotFound();
//        }
//        [HttpPost]
//        public async Task<IActionResult> Edit(string userId, List<string> roles)
//        {
//            // получаем пользователя
//            User user = await _userManager.FindByIdAsync(userId);
//            if (user != null)
//            {
//                // получем список ролей пользователя
//                var userRoles = await _userManager.GetRolesAsync(user);
//                // получаем все роли
//                var allRoles = _roleManager.Roles.ToList();
//                // получаем список ролей, которые были добавлены
//                var addedRoles = roles.Except(userRoles);
//                // получаем роли, которые были удалены
//                var removedRoles = userRoles.Except(roles);

//                await _userManager.AddToRolesAsync(user, addedRoles);

//                await _userManager.RemoveFromRolesAsync(user, removedRoles);

//                return RedirectToAction("UserList");
//            }

//            return NotFound();
//        }

//    }
//}