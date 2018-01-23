using System;
using System.Collections.Generic;
using ProtoBuf;

namespace Sand.Service
{
    public interface IDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        string Id { get; set; }
        /// <summary>
        /// 租户编号
        /// </summary>
        Guid? TenantId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime? CreateTime { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        string CreateId { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        string CreateName { get; set; }
        /// <summary>
        /// 最近更新时间
        /// </summary>
        DateTime? LastUpdateTime { get; set; }
        /// <summary>
        /// 最近更新者
        /// </summary>
        string LastUpdateId { get; set; }
        /// <summary>
        /// 最近更新人
        /// </summary>
        string LastUpdateName { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        bool? IsEnable { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        byte[] Version { get; set; }
        /// <summary>
        /// 是否选择
        /// </summary>
        bool Selected { get; set; }
        /// <summary>
        /// 验证
        /// </summary>
        void Validate();
    }
    public class BaseDto : IDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        [ProtoMember(1)]
        public string Id { get; set; }
        /// <summary>
        /// 住户编号
        /// </summary>
        [ProtoMember(2)]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [ProtoMember(3)]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [ProtoMember(4)]
        public string CreateId { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [ProtoMember(5)]
        public string CreateName { get; set; }
        /// <summary>
        /// 最近更新时间
        /// </summary>
        [ProtoMember(6)]
        public DateTime? LastUpdateTime { get; set; }
        /// <summary>
        /// 最近更新者
        /// </summary>
        [ProtoMember(7)]
        public string LastUpdateId { get; set; }
        /// <summary>
        /// 最近更新人
        /// </summary>
        [ProtoMember(8)]
        public string LastUpdateName { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        [ProtoMember(9)]
        public bool? IsEnable { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        [ProtoMember(10)]
        public byte[] Version { get; set; }
        /// <summary>
        /// 是否选择
        /// </summary>
        [ProtoMember(10)]
        public bool Selected { get; set; }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }

        public virtual IList<T> CreateList<T>() where T : BaseDto
        {
            return new List<T>();
        }
    }
}
