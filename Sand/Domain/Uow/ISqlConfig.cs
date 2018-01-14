using Sand.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sand.Domain.Uow
{
    public interface ISqlConfig: IDependencySingleton
    {
        /// <summary>
        /// 链接字符串
        /// </summary>
        string SqlConnectionString { get; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        DbType DbType { get; }
    }

    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DbType
    {
        Mysql = 0,
        Mssql = 1,
        Pgsql = 2
    }
}
