using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Entity.DataManager
{
    /// <summary>
    /// MenuEntity
    /// </summary>
    [Table("Base_Menu")]
    public class MenuEntity : BaseEntity
    {
        /// <summary>
        /// Name
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// path
        /// </summary>
        public string? Path { get; set; }
        /// <summary>
        /// icon
        /// </summary>
        public string? Icon { get; set; }
        /// <summary>
        /// key
        /// </summary>
        public string? Key { get; set; }
        /// <summary>
        /// PartentId
        /// </summary>
        public Guid? PartentId { get; set; }


    }
}

