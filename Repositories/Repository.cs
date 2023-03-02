namespace ControleEstoque.Repositories{
    using System.Linq.Expressions;
    using ControleEstoque.Data;
    using Microsoft.EntityFrameworkCore;

    public class Repository<T> : IRepository<T> where T : class
    {
        
        private DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public  void Add(T entity)
        {
              _context.Set<T>().Add(entity);
        }

        public List<T> Get()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
           return _context.Set<T>().AsNoTracking().SingleOrDefault(predicate);
        }

        public void Remove(Expression<Func<T,bool>> predicate)
        {
            var removeAux = _context.Set<T>().AsNoTracking().SingleOrDefault(predicate);
            _context.Set<T>().Remove(removeAux);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;  
        }
    }
}