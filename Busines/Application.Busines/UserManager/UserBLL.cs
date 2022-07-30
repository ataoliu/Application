using System;
using Application.Entity.UserManager;
using Application.IBusines.UserManager;
using Application.IService.UserManager;
using Application.Model.UserManager;
using Application.Service.UserManager;
using Application.Util.Extention;

namespace Application.Busines.UserManager
{
    public class UserBLL : UserIBLL
    {
        private readonly UserIService _service;

        public UserBLL(UserService service)
        {
            _service = service;

        }

        public IEnumerable<UserEntity> GetList()
        {
            return _service.GetList();
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="account">account email iphone </param>
        /// <param name="passWord">pwd</param>
        /// <returns>UserEntity</returns>
        public UserEntity Login(string account, string passWord)
        {
            return _service.Login(account, passWord);
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user">用户模型</param>
        public void Register(UserModel user)
        {
             _service.Register(user);
        }
    }
}

