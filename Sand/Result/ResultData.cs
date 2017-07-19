using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sand.Result
{
    public class ResultData<T>
    {
        /// <summary>
        /// 数据集合
        /// </summary>
        public List<T> Result { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }
    }
}
