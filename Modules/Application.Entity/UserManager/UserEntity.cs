using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Entity.UserManager
{
	/// <summary>
    /// 用户类
    /// </summary>
    [Table("Base_User")]
    public class UserEntity: BaseEntity
	{
        /// <summary>
        /// 用户名称
        /// </summary>
        public string? UserName { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        public string? Account { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>		
        public string? Password { get; set; }
        /// <summary>
        /// 密码秘钥
        /// </summary>		
        public string? SecretKey { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>		
        public string? RealName { get; set; }
        /// <summary>
        /// 呢称
        /// </summary>		
        public string? NickName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>		
        public string? HeadIcon { get; set; }
        /// <summary>
        /// 性别
        /// </summary>		
        public int? Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>		
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 手机
        /// </summary>		
        public string? Mobile { get; set; }
        /// <summary>
        /// 电话
        /// </summary>		
        public string? Telephone { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>		
        public string? Email { get; set; }
        /// <summary>
        /// QQ号
        /// </summary>		
        public string? OICQ { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>		
        public string? WeChat { get; set; }
        /// <summary>
        /// 有效标志
        /// </summary>		
        public bool EnabledMark { get; set; }
        /// <summary>
        /// 操作者角色
        /// </summary>		
        public byte? OperatorType { get; set; }

    }
}

