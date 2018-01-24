﻿using Sand.Dependency;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sand.Domain.Entities.Systems
{
    [Table("dics")]
    public class Dic : Entity<Guid>, ISoftDelete
    {

        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 拼音
        /// </summary>
        public string PinYin { get; set; }
        /// <summary>
        /// 全拼
        /// </summary>
        public string FullPinYin { get; set; }
        /// <summary>
        /// 五笔
        /// </summary>
        public string Wubi { get; set; }
        /// <summary>
        /// 关系
        /// </summary>
        public string RelationShip { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        public string Parent { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
