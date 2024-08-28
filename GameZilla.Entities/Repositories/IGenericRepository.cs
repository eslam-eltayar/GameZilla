using GameZilla.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameZilla.Entities.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? Includes = null);
        T? GetById(Expression<Func<T, bool>>? predicate = null, string? Includes = null);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
