using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Oxagile.Internal.MVC.Entities;
using Oxagile.Internal.MVC.Entities.Domain;

namespace Oxagile.Internal.MVC.DALCF.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        void Add(T entity);
        void AddRange(IEnumerable<Title> list);
        void Edit(T entity);
        void Delete(T entity);
        void Manage(T entity);
    }
}
