using Sand.Dependency;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sand.Domain.Entities.Systems
{
    [Table("Tenant")]
    public class Tenant : Entity<int>, ISoftDelete
    {
        /// <summary>
        /// 租户编号
        /// </summary>
        public new Guid TenantId { get; set; }
        /// <summary>
        /// 租户名称
        /// </summary>
        [Required(ErrorMessage ="请输入名称，名称不能为空！")]
        public string TenantName { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [Required(ErrorMessage = "请输入联系人，联系人不能为空！")]
        public string TelName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Required(ErrorMessage = "请输入联系电话，联系电话不能为空！")]
        public string TelPhone { get; set; }
        /// <summary>
        /// 营业证书
        /// </summary>
        public string BusinessCertificate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime EndTime { get; set; }

        public override void Init()
        {
            throw new NotImplementedException();
        }

        public override void Load(IEntity entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }

    }
}
