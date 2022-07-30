using System;
using Application.Util.Operator;

namespace Application.Util.Model
{
    public class TokenMode
    {
       public  string Type { get {return "Bearer"; } }
        /// <summary>
        /// AccessToken
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// RefreshToken
        /// </summary>
        public Guid RefreshToken { get; set; }
        /// <summary>
        /// ExpirationTime
        /// </summary>
        public DateTime ExpirationTime { get; set; }
    }
    public class UserTokenModel
    {
        /// <summary>
        /// 用户主键
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登陆账户
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LogTime { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 登录IP地址
        /// </summary>
        public string IPAddress { get; set; }="";
        /// <summary>
        /// 登录IP地址所在地址
        /// </summary>
        public string IPAddressName { get; set; }

        /// <summary>
        /// 操作者类型
        /// </summary>
        public OperatorTypeEnum? OperatorType { get; set; }
    }
}

