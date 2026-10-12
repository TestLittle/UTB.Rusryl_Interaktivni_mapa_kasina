

using System.Linq.Expressions;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities.Interfaces;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Repositories
{
    public interface IRepository<T, TKey> where T : IEntity<TKey> where TKey : notnull
    {
        T? GetById(TKey id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
    }
}
