using Data_EF.UnitOfWork;
using DataEntities.Domain;
using log4net;
using ServiceUtilsInterface.Interfaces;
using System;
using System.Collections.Generic;

namespace ServiceUtils.Implementations
{
    public class BaseService<T> : IBaseService<T> where T : Entity, new()
    {
        private readonly ILog _logger; // NLog.LogManager.GetCurrentClassLogger();
        private readonly IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork, ILog logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public List<T> List()
        {
            var resultList = new List<T>();
            try
            {
                _logger.Info("BaseService.List");
                resultList = _unitOfWork.GetRepository<T>().Get();
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            return resultList;
        }

        public T Get(int id)
        {
            T result = new T();
            try
            {
                _logger.Info("BaseService.Get");
                result = _unitOfWork.GetRepository<T>().GetByID(id);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            return result;
        }

        public void Insert(T item)
        {
            try
            {
                _logger.Info("BaseService.Insert");
                _unitOfWork.GetRepository<T>().Insert(item);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
        }

        public void Update(int id, T item)
        {
            try
            {
                //use "id" to check against the "item" actual id
                _logger.Info("BaseService.Update");
                _unitOfWork.GetRepository<T>().Update(item);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _logger.Info("BaseService.Delete");
                _unitOfWork.GetRepository<T>().Delete(id);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
        }
    }
}
