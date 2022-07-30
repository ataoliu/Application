using Application.Busines.UserManager;
using Application.Entity.UserManager;
using Application.IBusines.UserManager;
using Application.Model.UserManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Application.API.Controllers.UserManager
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : BaseController
    {
        private readonly UserIBLL _userBLL;
        public UserController(UserBLL userBLL)
        {
            _userBLL = userBLL;
        }
        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="user"></param>
        /// <returns>MenuEntity</returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(UserModel user)
        {
            try
            {
                _userBLL.Register(user);
                return Success("注册成功");
            }
            catch (Exception ex)
            {
                return Error($"注册失败:{ex.Message}");
            }

        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<UserEntity>> GetList()
        {
            return Success("操作成功", _userBLL.GetList());
        }
    }
}

