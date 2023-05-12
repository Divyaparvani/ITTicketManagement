using ITMS.Model.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ITMS.Data.Infrastructure
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T t, bool autoSave);
        void Update(T t, bool autoSave);
        void Delete(Guid Id, bool autoSave);
        void SaveChanges();
        T GetById(Guid Id);
        IQueryable<T> GetAll();
        IQueryable<T> GetWithWhere(Expression<Func<T, bool>> where);
    }
}
