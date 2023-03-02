using System;
using System.Linq.Expressions;

namespace ControleEstoque.Repositories {
    public interface IRepository<T> where T : class {
        public List<T> Get();
        public T GetById(Expression<Func<T,bool>> predicate);

        public void Add(T entity);

        public void Remove(Expression<Func<T,bool>> predicate);

        public void Update(T entity);

    }
}