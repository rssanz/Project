using Data.DataAccess;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServiceUtilsInterface.Interfaces;
using System;
using System.Collections.Generic;

namespace ServiceUtils.Implementations
{
    public class BaseService<T> : IBaseService<T>
    {
        private readonly string _endPoint;
        private readonly string _filePath;
        private readonly ILogger<BaseService<T>> _logger;
        private readonly IGenericItemDao<T> _gerericDao;

        public BaseService(ILogger<BaseService<T>> logger, IGenericItemDao<T> gerericDao, string endPoint, string filePath)
        {
            _logger = logger;
            _gerericDao = gerericDao;
            _endPoint = endPoint;
            _filePath = filePath;
        }

        public List<T> List()
        {
            var resultList = new List<T>();
            try
            {
                _logger.LogInformation("BaseService.List");
                var result = _gerericDao.Get(_endPoint, _filePath);
                if (!String.IsNullOrEmpty(result))
                    resultList = JsonConvert.DeserializeObject<List<T>>(result);
            }
            catch (Exception e)
            {
                _logger.LogError("BaseService.List: {e}", e);
            }

            return resultList;
        }
    }
}
