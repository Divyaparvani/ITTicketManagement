using ITMS.Data.Interface;
using ITMS.Model.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ITMS.Data.Repository
{
    public class RoleRepositroy : IRoleRepository
    {
        public DataContext context;
        internal DbSet<Roles> _dbSet;

        public RoleRepositroy()
        {
            context = new DataContext();
            this._dbSet = context.Set<Roles>();
        }

        public void Add(Roles roles)
        {
            _dbSet.Add(roles);
            
        }

        public IQueryable<Roles> GetAll()
        {
            return _dbSet;
        }

        public Roles GetById(Guid Id)
        {
            return _dbSet.Find(Id);
        }

        public IQueryable<Roles> GetWithWhere(Expression<Func<Roles, bool>> where)
        {
            return _dbSet.Where(where);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(Roles roles)
        {
            _dbSet.Attach(roles);
            context.Entry(roles).State = EntityState.Modified;
           
        }

        public void Delete(Guid Id, bool autoSave = true)
        {
            var t = GetById(Id);
            if (context.Entry(t).State == EntityState.Detached)
            {
                _dbSet.Attach(t);
            }
            _dbSet.Remove(t);
            if (autoSave)
            {
                context.SaveChanges();
            }
        }
    }
}
