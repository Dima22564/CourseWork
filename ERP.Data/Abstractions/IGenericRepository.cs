using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ERP.Data.Abstractions
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<ICollection<T>> GetAllListAsync(); //
        public void SaveChanges();
        public Task<T> GetAsync(object id); //
        public ICollection<T> GetTracked(Func<T, bool> predicate);
        public T Get(object id);
        public Task<EntityEntry<T>> AddAsync(T entity); //
        public bool IsExists(Func<T, bool> predicate); //
        public ICollection<T> Get(Func<T, bool> predicate); //
        public Task SaveChangesAsync(); //
        public ICollection<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties); //
        public ICollection<T> GetWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties); //
    }
}