using DotNetCoreWebAPI_3._0.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreWebAPI_3._0.Data.Repositories.Impl
{
    public class Repository<TEntity> : IRepository<TEntity>
         where TEntity : class, IEntity
    {
        private readonly ApiDbContext _context;

        public Repository(ApiDbContext context) => _context = context;

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entityToDelete = _context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
            if (entityToDelete != null)
            {
                _context.Set<TEntity>().Remove(entityToDelete);
                _context.SaveChanges();
            }
        }

        public void Edit(TEntity entity)
        {
            var editedEntity = _context.Set<TEntity>().FirstOrDefault(e => e.Id == entity.Id);
            editedEntity = entity;
            _context.SaveChanges();
        }

        public TEntity GetById(long id)
        {
            return _context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<TEntity> Filter()
        {
            return _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }
    }
}
