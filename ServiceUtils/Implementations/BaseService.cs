using Data_EF.UnitOfWork;
using DataEntities.Domain;
using Microsoft.Extensions.Logging;
using ServiceUtilsInterface.Interfaces;
using System;
using System.Collections.Generic;

namespace ServiceUtils.Implementations
{
    public class BaseService<T> : IBaseService<T> where T : Entity, new()
    {
        private readonly ILogger<BaseService<T>> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public BaseService(ILogger<BaseService<T>> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public List<T> List()
        {
            var resultList = new List<T>();
            try
            {
                _logger.LogInformation("BaseService.List");
                resultList = _unitOfWork.GetRepository<T>().Get();
            }
            catch (Exception e)
            {
                _logger.LogError("BaseService.List: {e}", e);
            }

            return resultList;
        }

        public T Get(int id)
        {
            T result = new T();
            try
            {
                _logger.LogInformation("BaseService.Get");
                result = _unitOfWork.GetRepository<T>().GetByID(id);
            }
            catch (Exception e)
            {
                _logger.LogError("BaseService.Get: {e}", e);
            }

            return result;
        }

        public void Insert(T item)
        {
            try
            {
                _logger.LogInformation("BaseService.Insert");
                _unitOfWork.GetRepository<T>().Insert(item);
            }
            catch (Exception e)
            {
                _logger.LogError("BaseService.Insert: {e}", e);
            }
        }

        public void Update(int id, T item)
        {
            try
            {
                //use "id" to check against the "item" actual id
                _logger.LogInformation("BaseService.Update");
                _unitOfWork.GetRepository<T>().Update(item);
            }
            catch (Exception e)
            {
                _logger.LogError("BaseService.Update: {e}", e);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _logger.LogInformation("BaseService.Delete");
                _unitOfWork.GetRepository<T>().Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogError("BaseService.Delete: {e}", e);
            }
        }
    }
}
