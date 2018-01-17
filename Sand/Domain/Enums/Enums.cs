using EnumsNET;
using System.ComponentModel;

namespace Sand.Domain.Enums
{
    /// <summary>
    /// 系统表示状态使用还是停用
    /// </summary>
    public enum SystemStatus
    {
        /// <summary>
        /// 使用中
        /// </summary>
        [Description("正常")]
        Using=0,
        /// <summary>
        /// 停止使用
        /// </summary>
        [Description("停用")]
        Pause = 1
    }
}
