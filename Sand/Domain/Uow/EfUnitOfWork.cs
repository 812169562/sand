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

namespace Sand.Domain.Uow
{
    public class EfUnitOfWork : DbContext, IUnitOfWork
    {
        public string ConnectionString { get; set; }
        //public EfUnitOfWork(string connectionString)
        //{
        //    // ConnectionString = connectionString;
        //    base.OnConfiguring(DbContextOptionsBuilder)
        //}
        public string TraceId { get; }
        public IUnitOfWork Begin(UnitOfWorkOptions options = null)
        {
            throw new NotImplementedException();
        }

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

        public IDbConnection DbConnection { get; }

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
                ConnectionString = "server=localhost;database=sand;user=root;password=root;";
                optionsBuilder.UseMySql(ConnectionString);
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
