using DataEntities.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ServiceRate.Interfaces;
using System;
using AutoMapper;
using DataEntities.DTO;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly ILogger<RateController> _logger;
        private readonly IRateService _rateService;
        private readonly IMapper _mapper;

        public RateController(IRateService rateService, ILogger<RateController> logger, IMapper mapper)
        {
            _rateService = rateService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<RateDTO>> GetRates()
        {
            try
            {
                _logger.LogInformation("Getting Rates");
                return _mapper.Map<List<Rate>, List<RateDTO>>(_rateService.List());
            }
            catch (Exception e)
            {
                _logger.LogError("Getting Rates {e}", e);
                return new List<RateDTO>();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<RateDTO> GetRateByID([FromRoute] int id)
        {
            try
            {
                _logger.LogInformation("Getting Rate");
                return _mapper.Map<Rate, RateDTO>(_rateService.Get(id));
            }
            catch (Exception e)
            {
                _logger.LogError("Getting Rate {e}", e);
                return new RateDTO();
            }
        }

        [HttpPost]
        public void InsertRate([FromBody] Rate rate)
        {
            try
            {
                _logger.LogInformation("Inserting Rate");
                //_rateService.Insert(rate);
            }
            catch (Exception e)
            {
                _logger.LogError("Inserting Rate {e}", e);
            }
        }

        [HttpPut("{id}")]
        public void UpdateRate([FromRoute] int id, [FromBody] Rate rate)
        {
            try
            {
                _logger.LogInformation("Updating Rate");
                //_rateService.Update(id, rate);
            }
            catch (Exception e)
            {
                _logger.LogError("Updating Rate {e}", e);
            }
        }

        [HttpDelete("{id}")]
        public void DeleteRate([FromRoute] int id)
        {
            try
            {
                _logger.LogInformation("Deleting Rate");
                //_rateService.Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogError("Deleting Rate {e}", e);
            }
        }
    }
}