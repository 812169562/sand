using System;
using Sand.Dependency;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Sand.Domain.Entities.Systems
{
    /// <summary>
    /// 租户
    /// </summary>
    [Description("租户")]
    public partial class Tenant : Entity<int>, ISoftDelete
    {
        /// <summary>
        /// 初始化租户
        /// </summary>
        public Tenant()
        {
        }
        /// <summary>
        /// 租户名
        /// </summary>
        [Required(ErrorMessage = "租户名不能为空")]
        [StringLength(80, ErrorMessage = "租户名输入过长，不能超过80位")]
        public string TenantName { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [StringLength(20, ErrorMessage = "联系人输入过长，不能超过20位")]
        public string TelName { get; set; }
        /// <summary>
        /// 联系地址
        /// </summary>
        [StringLength(80, ErrorMessage = "联系地址输入过长，不能超过80位")]
        public string Address { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Required(ErrorMessage = "联系电话不能为空")]
        [StringLength(11, ErrorMessage = "联系电话输入过长，不能超过11位")]
        public string TelPhone { get; set; }
        /// <summary>
        /// 营业证书
        /// </summary>
        [StringLength(36, ErrorMessage = "营业证书输入过长，不能超过36位")]
        public string BusinessCertificate { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        [StringLength(36, ErrorMessage = "代码输入过长，不能超过36位")]
        public string Code { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [Required(ErrorMessage = "类型不能为空")]
        public int Type { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Required(ErrorMessage = "状态不能为空")]
        public int Status { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        [Required(ErrorMessage = "删除标志不能为空")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 加载
        /// </summary>
        public override void Load(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}