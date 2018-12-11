using LovePlatform.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LovePlatform.WebAdmin.Middleware
{
    public class CustomAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session.GetString(CommConstant.AdminLoginCurrentUser);
            if (string.IsNullOrEmpty(session))
            {
                filterContext.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
