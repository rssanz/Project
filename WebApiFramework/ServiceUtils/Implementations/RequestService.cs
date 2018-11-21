using log4net;
using ServiceUtilsInterface.Interfaces;
using System;

namespace ServiceUtils.Implementations
{
    public class RequestService : IRequestService
    {
        private readonly ILog _logger;

        public RequestService(ILog logger)
        {
            _logger = logger;
        }

        public string RequestInfo(string endPoint)
        {
            _logger.Info($"RequestService.RequestInfo: {endPoint}");

            var result = String.Empty;

            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    result = webClient.DownloadString(endPoint);
                }             
            }
            catch (Exception e)
            {
                _logger.Error($"RequestService.Get: {e}", e);
            }

            return result;
        }  
    }
}
