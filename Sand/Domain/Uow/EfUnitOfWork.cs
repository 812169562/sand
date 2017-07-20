using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sand.Dependency;
using Microsoft.EntityFrameworkCore.Storage;
using Sand.Maps;

namespace Sand.Domain.Uow
{
    public class EfUnitOfWork: DbContext, IUnitOfWork
    {
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
            //modelBuilder.Entity<Task>().HasQueryFilter(t=>t.);
            //foreach (IMapRegister mapper in GetMaps())
            //    mapper.Register(modelBuilder.Configurations);
        }
    }
}
