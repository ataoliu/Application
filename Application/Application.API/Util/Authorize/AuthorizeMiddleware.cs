using System;
using Application.IService.DataManager;
using Application.Service.DataManager;
using Application.Util.Extention;

namespace Application.API.Util
{
    /// <summary>
    /// 授权拦截中间件
    /// </summary>
    public class AuthorizeMiddleware
    {
        private readonly ClaimsIdentityIService _claimsIdentityIService;
        private readonly RequestDelegate _requestDelegate;
        public AuthorizeMiddleware(RequestDelegate requestDelegate, ClaimsIdentityService claimsIdentityService)
        {
            _requestDelegate = requestDelegate;
            _claimsIdentityIService = claimsIdentityService;
        }

       public  async Task InvokeAsync(HttpContext httpContext)
        {

            var claims = httpContext.User.Claims;
            string refreshToken = "";
            if (claims.Count() > 0)
            {
                refreshToken = claims.FirstOrDefault(s => s?.Type == "RefreshToken").Value;
            }
            if (!refreshToken.IsEmpty())
            {
                //读数据库的token以及过期时间
                var res = _claimsIdentityIService.Expired(Guid.Parse(refreshToken));
                if (res)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return;
                }


            }



            await _requestDelegate(httpContext);
        }


    }
    public static class AuthorizeMiddlewareExtensions
    {
        public static void UseAuthorizeMiddleware(this WebApplication app)
        {

            app.UseMiddleware<AuthorizeMiddleware>();
        }
    }

}