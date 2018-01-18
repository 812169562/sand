using EnumsNET;
using System;
using System.ComponentModel;
using Enums = EnumsNET.Enums;

namespace Sand.Utils.Enums
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
        [DisplayName("是")]
        Using = 0,
        /// <summary>
        /// 停止使用
        /// </summary>
        [DisplayName("否")]
        [Description("停用")]
        Pause = 1
    }
}
