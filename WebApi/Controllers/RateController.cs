using Data.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ServiceRate.Interfaces;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly ILogger<RateController> _logger;
        private readonly IRateService _rateService;

        public RateController(IRateService rateService, ILogger<RateController> logger)
        {
            _rateService = rateService;
            _logger = logger;
        }

        [HttpGet(Name = "GetRates")]
        public ActionResult<List<RateItem>> GetRates()
        {
            try
            {   
                _logger.LogInformation("Getting Rates info");
                return _rateService.List();
            }
            catch (Exception e)
            {
                _logger.LogError("Getting Rates info");
                return new List<RateItem>();
            }
        }
    }
}