using System;
using System.Linq;
using Data_EF.Contexts;
using Data_EF.Repositories;
using DataEntities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data_EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IServiceProvider _provider;
        private readonly MyDbContext _context;

        private bool disposed = false;

        public UnitOfWork(IServiceProvider provider, MyDbContext context)
        {
            _provider = provider;
            _context = context;
        }

        public IGenericRepository<T> GetRepository<T>() where T : Entity
        {
            return _provider.GetService<IGenericRepository<T>>();
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