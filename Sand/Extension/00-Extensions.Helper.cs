﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Sand.Helpers;
using EnumsNET;
using System.ComponentModel;
using EnumsNET.NonGeneric;
using Sand.Utils.Enums;

namespace Sand.Extensions
{
    /// <summary>
    /// 工具扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 转换为用分隔符拼接的字符串
        /// </summary>
        /// <typeparam name="T">集合元素类型</typeparam>
        /// <param name="list">集合</param>
        /// <param name="quotes">引号，默认不带引号，范例：单引号 "'"</param>
        /// <param name="separator">分隔符，默认使用逗号分隔</param>
        public static string Splice<T>(this IEnumerable<T> list, string quotes = "", string separator = ",")
        {
            var result = new StringBuilder();
            foreach (var each in list)
                result.AppendFormat("{0}{1}{0}{2}", quotes, each, separator);
            return result.ToString().TrimEnd(separator.ToCharArray());
        }

        /// <summary>
        /// 截断字符串
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="length">返回长度</param>
        /// <param name="endCharCount">添加结束符号的个数，默认0，不添加</param>
        /// <param name="endChar">结束符号，默认为省略号</param>
        public static string Truncate(this string text, int length, int endCharCount = 0, string endChar = ".")
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            if (text.Length < length)
                return text;
            return text.Substring(0, length) + GetEndString(endCharCount, endChar);
        }

        /// <summary>
        /// 获取结束字符串
        /// </summary>
        private static string GetEndString(int endCharCount, string endChar)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < endCharCount; i++)
                result.Append(endChar);
            return result.ToString();
        }

        #region Empty(空字符串)

        /// <summary>
        /// 空字符串
        /// </summary>
        public static string Empty
        {
            get { return string.Empty; }
        }

        #endregion

        #region PinYin(获取汉字的拼音简码)

        /// <summary>
        /// 获取汉字的拼音简码，即首字母缩写,范例：中国,返回zg
        /// </summary>
        /// <param name="chineseText">汉字文本,范例： 中国</param>
        public static string PinYin(string chineseText)
        {
            if (string.IsNullOrWhiteSpace(chineseText))
                return string.Empty;
            var result = new System.Text.StringBuilder();
            foreach (char text in chineseText)
                result.AppendFormat("{0}", ResolvePinYin(text));
            return result.ToString().ToLower();
        }

        /// <summary>
        /// 解析单个汉字的拼音简码
        /// </summary>
        /// <param name="text">单个汉字</param>
        private static string ResolvePinYin(char text)
        {
            byte[] charBytes = Encoding.Default.GetBytes(text.ToString());
            if (charBytes[0] <= 127)
                return text.ToString();
            var unicode = (ushort)(charBytes[0] * 256 + charBytes[1]);
            string pinYin = ResolvePinYinByCode(unicode);
            if (!string.IsNullOrWhiteSpace(pinYin))
                return pinYin;
            return ResolvePinYinByFile(text.ToString());
        }

        /// <summary>
        /// 使用字符编码方式获取拼音简码
        /// </summary>
        private static string ResolvePinYinByCode(ushort unicode)
        {
            if (unicode >= '\uB0A1' && unicode <= '\uB0C4')
                return "A";
            if (unicode >= '\uB0C5' && unicode <= '\uB2C0' && unicode != 45464)
                return "B";
            if (unicode >= '\uB2C1' && unicode <= '\uB4ED')
                return "C";
            if (unicode >= '\uB4EE' && unicode <= '\uB6E9')
                return "D";
            if (unicode >= '\uB6EA' && unicode <= '\uB7A1')
                return "E";
            if (unicode >= '\uB7A2' && unicode <= '\uB8C0')
                return "F";
            if (unicode >= '\uB8C1' && unicode <= '\uB9FD')
                return "G";
            if (unicode >= '\uB9FE' && unicode <= '\uBBF6')
                return "H";
            if (unicode >= '\uBBF7' && unicode <= '\uBFA5')
                return "J";
            if (unicode >= '\uBFA6' && unicode <= '\uC0AB')
                return "K";
            if (unicode >= '\uC0AC' && unicode <= '\uC2E7')
                return "L";
            if (unicode >= '\uC2E8' && unicode <= '\uC4C2')
                return "M";
            if (unicode >= '\uC4C3' && unicode <= '\uC5B5')
                return "N";
            if (unicode >= '\uC5B6' && unicode <= '\uC5BD')
                return "O";
            if (unicode >= '\uC5BE' && unicode <= '\uC6D9')
                return "P";
            if (unicode >= '\uC6DA' && unicode <= '\uC8BA')
                return "Q";
            if (unicode >= '\uC8BB' && unicode <= '\uC8F5')
                return "R";
            if (unicode >= '\uC8F6' && unicode <= '\uCBF9')
                return "S";
            if (unicode >= '\uCBFA' && unicode <= '\uCDD9')
                return "T";
            if (unicode >= '\uCDDA' && unicode <= '\uCEF3')
                return "W";
            if (unicode >= '\uCEF4' && unicode <= '\uD188')
                return "X";
            if (unicode >= '\uD1B9' && unicode <= '\uD4D0')
                return "Y";
            if (unicode >= '\uD4D1' && unicode <= '\uD7F9')
                return "Z";
            return string.Empty;
        }

        /// <summary>
        /// 从拼音简码文件获取
        /// </summary>
        /// <param name="text">单个汉字</param>
        private static string ResolvePinYinByFile(string text)
        {
            int index = Const.ChinesePinYin.IndexOf(text, StringComparison.Ordinal);
            if (index < 0)
                return string.Empty;
            return Const.ChinesePinYin.Substring(index + 1, 1);
        }

        #endregion

        #region FirstUpper(将值的首字母大写)

        /// <summary>
        /// 将值的首字母大写
        /// </summary>
        /// <param name="value">值</param>
        public static string FirstUpper(string value)
        {
            string firstChar = value.Substring(0, 1).ToUpper();
            return firstChar + value.Substring(1, value.Length - 1);
        }

        #endregion

        #region ToCamel(将字符串转成驼峰形式)

        /// <summary>
        /// 将字符串转成驼峰形式
        /// </summary>
        /// <param name="value">原始字符串</param>
        public static string ToCamel(string value)
        {
            return FirstUpper(value.ToLower());
        }

        #endregion

        #region ContainsChinese(是否包含中文)

        /// <summary>
        /// 是否包含中文
        /// </summary>
        /// <param name="text">文本</param>
        public static bool ContainsChinese(string text)
        {
            const string pattern = "[\u4e00-\u9fa5]+";
            return Regex.IsMatch(text, pattern);
        }

        #endregion

        #region ContainsNumber(是否包含数字)

        /// <summary>
        /// 是否包含数字
        /// </summary>
        /// <param name="text">文本</param>
        public static bool ContainsNumber(string text)
        {
            const string pattern = "[0-9]+";
            return Regex.IsMatch(text, pattern);
        }

        #endregion

        #region Distinct(去除重复)

        /// <summary>
        /// 去除重复
        /// </summary>
        /// <param name="value">值，范例1："5555",返回"5",范例2："4545",返回"45"</param>
        public static string Distinct(string value)
        {
            var array = value.ToCharArray();
            return new string(array.Distinct().ToArray());
        }

        #endregion

        #region Unique(获取全局唯一值)

        /// <summary>
        /// 获取全局唯一值
        /// </summary>
        public static string Unique()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        #endregion

        #region GetLastProperty(获取最后一个属性)

        /// <summary>
        /// 获取最后一个属性
        /// </summary>
        /// <param name="propertyName">属性名，范例，A.B.C,返回"C"</param>
        public static string GetLastProperty(string propertyName)
        {
            if (propertyName.IsEmpty())
                return string.Empty;
            var lastIndex = propertyName.LastIndexOf(".", StringComparison.Ordinal) + 1;
            return propertyName.Substring(lastIndex);
        }

        #endregion




        /// <summary>
        /// 获取枚举的显示名称
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="t">枚举值</param>
        /// <returns>如果返回-999即失败</returns>
        public static int Value<TEnum>(this TEnum value) where TEnum : struct
        {
            if (!(value is Enum)) return -999;
            var values = NonGenericEnums.GetMember(value.GetType(), value);
            return values.ToInt32() ;
        }

        /// <summary>
        /// 获取枚举的描述
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="t">枚举值</param>
        /// <returns></returns>
        public static string Description<TEnum>(this TEnum value) where TEnum : struct
        {
            if (!(value is Enum)) return "";
            var values = NonGenericEnums.GetMember(value.GetType(), value);
            var des = values.Attributes.Get(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return des == null ? "" : des.Description;
        }

        /// <summary>
        /// 获取枚举的显示名称
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="t">枚举值</param>
        /// <returns></returns>
        public static string DisplayName<TEnum>(this TEnum value) where TEnum : struct
        {
            if (!(value is  Enum)) return "";
            var values = NonGenericEnums.GetMember(value.GetType(), value);
            var dis = values.Attributes.Get(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
            return dis == null ? "" : dis.DisplayName;
        }

        /// <summary>
        /// 获取枚举的显示名称
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="t">枚举值</param>
        /// <returns></returns>
        public static List<EnumKeyValue> GetEnumList<TEnum>(this TEnum type) where TEnum : struct
        {
            List<EnumKeyValue> list = new List<EnumKeyValue>();
            if (!(type is Enum)) return list;
            var values = NonGenericEnums.GetMembers(type.GetType());
            foreach (EnumMember value in values)
            {
                var dis = value.Attributes.Get(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                var des = value.Attributes.Get(typeof(DescriptionAttribute)) as DescriptionAttribute;
                EnumKeyValue keyValue = new EnumKeyValue();
                keyValue.Value = value.ToInt32();
                keyValue.DisplayName = dis == null ? "" : dis.DisplayName;
                keyValue.Description = des == null ? "" : des.Description;
                list.Add(keyValue);
            }
            return list;
        }
    }
}
