using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sand.Domain.Repositories;
using Sand.Domain.Uow;
using Microsoft.EntityFrameworkCore;

namespace Sand.Api
{
    //public class Uow : EfUnitOfWork
    //{
    //    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    //{
    //    //    base.OnModelCreating(modelBuilder);
    //    //    modelBuilder.Entity<BaseData>().HasQueryFilter(t=>t.IsDeleted);
    //    //       // .HasKey(t => t.Id);
    //    //}

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        base.OnConfiguring(optionsBuilder);
    //    }
    //}

    public class BaseDataRepository : EfRepository<BaseData, Guid>, IBaseDataRepository
    {
        public BaseDataRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public void Test()
        {
            //Uow ef = new Uow();
            //var ff=ef.Find<BaseData>(new Guid("6782c86c-bd3f-428e-aed8-e078954f8ec2"));
        }
    }
}
