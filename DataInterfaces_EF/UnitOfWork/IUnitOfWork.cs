using Data_EF.Repositories;
using DataEntities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

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
