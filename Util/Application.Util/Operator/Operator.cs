using System;
namespace Application.Util.Operator
{
    public class Operator
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
        public string IPAddress { get; set; }
        /// <summary>
        /// 登录IP地址所在地址
        /// </summary>
        public string IPAddressName { get; set; }
        /// <summary>
        /// Mac地址
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        /// 操作者类型
        /// </summary>
        public OperatorTypeEnum OperatorType { get; set; }

        /// <summary>
        /// 用户数据权限
        /// </summary>
        //public AuthorizeDataModel DataAuthorize { get; set; }

    }
}

