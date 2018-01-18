using System;
using System.Collections.Generic;
using System.Text;

namespace Sand.Extensions
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 判断字符为空
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        /// <summary>
        /// 判断字符不为空
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsNotEmpty(this string str)
        {
            return !str.IsEmpty();
        }

        /// <summary>
        /// 判断字符为空或者空格
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsWhiteSpaceEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// 判断字符为空或者空格
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsNotWhiteSpaceEmpty(this string str)
        {
            return !str.IsWhiteSpaceEmpty();
        }
    }
}
