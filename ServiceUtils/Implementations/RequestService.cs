using Microsoft.Extensions.Logging;
using ServiceUtils.Interfaces;
using System;

namespace ServiceUtils.Implementations
{
    public class RequestService : IRequestService
    {
        private readonly ILogger<RequestService> _logger;

        public RequestService(ILogger<RequestService> logger)
        {
            _logger = logger;
        }

        public string RequestInfo(string endPoint)
        {
            _logger.LogInformation("RequestService.RequestInfo: {endpoint}", endPoint);

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
                _logger.LogError("RequestService.Get: {e}", e);
            }

            return result;
        }  
    }
}
