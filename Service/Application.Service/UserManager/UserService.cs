using System;
using Application.Data.Repository;
using Application.Entity.UserManager;
using Application.IService.UserManager;
using Application.Model.UserManager;
using Application.Util;
using Application.Util.Extention;

namespace Application.Service.UserManager
{
    public class UserService : RepositoryFactory<UserEntity>, UserIService
    {
  

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="account">account email iphone </param>
        /// <param name="passWord">pwd</param>
        /// <returns>UserEntity</returns>
        public UserEntity Login(string account, string passWord)
        {
            var expression = LinqExtensions.True<UserEntity>();
            expression = expression.And(s => s.Account == account || s.Email == account || s.Telephone == account || s.Mobile == account);
            var userList = BaseRepository().IQueryable(expression);
            if (userList.Count() == 1)
            {
                var user = userList.First();
                if (user.Password == $"{passWord.ToSHA1String()}{user.SecretKey}".ToMD5String())
                    return userList.FirstOrDefault();
                else
                    throw new ApplicationException("密码错误");
            }
           else if (userList.Count() == 0)
            {
                throw new ApplicationException("账号密码不存在");
            }
            else
            {
                throw new ApplicationException("账号密码出现异常");
            }

        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ApplicationException"></exception>
        public void Register(UserModel user)
        {
            if (Exists(user.Account))
            {
                throw new ApplicationException("账号已经存在");
            }
            else
            {
                UserEntity entity = new UserEntity();
                entity.SecretKey = new Security(30).SecretKey;
                entity.Password = (user.PassWord.ToSHA1String() + entity.SecretKey).ToMD5String();
                entity.Account = user.Account;
                entity.Mobile = user.Mobile;
                entity.UserName = user.UserName;
                entity.Telephone = user.Telephone;
                entity.Create();
                BaseRepository().Insert(entity)
 ;            }
        }
        /// <summary>
        /// 判断账号是否存在
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns> true 存在 false 不存在</returns>
        public bool Exists(string account)
        {
            var expression = LinqExtensions.True<UserEntity>();
            expression = expression.And(s => s.DeleteMark == false);
            expression = expression.And(s => s.Account == account);
            var list = BaseRepository().IQueryable(expression);
            return list.Count() == 0 ? false : true;
        }

        public IEnumerable<UserEntity> GetList()
        {
            return BaseRepository().FindList("select *from Base_User");
        }
    }
}

