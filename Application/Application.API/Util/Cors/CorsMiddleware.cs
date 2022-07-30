using System;
using System.Text.RegularExpressions;
using Application.Busines.DataManager;
using Application.IBusines.DataManager;

namespace Application.API.Util
{
    public class CorsMiddleware
    {
        private readonly CorsIBLL _corsIBLL;
        private readonly RequestDelegate _requestDelegate;
        public CorsMiddleware(RequestDelegate requestDelegate ,CorsBLL corsBLL)
        {
            _requestDelegate = requestDelegate;
            _corsIBLL = corsBLL;
        }
        /// <summary>
        /// 自定义中间件要执行的逻辑
        /// </summary>
        /// <param name="httpContext">b</param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            //http ://4673297.com
            //string pattern = @"(localhost)*(192)";
            //var origin = httpContext.Request.Headers["Origin"];

            //var matchs=  Regex.Matches(origin, pattern);
            //var list = _corsIBLL.GetList();
            // list.Where(s => s.IPAddress == origin);

            //if (matchs?.Count > 0)
            //{

            //}
            httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "");
            httpContext.Response.Headers.Add("Access-Control-Allow-Headers", "");
            httpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            //若为OPTIONS跨域请求则直接返回,不进入后续管道
            if (httpContext.Request.Method.ToUpper() != "OPTIONS")
                await _requestDelegate(httpContext);
        }
    }
    public static class CorsMiddlewareExtensions
    {
        public static void UseCorsMiddleware(this WebApplication app)
        {
            app.UseMiddleware<CorsMiddleware>();
        }
    }
}

