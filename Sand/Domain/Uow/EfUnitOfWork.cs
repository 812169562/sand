using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sand.Dependency;
using Microsoft.EntityFrameworkCore.Storage;
using Sand.Maps;
using Sand.Domain.Entities;
using Sand.Data;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;
using System.Linq;
using System.Runtime.Loader;
using Sand.Extensions;
using Microsoft.Extensions.Logging;
using Sand.Filter;

namespace Sand.Domain.Uow
{
    public class EfUnitOfWork : DbContext, IUnitOfWork
    {
        private readonly ILog _log;
        private readonly ISqlConfig _sqlConfig;
        public EfUnitOfWork(ISqlConfig sqlConfig)
        {
            _log = Log.Log.GetLog("EfTraceLog");
            _sqlConfig = sqlConfig;
        }
        public string ConnectionString { get; set; }
        public EfUnitOfWork(string connectionString)
        {
            //ConnectionString = connectionString;
        }
        public string TraceId { get { return DateTimeExtensions.GetUnixTimestamp().ToString(); } }
        public void Complete()
        {
            this.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await this.SaveChangesAsync();
        }

        public void RollBack()
        {
            this.RollBack();
        }

        public async Task RollBackAsync()
        {
            await this.RollBackAsync();
        }

        public IDbConnection DbConnection { get { return this.Database.GetDbConnection(); } }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (IMapRegister mapper in GetMaps())
                mapper.Register(modelBuilder);
        }

        /// <summary>
        /// Configure context options<br/>
        /// 配置上下文选项<br/>
        /// </summary>
        /// <param name="optionsBuilder">Options builder</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                ConnectionString = _sqlConfig.SqlConnectionString;
                optionsBuilder.UseMySql(ConnectionString);
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseLoggerFactory(new LoggerFactory(new[] { new EfLoggerProvider(_log, this) }));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取映射配置
        /// </summary>
        private IEnumerable<IMapRegister> GetMaps()
        {
            var result = new List<IMapRegister>();
            foreach (var assembly in GetAssemblies())
                result.AddRange(Helpers.Reflection.GetTypesByInterface<IMapRegister>(assembly));
            return result;
        }

        /// <summary>
        /// 获取定义映射配置的程序集列表
        /// </summary>
        protected virtual Assembly[] GetAssemblies()
        {
            var assemblies = new List<Assembly>();
            var dependencyContext = DependencyContext.Default;
            var libs = dependencyContext.CompileLibraries.Where(lib => !lib.Serviceable && lib.Type != "package");
            foreach (var lib in libs)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name));
                assemblies.Add(assembly);
            }
            return assemblies.ToArray();
        }
    }
}
