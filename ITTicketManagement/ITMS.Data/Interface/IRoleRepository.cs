using ITMS.Model.Models;
using System;
using System.Linq;

namespace ITMS.Data.Interface
{
    public  interface IRoleRepository 
    {
        void Add(Roles roles);
        void SaveChanges();
        Roles GetById(Guid Id);
        IQueryable<Roles> GetAll();
        void Update(Roles roles);
        
    }
}
