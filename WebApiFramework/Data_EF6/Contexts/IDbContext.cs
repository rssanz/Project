using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Data_EF.Contexts
{
    public interface IDbContext
    {
        Database Database { get; }
   
        DbChangeTracker ChangeTracker { get; }

        DbContextConfiguration Configuration { get; }

        void Dispose();
  
        DbEntityEntry Entry(object entity);
 
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        bool Equals(object obj);

        int GetHashCode();

        Type GetType();

        IEnumerable<DbEntityValidationResult> GetValidationErrors();
  
        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task<int> SaveChangesAsync();

        DbSet Set(Type entityType);

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        string ToString();

        //void Dispose(bool disposing);

        //void OnModelCreating(DbModelBuilder modelBuilder);

        //bool ShouldValidateEntity(DbEntityEntry entityEntry);

        //DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items);
    }
}