using System;
using Application.Entity.UserManager;
using Application.Model.UserManager;

namespace Application.IBusines.UserManager
{
	public interface UserIBLL
	{
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="account">account email iphone </param>
        /// <param name="passWord">pwd</param>
        /// <returns>UserEntity</returns>
        public UserEntity Login(string account, string passWord);
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user">用户模型</param>
        public void Register(UserModel user);

        public IEnumerable<UserEntity> GetList();
    }
}

