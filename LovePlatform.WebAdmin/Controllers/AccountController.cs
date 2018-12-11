using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LovePlatform.DTO.WebAdmin;
using LovePlatform.Common;
using LovePlatform.WebAdmin.Middleware;
using LovePlatform.Service;

namespace LovePlatform.WebAdmin.Controllers
{
    public class AccountController : Controller
    {
        private readonly AdministratorService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public AccountController(AdministratorService service)
        {
            _service = service; 
        }

        public IActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginInput model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var currentUser = await _service.Login(model);
            if (currentUser != null)
            {
                HttpContext.Session.Set(CommConstant.AdminLoginCurrentUser, currentUser);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "用户名或密码错误");
            return View();
        }

        [CustomAuthentication]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove(CommConstant.AdminLoginCurrentUser);
            return RedirectToAction("Login", "Account");
        }
    }
}