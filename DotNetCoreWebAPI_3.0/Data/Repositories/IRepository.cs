using DotNetCoreWebAPI_3._0.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI_3._0.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Delete(long id);
        void Edit(TEntity entity);
        TEntity GetById(long id);
        IEnumerable<TEntity> Filter();
        IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate);
    }
}
