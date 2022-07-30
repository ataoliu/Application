using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Application.Util.Operator
{
    public class OperatorProvider : OperatorIProvider
    {
        #region 静态实例
        /// <summary>
        /// 当前提供者
        /// </summary>
        public static OperatorIProvider Provider => new OperatorProvider();
        /// <summary>
        /// 给app调用
        /// </summary>
        public static string AppUserId
        {
            set;
            get;
        }


        #endregion
        /// <summary>
        /// 写入登录信息
        /// </summary>
        /// <param name="user">成员信息</param>
        public virtual void AddCurrent(Operator user)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 当前用户
        /// </summary>
        /// <returns></returns>
        public virtual Operator Current()
        {
            try
            {
                Operator user = null;
                IHttpContextAccessor ih = new HttpContextAccessor();
                var claims = ih.HttpContext.User.Claims;
                if (claims.Count() > 0)
                {
                    user = new Operator();
                    DateTime.TryParse(claims.FirstOrDefault(s => s?.Type == "LogTime").Value, out DateTime LogTime);
                    Guid.TryParse(claims.FirstOrDefault(s => s?.Type == "UserId").Value, out Guid UserId);
                    user.UserName = claims.FirstOrDefault(s => s?.Type == "UserName").Value;
                    user.UserId = UserId;
                    user.LogTime = LogTime;
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 删除登录信息
        /// </summary>
        public virtual void EmptyCurrent()
        {

        }
        /// <summary>
        /// 是否过期
        /// </summary>
        /// <returns></returns>
        public virtual bool IsOverdue()
        {
            return false;
        }
        /// <summary>
        /// 是否已登录
        /// </summary>
        /// <returns></returns>
        public virtual int IsOnLine()
        {
            return 1;
        }
    }
}

