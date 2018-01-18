using EnumsNET;
using System;
using System.ComponentModel;

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

    /// <summary>
    /// 状态码
    /// </summary>
    public enum StateCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Ok = 1,
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Fail = 2
    }
}
