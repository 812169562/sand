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
            throw new NotImplementedException();
        }

        public Task CompleteAsync()
        {
            throw new NotImplementedException();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }

        public Task RollBackAsync()
        {
            throw new NotImplementedException();
        }

        public IDbConnection DbConnection { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //if (typeof(TEntity) is ISoftDelete)
            //{
            //    //modelBuilder.Entity<TEntity>().HasQueryFilter(t =>(bool)t.GetType().GetProperty(DataFilters.SoftDelete).GetValue(t)==true);
            //}
            //foreach (IMapRegister mapper in GetMaps())
            //    mapper.Register(modelBuilder.Configurations);
        }

        /// <summary>
		/// Configure context options<br/>
		/// 配置上下文选项<br/>
		/// </summary>
		/// <param name="optionsBuilder">Options builder</param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConnectionString = "server=.;database=Sand;uid=sa;pwd=sa;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(ConnectionString);

            //services.AddDbContext<MyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //var pathConfig = Application.Ioc.Resolve<LocalPathConfig>();
            //if (string.Compare(DatabaseName, "MSSQL", true) == 0)
            //{
            //    optionsBuilder.UseSqlServer(
            //        ConnectionString, option => option.UseRowNumberForPaging());
            //}
            //else if (string.Compare(DatabaseName, "SQLite", true) == 0)
            //{
            //    optionsBuilder.UseSqlite(
            //        ConnectionString.Replace("{{App_Data}}", pathConfig.AppDataDirectory));
            //}
            //else if (string.Compare(DatabaseName, "MySQL", true) == 0)
            //{
            //    optionsBuilder.UseMySql(ConnectionString);
            //}
            //else if (string.Compare(DatabaseName, "PostgreSQL", true) == 0)
            //{
            //    optionsBuilder.UseNpgsql(ConnectionString);
            //}
            //else if (string.Compare(DatabaseName, "InMemory", true) == 0)
            //{
            //    optionsBuilder.UseInMemoryDatabase();
            //}
            //else
            //{
            //    throw new ArgumentException($"unsupported database type {Database}");
            //}
        }
    }
}
