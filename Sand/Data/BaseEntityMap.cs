using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sand.Dependency;
using Sand.Domain.Entities;

namespace Sand.Data
{
    public abstract class BaseEntityMap<TEntity> : IMapRegister where TEntity : class, IEntity
    {
        public void Register(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<TEntity>();
            if (typeof(TEntity) is ISoftDelete)
            {
                //builder.HasQueryFilter(t=>t.);
            }
            MapTable(builder);
            MapVersion(builder);
            MapProperties(builder);
            MapAssociations(builder);
        }

        /// <summary>
        /// 映射表
        /// </summary>
        protected abstract void MapTable(EntityTypeBuilder<TEntity> builder);

        /// <summary>
        /// 映射乐观离线锁
        /// </summary>
        protected virtual void MapVersion(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(t => t.Version).IsRowVersion();
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected virtual void MapProperties(EntityTypeBuilder<TEntity> builder)
        {
        }

        /// <summary>
        /// 映射导航属性
        /// </summary>
        protected virtual void MapAssociations(EntityTypeBuilder<TEntity> builder)
        {
        }
    }
}