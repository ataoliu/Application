using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Application.API.Util
{
    public static class AuthenticationService
    {
        public static void AddAuthenticationService(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true, //是否验证Issuer
                    ValidIssuer = configuration["Jwt:Issuer"], //发行人Issuer
                    ValidateAudience = true, //是否验证Audience
                    ValidAudience = configuration["Jwt:Audience"], //订阅人Audience
                    ValidateIssuerSigningKey = true, //是否验证SecurityKey
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])), //SecurityKey
                    ValidateLifetime = true, //是否验证失效时间
                    ClockSkew = TimeSpan.FromSeconds(60 * 60 * 24), //过期时间容错值，解决服务器端时间不同步问题（秒）
                    RequireExpirationTime = true,
                };
            });//jwt
        }
    }
}

