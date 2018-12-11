using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LovePlatform.DTO.WebAdmin;
using LovePlatform.Common;

namespace LovePlatform.WebAdmin.Middleware
{
    public class BaseController : Controller
    {
        public AdminLoginUserInfo CurrentLoginUser
        {
            get
            {
                return HttpContext.Session.Get<AdminLoginUserInfo>(CommConstant.AdminLoginCurrentUser);
            }
        }
    }
}