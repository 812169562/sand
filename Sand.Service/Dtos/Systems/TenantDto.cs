using System;
using System.Collections.Generic;
using System.Text;

namespace Sand.Service.Dtos.Systems
{
    public class TenantDto : BaseDto
    {
        /// <summary>
        /// 租户编号
        /// </summary>
        public new Guid TenantId { get; set; }
        /// <summary>
        /// 租户名称
        /// </summary>
        public string TenantName { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string TelName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string TelPhone { get; set; }
        /// <summary>
        /// 营业证书
        /// </summary>
        public string BusinessCertificate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }

    }
}
