using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using Application.Util.Extention;
using Application.Util.Model;

namespace Application.Util.Helper
{

    public class JwtHelper
    {

        private readonly IConfiguration _configuration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(UserTokenModel user , out Guid refreshToken,out DateTime expirationTime)
        {
            var time = DateTime.Now;
            refreshToken = Guid.NewGuid(); 
             var Issued = _configuration["Jwt:Issued"] ?? "300";
            expirationTime = time.AddSeconds(int.Parse(Issued));
            // 1. 定义需要使用到的Claims
            var claims = new[]
                        {
            //new Claim(ClaimTypes.Name, "u_admin"), //HttpContext.User.Identity.Name
            //new Claim(ClaimTypes.Role, "r_admin"), //HttpContext.User.IsInRole("r_admin")
             //new Claim(JwtRegisteredClaimNames.Jti, "admin"),
            new Claim ("Expires",time.ToJsTimestamp().ToString()),// 颁发时间
            new Claim ("Issued",time.AddSeconds(int.Parse(Issued)).ToJsTimestamp().ToString()),// 到期时间
            new Claim("RefreshToken", refreshToken.ToString()),
            new Claim("UserId", user.UserId.ToString()),
            new  Claim ("UserName",user.UserName),
            new Claim ("IPAddress",user?.IPAddress),
            new Claim("OperatorType",user?.OperatorType.ToString()),
            new Claim("Account",user.Account),
            new Claim("LogTime",time.ToString())


        };
            // 2. 从 appsettings.json 中读取SecretKey
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            // 3. 选择加密算法
            var algorithm = SecurityAlgorithms.HmacSha256;
            // 4. 生成Credentials
            var signingCredentials = new SigningCredentials(secretKey, algorithm);
            // 5. 根据以上，生成token
            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],     //Issuer
                _configuration["Jwt:Audience"],   //Audience
                claims,                          //Claims,
                time,                    //notBefore
                time.AddSeconds(30),    //expires
                signingCredentials              //Credentials

            );

            // 6. 将token变为string
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;
        }
        public string GetUserId()
        {
            IHttpContextAccessor ih = new HttpContextAccessor();
            var Claims = ih.HttpContext.User.Claims;
          
            string userId = "";
            if (Claims.Count() > 0)
            {
                userId = Claims.FirstOrDefault(s => s?.Type == "UserId").Value;
            }
            return userId;
        }

    }


}

