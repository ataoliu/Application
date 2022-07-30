using System;
using Application.Entity.UserManager;
using Application.Model.UserManager;

namespace Application.IService.UserManager
{
	/// <summary>
    /// UserIService
    /// </summary>
	public interface UserIService
	{
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="account">账号 邮箱 电话 </param>
        /// <param name="passWord">密码</param>
        /// <returns>UserEntity</returns>
        public UserEntity Login(string account, string passWord);
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="entity">用户模型</param>
        public void Register(UserModel user);
        /// <summary>
        /// 判断账号是否存在
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns> true 存在 false 不存在</returns>
        public bool Exists(string account);

        public IEnumerable<UserEntity> GetList();
    }
}

