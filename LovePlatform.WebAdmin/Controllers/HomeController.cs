using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LovePlatform.WebAdmin.Middleware;

namespace LovePlatform.WebAdmin.Controllers
{
    [CustomAuthentication]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "User");
        }

        public IActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// 提示信息页面
        /// </summary>
        /// <param name="isSuccess">是否成功</param>
        /// <param name="message">信息内容</param>
        /// <returns></returns>
        public ActionResult Message(bool isSuccess, string message, string url)
        {
            ViewBag.IsSuccessful = isSuccess;
            ViewBag.Message = message;
            ViewBag.Url = url;

            return PartialView("_MessagePartial");
        }
    }
}
