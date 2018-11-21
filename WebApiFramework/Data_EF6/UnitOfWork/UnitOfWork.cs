using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using Autofac;
using Data_EF.Contexts;
using Data_EF.Repositories;
using DataEntities.Domain;

namespace Data_EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ILifetimeScope _lifetimeScope;
        private readonly IDbContext _context;

        private bool disposed = false;

        public UnitOfWork(IDbContext context, ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _context = context;
        }

        public IGenericRepository<T> GetRepository<T>() where T : Entity
        {
            return _lifetimeScope.Resolve<IGenericRepository<T>>();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void RejectChanges()
        {
            foreach (var entry in _context.ChangeTracker.Entries()
                  .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }
}