using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Oxagile.Internal.MVC.DALCF.Interfaces;
using Oxagile.Internal.MVC.Entities.Domain;

namespace Oxagile.Internal.MVC.DALCF.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext dbContext)
        {
            _context = dbContext;
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            dbQuery = dbQuery.OrderBy(x => x.Id);

            foreach (var navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include(navigationProperty);
            return dbQuery;
        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            IQueryable<T> dbQuery = _context.Set<T>();

            foreach (var navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include(navigationProperty);

            item = dbQuery
                .AsNoTracking()
                .FirstOrDefault(where);
            return item;
        }

        public void Add(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void AddRange(IEnumerable<Title> list)
        {
            _context.Set<Title>().AddRange(list);
        }
        public void Delete(T item)
        {
            _context.Entry(item).State = EntityState.Deleted;
        }

        public void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Manage(T entity)
        {
            _context.Set<T>().AddOrUpdate(entity);
        }
    }
}
