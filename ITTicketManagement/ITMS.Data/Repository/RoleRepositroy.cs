using ITMS.Data.Interface;
using ITMS.Model.Models;
using System;
using System.Data.Entity;
using System.Linq;

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

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(Roles roles)
        {
            _dbSet.Attach(roles);
            context.Entry(roles).State = EntityState.Modified;
           
        }
  
    }
}
