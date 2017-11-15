using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sand.Dependency;

namespace Sand.Context
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public interface IUserContext : IDependency
    {
        /// <summary>
        /// 登录编号
        /// </summary>
        string LoginKey { get; set; }
        /// <summary>
        /// 登录帐号
        /// </summary>
        string LoginCode { get; set; }
        /// <summary>
        /// 登录人
        /// </summary>
        string LoginName { get; set; }
        /// <summary>
        /// 租户编号
        /// </summary>
        string TenantId { get; set; }
    }

    public class TestUserContext : IUserContext
    {
        /// <summary>
        /// 登录编号
        /// </summary>
        public string LoginKey { get; set; }
        /// <summary>
        /// 登录帐号
        /// </summary>
        public string LoginCode { get; set; }
        /// <summary>
        /// 登录人
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 租户编号
        /// </summary>
        public string TenantId { get; set; }

        public TestUserContext()
        {
            LoginKey = "1";
            LoginCode = "2";
            LoginName = "3";
            TenantId = new Guid().ToString();
        }
    }
}
