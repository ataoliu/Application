using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Entity.DataManager
{
    /// <summary>
    /// ClaimsIdentity
    /// </summary>
    [Table("Base_ClaimsIdentity")]
    public class ClaimsIdentityEntity : BaseEntity
    {
        /// <summary>
        ///	用户ID
        /// </summary>
        public Guid  UserId { get; set; }
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
}

