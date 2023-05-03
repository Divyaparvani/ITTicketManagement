using System;
using System.Data.Entity;

namespace ITMS.Data.Infrastructure
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        TContext Context { get; }
        int SaveChanges();
    }
}
