using Data_EF.Repositories;
using DataEntities.Domain;

namespace Data_EF.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : Entity;

        /// <summary>
        /// Commits all changes
        /// </summary>
        void Commit();

        /// <summary>
        /// Discards all changes that has not been commited
        /// </summary>
        void RejectChanges();

        void Dispose();
    }
}
