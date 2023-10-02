using System;
using System.Linq.Expressions;

namespace Quantum.Data.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T? Find(Guid id);
        IEnumerable<T> Where(Expression<Func<T,bool>> expresion);
        void Add(T item);
        void Update(T item);
        void Save();
    }
}