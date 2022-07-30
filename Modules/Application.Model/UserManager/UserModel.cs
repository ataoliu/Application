using System;
using System.ComponentModel;

namespace Application.Model.UserManager
{
    public class UserModel
    {
        /// <summary>
        /// Account
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// PassWord
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Telephone
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// Mobile
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 验证码类型
        /// </summary>
        public CodeType CodeType { get; set; }
    }
    /// <summary>
    /// 验证码类型
    /// </summary>
    public enum CodeType
    {
        
        [Description("验证码")]
        VerificationCode,
        [Description("手机验证")]
        Mobile,
        [Description("邮箱验证")]
        Email,

    }
}

