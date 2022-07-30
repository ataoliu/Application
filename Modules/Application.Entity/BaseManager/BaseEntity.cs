using System;
using System.ComponentModel.DataAnnotations;
using Application.Util.Operator;

namespace Application.Entity
{
    /// <summary>
    /// 实体基础类
    /// CreateTime:2022.4.28.21.01
    /// </summary>
	public abstract class BaseEntity
    {
        #region base entity
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 创建用户名称
        /// </summary>
        public string? CreateUserName { get; set; }
        /// <summary>
        /// 创建用户Id
        /// </summary>
        public Guid? CreateUserId { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// 修改用户名称
        /// </summary>
        public string? ModifyUserName { get; set; }
        /// <summary>
        /// 修改用户Id
        /// </summary>
        public Guid? ModifyUserId { get; set; }
        /// <summary>
        /// 删除标识 false 未删除 true 删除
        /// </summary>
        public bool? DeleteMark { get; set; }
        #endregion
        #region base method
        /// <summary>
        /// 创建调用
        /// </summary>
        public virtual void Create()
        {
            Operator user = OperatorProvider.Provider.Current();
            this.Id = Guid.NewGuid();
            this.CreateDate = DateTime.Now;
            this.DeleteMark = false;
            this.CreateUserId = user?.UserId;
            this.CreateUserName = user?.UserName;
        }
        /// <summary>
        /// 修改调用
        /// </summary>
        public virtual void Modify()
        {
            this.ModifyDate = DateTime.Now;
            Operator user = OperatorProvider.Provider.Current();
            this.ModifyUserId = user?.UserId;
            this.ModifyUserName = user?.UserName;
        }
        /// <summary>
        /// 删除调用
        /// </summary>

        public virtual void Remove()
        {
            DeleteMark = true;
            Operator user = OperatorProvider.Provider.Current();
            this.ModifyUserId = user?.UserId;
            this.ModifyUserName = user?.UserName;
        }
        #endregion

    }
}

