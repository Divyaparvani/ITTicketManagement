using ITMS.Model.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ITMS.Data.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
   
    {
        internal DataContext _context;
        internal DbSet<T> _dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T t, bool autoSave = true)
        {
            _dbSet.Add(t);
            if (autoSave)
            {
                _context.SaveChanges();
            }
        }

        public void Update(T t, bool autoSave = true)
        {
            _dbSet.Attach(t);
            _context.Entry(t).State = EntityState.Modified;
            if (autoSave)
            {
                _context.SaveChanges();
            }
        }

        public void Delete(Guid Id, bool autoSave = true)
        {
            var t = GetById(Id);
            if (_context.Entry(t).State == EntityState.Detached)
            {
                _dbSet.Attach(t);
            }
            _dbSet.Remove(t);
            if (autoSave)
            {
                _context.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public T GetById(Guid Id)
        {
            return _dbSet.Find(Id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetWithWhere(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where);
        }

      
    }
}


