using System;
using Sand.Dependency;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Sand.Domain.Entities.Systems
{
    /// <summary>
    /// 字典表
    /// </summary>
    [Description( "字典表" )]
    public partial class Dics : Entity,ISoftDelete {
        /// <summary>
        /// 初始化字典表
        /// </summary>
        public Dics(){
        }
        
        /// <summary>
        /// 代码
        /// </summary>
        [StringLength( 36, ErrorMessage = "代码输入过长，不能超过36位" )]
        public string Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [StringLength( 50, ErrorMessage = "名称输入过长，不能超过50位" )]
        public string Name { get; set; }
        /// <summary>
        /// 拼音简拼
        /// </summary>
        [StringLength( 50, ErrorMessage = "拼音简拼输入过长，不能超过50位" )]
        public string PinYin { get; set; }
        /// <summary>
        /// 全拼
        /// </summary>
        [StringLength( 150, ErrorMessage = "全拼输入过长，不能超过150位" )]
        public string FullPinYin { get; set; }
        /// <summary>
        /// 五笔
        /// </summary>
        [StringLength( 80, ErrorMessage = "五笔输入过长，不能超过80位" )]
        public string Wubi { get; set; }
        /// <summary>
        /// 关系
        /// </summary>
        [StringLength( 370, ErrorMessage = "关系输入过长，不能超过370位" )]
        public string RelationShip { get; set; }
        /// <summary>
        /// 父级
        /// </summary>
        [StringLength( 36, ErrorMessage = "父级输入过长，不能超过36位" )]
        public string Parent { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public int? Level { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Required(ErrorMessage = "排序不能为空")]
        public int Sort { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int? Type { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Required(ErrorMessage = "状态不能为空")]
        public int Status { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        [Required(ErrorMessage = "删除标志不能为空")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {
            throw new NotImplementedException();
        }

 
        /// <summary>
        /// 加载
        /// </summary>
        public override void Load(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}