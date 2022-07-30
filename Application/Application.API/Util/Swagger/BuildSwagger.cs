using System;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Application.API.Util
{
    public static class BuildSwagger
    {
        public static void SwaggerService(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v0.1.0",
                    Title = "Application.API",
                    Description = "框架文档说明",
                    Contact = new OpenApiContact
                    {
                        Name = "atao",
                        Email = "ataoliu@outlook.com"
                    }
                });
                var basePath = AppContext.BaseDirectory;
                var xmalPath = Path.Combine(basePath, "Application.API.xml");
                c.IncludeXmlComments(xmalPath, true);
                var xmlModelPath = Path.Combine(basePath, "Application.Entity.xml");
                c.IncludeXmlComments(xmlModelPath, true);
                // 开启小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                // 在header中添加token，传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {

                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }
    }
}

