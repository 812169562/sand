using System;
using System.Collections.Generic;
using System.Linq;

namespace Sand.Exceptions
{
    /// <summary>
    /// 系统异常
    /// </summary>
    public class SandException : Exception
    {
        /// <summary>
        /// 警告编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 多条警告信息
        /// </summary>
        public List<string> MutiMessage { get; set; }
        /// <summary>
        /// 警告信息
        /// </summary>
        public string Messages { get; set; }

        public SandException()
        {
        }
        public SandException(string message) : base(message)
        {
        }
        public SandException(List<string> message)
        {
        }
    }

    /// <summary>
    /// 警告信息
    /// </summary>
    public class Warning : SandException
    {
        public Warning()
        {
            Code = "W";
        }
        public Warning(string message, string code = "W",Exception ex=null) : base(message)
        {
            if (!code.Contains("W"))code = "W" + code;
            Code = code;
            Messages = message;
        }
        public Warning(List<string> message)
        {
            MutiMessage = message;
            Messages = MutiMessage.Aggregate((item, current) => item + "," + current);
            if (!message.Any()) Code = string.Empty;
        }
    }
    /// <summary>
    /// 错误信息
    /// </summary>
    public class Error : SandException
    {
        public Error()
        {
            Code = "E";
        }
        public Error(string message, string code = "E") : base(message)
        {
            if (!code.Contains("E")) code = "E" + code;
            Code = code;
            Messages = message;
        }

        public Error(List<string> message)
        {
            MutiMessage = message;
            Messages = MutiMessage.Aggregate((item, current) => item + "," + current);
            if (!message.Any())
                Code = string.Empty;
        }

    }
    /// <summary>
    /// 普通信息
    /// </summary>
    public class Info : SandException
    {
        public Info()
        {
            Code = "I";
        }
        public Info(string message, string code = "I") : base(message)
        {
            if (!code.Contains("I")) code = "I" + code;
            Code = code;
            Messages = message;
        }
        public Info(List<string> message)
        {
            MutiMessage = message;
            Messages = MutiMessage.Aggregate((item, current) => item + "," + current);
            if (!message.Any())
                Code = string.Empty;
        }
    }
}
