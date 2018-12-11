using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LovePlatform.Domain.Models;
using LovePlatform.Service;
using Microsoft.AspNetCore.Mvc;

namespace LovePlatform.WebAdmin.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdministratorService _service;

        /// <summary>
        /// ¹¹Ôìº¯Êý
        /// </summary>
        /// <param name="service"></param>
        public AdminController(AdministratorService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var items = await _service.Get();
            return PartialView("_ListPartial", items);
        }

        public async Task<IActionResult> Add()
        {
            return PartialView("_AddPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Administrator admin)
        {
            if (!ModelState.IsValid)
            {
                return View(admin);
            }
            _service.AddAdmin(admin);
            return Content("");
        }

        public async Task<IActionResult> Edit(long id)
        {
            var admin = await _service.Get(id);
            return PartialView("_EditPartial", admin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Administrator admin)
        {
            if (!ModelState.IsValid)
            {
                return View(admin);
            }
            await _service.UpdateAdmin(admin);
            return Content("");
        }
    }
}