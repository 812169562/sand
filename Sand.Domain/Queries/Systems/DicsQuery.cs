using System;
using System.ComponentModel.DataAnnotations;
using Sand.Domain.Query;
using Sand.Domain.Entities.Systems;

namespace Sand.Domain.Queries.Systems
{
    /// <summary>
    /// 字典表查询实体
    /// </summary>
    public class DicsQuery :  BaseQuery<Dics> {
        /// <summary>
        /// 编号
        /// </summary>
        [Display(Name="编号")]
        public Guid? Id { get; set; }
        
        private string _code = string.Empty;
        /// <summary>
        /// 代码
        /// </summary>
        [Display(Name="代码")]
        public string Code {
            get { return _code == null ? string.Empty : _code.Trim(); }
            set{ _code=value;}
        }        
        
        private string _tenantId = string.Empty;
        /// <summary>
        /// 租户
        /// </summary>
        [Display(Name="租户")]
        public string TenantId {
            get { return _tenantId == null ? string.Empty : _tenantId.Trim(); }
            set{ _tenantId=value;}
        }        
        /// <summary>
        /// 起始创建时间
        /// </summary>
        [Display( Name = "起始创建时间" )]
        public DateTime? BeginCreateTime { get; set; }
        /// <summary>
        /// 结束创建时间
        /// </summary>
        [Display( Name = "结束创建时间" )]
        public DateTime? EndCreateTime { get; set; }        
        
        private string _createId = string.Empty;
        /// <summary>
        /// 创建者
        /// </summary>
        [Display(Name="创建者")]
        public string CreateId {
            get { return _createId == null ? string.Empty : _createId.Trim(); }
            set{ _createId=value;}
        }        
        
        private string _createName = string.Empty;
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name="创建人")]
        public string CreateName {
            get { return _createName == null ? string.Empty : _createName.Trim(); }
            set{ _createName=value;}
        }        
        /// <summary>
        /// 起始最近更新时间
        /// </summary>
        [Display( Name = "起始最近更新时间" )]
        public DateTime? BeginLastUpdateTime { get; set; }
        /// <summary>
        /// 结束最近更新时间
        /// </summary>
        [Display( Name = "结束最近更新时间" )]
        public DateTime? EndLastUpdateTime { get; set; }        
        
        private string _lastUpdateId = string.Empty;
        /// <summary>
        /// 最近更新者
        /// </summary>
        [Display(Name="最近更新者")]
        public string LastUpdateId {
            get { return _lastUpdateId == null ? string.Empty : _lastUpdateId.Trim(); }
            set{ _lastUpdateId=value;}
        }        
        
        private string _lastUpdateName = string.Empty;
        /// <summary>
        /// 最近更新人
        /// </summary>
        [Display(Name="最近更新人")]
        public string LastUpdateName {
            get { return _lastUpdateName == null ? string.Empty : _lastUpdateName.Trim(); }
            set{ _lastUpdateName=value;}
        }        
        
        private string _name = string.Empty;
        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name="名称")]
        public string Name {
            get { return _name == null ? string.Empty : _name.Trim(); }
            set{ _name=value;}
        }        
        
        private string _pinYin = string.Empty;
        /// <summary>
        /// 拼音简拼
        /// </summary>
        [Display(Name="拼音简拼")]
        public string PinYin {
            get { return _pinYin == null ? string.Empty : _pinYin.Trim(); }
            set{ _pinYin=value;}
        }        
        
        private string _fullPinYin = string.Empty;
        /// <summary>
        /// 全拼
        /// </summary>
        [Display(Name="全拼")]
        public string FullPinYin {
            get { return _fullPinYin == null ? string.Empty : _fullPinYin.Trim(); }
            set{ _fullPinYin=value;}
        }        
        
        private string _wubi = string.Empty;
        /// <summary>
        /// 五笔
        /// </summary>
        [Display(Name="五笔")]
        public string Wubi {
            get { return _wubi == null ? string.Empty : _wubi.Trim(); }
            set{ _wubi=value;}
        }        
        
        private string _relationShip = string.Empty;
        /// <summary>
        /// 关系
        /// </summary>
        [Display(Name="关系")]
        public string RelationShip {
            get { return _relationShip == null ? string.Empty : _relationShip.Trim(); }
            set{ _relationShip=value;}
        }        
        
        private string _parent = string.Empty;
        /// <summary>
        /// 父级
        /// </summary>
        [Display(Name="父级")]
        public string Parent {
            get { return _parent == null ? string.Empty : _parent.Trim(); }
            set{ _parent=value;}
        }        
        /// <summary>
        /// 等级
        /// </summary>
        [Display(Name="等级")]
        public int? Level { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name="排序")]
        public int? Sort { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [Display(Name="类型")]
        public int? Type { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name="状态")]
        public int? Status { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        [Display(Name="是否可用")]
        public byte? IsEnable { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        [Display(Name="删除标志")]
        public byte? IsDeleted { get; set; }
        
    }
}
