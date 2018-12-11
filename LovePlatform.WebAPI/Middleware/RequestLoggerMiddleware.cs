using LovePlatform.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovePlatform.WebAPI.Middleware
{
    /// <summary>
    /// RequestLoggerMiddleware
    /// </summary>
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public RequestLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            StringBuilder requestStr = new StringBuilder();
            requestStr.AppendFormat("{0}Requset Url：{1}", Environment.NewLine, context.Request.Path);
            requestStr.AppendFormat("{0}Requset Headers：", Environment.NewLine);
            foreach (var header in context.Request.Headers)
            {
                requestStr.AppendFormat("{0}    {1}：{2}", Environment.NewLine, header.Key, string.Join(CommConstant.Comma, header.Value));
            }
            requestStr.AppendFormat("{0}Requset Method：{1}", Environment.NewLine, context.Request.Method);

            //Workaround - copy original Stream
            var initalBody = context.Request.Body;

            using (var bodyReader = new StreamReader(context.Request.Body))
            {
                string body = await bodyReader.ReadToEndAsync();
                requestStr.AppendFormat("{0}Requset Context：{1}", Environment.NewLine, body);
                //Do something with body
                //Replace write only request body with read/write memorystream so you can read from it later

                context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));

                //handle other middlewares
                await _next.Invoke(context);

                //Workaround - return back to original Stream
                context.Request.Body = initalBody;
            }

            //LogHelper.WriteInfo(string.Format("请求信息：{0}", requestStr.ToString()));
        }
    }
}
