using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Application.Entity.DataManager
{
    /// <summary>
    /// 跨域
    /// </summary>
    [Table("Base_Cors")]
    public class CorsEntity : BaseEntity
    {
        /// <summary>
        /// 地址
        /// </summary>
        //[MaxLength(20)]
        public string? IPAddress { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        //[MaxLength(50)]
        public string? Description { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// 启用禁用 true 启用 false 禁用
        /// </summary>
        public bool? EnableMark { get; set; }
    }
}

