using System;
using Application.Util.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Application.API.Util
{
    /// <summary>
    /// 注入其他服务
    /// </summary>
    public static class BuildOtherService
    {
        public static void AddApplicationOtherService(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            builder.Services.AddSingleton(new JwtHelper(configuration));//jwt


        }
    }
}

