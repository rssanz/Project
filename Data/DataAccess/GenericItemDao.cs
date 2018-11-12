using Microsoft.Extensions.Logging;
using ServiceUtils.Interfaces;
using System;


namespace Data.DataAccess
{
    public class GenericItemDao<T> : IGenericItemDao<T>
    {
        private readonly ILogger _logger;
        private readonly IFileService _fileService;
        private readonly IRequestService _requestService;

        public GenericItemDao(ILogger<T> logger, IRequestService requestService, IFileService fileService)
        {
            _logger = logger;
            _requestService = requestService;
            _fileService = fileService;
        }

        public string Get(string endPoint, string filePath)
        {
            var result = String.Empty;

            try
            {
                _logger.LogInformation("GenericItemDao.Get - EndPoint: {endPoint} , File Path: {filePath}", endPoint, filePath);
                result = _requestService.RequestInfo(endPoint);
                _fileService.WriteFile(filePath, result);
            }
            catch (Exception e)
            {
                _logger.LogError("GenericItemDao.Get - EndPoint: {endPoint} , File Path: {filePath} , error: {e}", endPoint, filePath, e);
            }
            finally
            {
                if (String.IsNullOrEmpty(result))
                    result = _fileService.ReadFile(filePath);
            }

            return result;
        }
    }
}
