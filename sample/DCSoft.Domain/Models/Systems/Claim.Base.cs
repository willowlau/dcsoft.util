using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domain;
using Util.Domain.Auditing;
using Util.Domain.Entities;

namespace DCSoft.Domain.Models.Systems
{
    /// <summary>
    /// 声明
    /// </summary>
    [Description("声明")]
    public partial class Claim : AggregateRoot<Claim>, IDelete, IAudited
    {
        /// <summary>
        /// 初始化声明
        /// </summary>
        public Claim() : this(Guid.Empty)
        {
        }

        /// <summary>
        /// 初始化声明
        /// </summary>
        /// <param name="id">声明标识</param>
        public Claim(Guid id) : base(id)
        {
        }

        /// <summary>
        /// 声明名称
        ///</summary>
        [DisplayName("声明名称")]
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// 启用
        ///</summary>
        [DisplayName("启用")]
        public bool Enabled { get; set; }

        /// <summary>
        /// 排序号
        ///</summary>
        [DisplayName("排序号")]
        public int? SortId { get; set; }

        /// <summary>
        /// 备注
        ///</summary>
        [DisplayName("备注")]
        [MaxLength(512)]
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        ///</summary>
        [DisplayName("创建时间")]
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// 创建者标识
        ///</summary>
        [DisplayName("创建者标识")]
        public Guid? CreatorId { get; set; }

        /// <summary>
        /// 创建者
        ///</summary>
        [DisplayName("创建者")]
        [MaxLength(256)]
        public string Creator { get; set; }

        /// <summary>
        /// 最后修改时间
        ///</summary>
        [DisplayName("最后修改时间")]
        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 最后修改者标识
        ///</summary>
        [DisplayName("最后修改者标识")]
        public Guid? LastModifierId { get; set; }

        /// <summary>
        /// 最后修改者
        ///</summary>
        [DisplayName("最后修改者")]
        [MaxLength(256)]
        public string LastModifier { get; set; }

        /// <summary>
        /// 是否删除
        ///</summary>
        [DisplayName("是否删除")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges(Claim other)
        {
            AddChange(t => t.Name, other.Name);
            AddChange(t => t.Enabled, other.Enabled);
            AddChange(t => t.SortId, other.SortId);
            AddChange(t => t.Remark, other.Remark);
            AddChange(t => t.CreationTime, other.CreationTime);
            AddChange(t => t.CreatorId, other.CreatorId);
            AddChange(t => t.Creator, other.Creator);
            AddChange(t => t.LastModificationTime, other.LastModificationTime);
            AddChange(t => t.LastModifierId, other.LastModifierId);
            AddChange(t => t.LastModifier, other.LastModifier);
        }
    }
}