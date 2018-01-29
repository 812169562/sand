using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Sand.Service.Dtos.Systems
{
    /// <summary>
    /// 字典表数据传输对象
    /// </summary>
    [DataContract]
    public class DicsDto : BaseDto
    {
        /// <summary>
        /// 代码
        /// </summary>
        [StringLength( 36, ErrorMessage = "代码输入过长，不能超过36位" )]
        [Display( Name = "代码" )]
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [StringLength( 50, ErrorMessage = "名称输入过长，不能超过50位" )]
        [Display( Name = "名称" )]
        [DataMember]
        public string Name { get; set; }
        
        /// <summary>
        /// 拼音简拼
        /// </summary>
        [StringLength( 50, ErrorMessage = "拼音简拼输入过长，不能超过50位" )]
        [Display( Name = "拼音简拼" )]
        [DataMember]
        public string PinYin { get; set; }
        
        /// <summary>
        /// 全拼
        /// </summary>
        [StringLength( 150, ErrorMessage = "全拼输入过长，不能超过150位" )]
        [Display( Name = "全拼" )]
        [DataMember]
        public string FullPinYin { get; set; }
        
        /// <summary>
        /// 五笔
        /// </summary>
        [StringLength( 80, ErrorMessage = "五笔输入过长，不能超过80位" )]
        [Display( Name = "五笔" )]
        [DataMember]
        public string Wubi { get; set; }
        
        /// <summary>
        /// 关系
        /// </summary>
        [StringLength( 370, ErrorMessage = "关系输入过长，不能超过370位" )]
        [Display( Name = "关系" )]
        [DataMember]
        public string RelationShip { get; set; }
        
        /// <summary>
        /// 父级
        /// </summary>
        [StringLength( 36, ErrorMessage = "父级输入过长，不能超过36位" )]
        [Display( Name = "父级" )]
        [DataMember]
        public string Parent { get; set; }
        
        /// <summary>
        /// 等级
        /// </summary>
        [Display( Name = "等级" )]
        [DataMember]
        public int? Level { get; set; }
        
        /// <summary>
        /// 排序
        /// </summary>
        [Required(ErrorMessage = "排序不能为空")]
        [Display( Name = "排序" )]
        [DataMember]
        public int Sort { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        [Display( Name = "类型" )]
        [DataMember]
        public int? Type { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        [Required(ErrorMessage = "状态不能为空")]
        [Display( Name = "状态" )]
        [DataMember]
        public int Status { get; set; }
        
        /// <summary>
        /// 删除标志
        /// </summary>
        [Required(ErrorMessage = "删除标志不能为空")]
        [Display( Name = "删除标志" )]
        [DataMember]
        public byte IsDeleted { get; set; }
        
    }
}
