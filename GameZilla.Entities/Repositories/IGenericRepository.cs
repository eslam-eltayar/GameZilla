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
        
        T GetFirstOrDefault(int id);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
