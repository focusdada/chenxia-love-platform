using LovePlatform.DTO.WebAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LovePlatform.WebAPI.Middleware
{
    /// <summary>
    /// 模型验证
    /// </summary>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 调用Action前验证Model
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                string errorMessage;
                var firstValue = context.ModelState.Where(m => m.Value.Errors.Count > 0).FirstOrDefault().Value;   //取出第一个错误信息
                if (firstValue.Errors.Count > 0)
                {
                    errorMessage = firstValue.Errors.FirstOrDefault().ErrorMessage;
                }
                else
                {
                    errorMessage = "参数错误";
                }
                context.Result = new OkObjectResult(OutputBase.Fail(errorMessage));
            }
        }
    }
}
