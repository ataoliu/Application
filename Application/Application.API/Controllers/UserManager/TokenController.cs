using Application.Busines.DataManager;
using Application.Busines.UserManager;
using Application.IBusines.DataManager;
using Application.IBusines.UserManager;
using Application.Util.Helper;
using Application.Util.Model;
using Application.Util.Operator;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers.UserManager
{
    [Route("api")]
    [ApiController]
    public class TokenController : BaseController
    {
        private readonly JwtHelper _jwtHelper;
        private readonly UserIBLL _userBLL;
        private readonly ClaimsIdentityIBLL _claimsIdentityIBLL;

        public TokenController(JwtHelper jwtHelper, UserBLL userBLL, ClaimsIdentityBLL claimsIdentityBLL)
        {
            _jwtHelper = jwtHelper;
            _userBLL = userBLL;
            _claimsIdentityIBLL = claimsIdentityBLL;
        }
        [HttpPost]
        [Route("/token")]
        public TokenMode Token(User user)
        {
         
            //验证账号
            var usr = _userBLL.Login(user.account, user.password);
            UserTokenModel model = new UserTokenModel();
            model.UserId = usr.Id;
            model.UserName = usr.UserName;
            model.Account = usr.Account;
            //获取token
            var res = _claimsIdentityIBLL.CreateToken(model);
            return res;
        }
    }
    public class User
    {
        public string password { get; set; } = "1111";
        public string account { get; set; } = "admin";
    }
}
