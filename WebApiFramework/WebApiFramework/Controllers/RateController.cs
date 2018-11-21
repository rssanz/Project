using DataEntities.Domain;
using System.Collections.Generic;
using ServiceRate.Interfaces;
using System;
using AutoMapper;
using DataEntities.DTO;
using System.Web.Http;
using log4net;

namespace WebApi.Controllers
{
    public class RateController : ApiController
    {
        private readonly ILog _logger;
        private readonly IRateService _rateService;
        private readonly IMapper _mapper;

        public RateController() { }

        public RateController(IRateService rateService, ILog logger, IMapper mapper)
        {
            _rateService = rateService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public List<RateDTO> GetRates()
        {
            try
            {
                _logger.Info("Getting Rates");
                return _mapper.Map<List<Rate>, List<RateDTO>>(_rateService.List());
            }
            catch (Exception e)
            {
                _logger.Error("Getting Rates {e}", e);
                return new List<RateDTO>();
            }
        }

        //[HttpGet]
        //public RateDTO GetRateByID(int id)
        //{
        //    try
        //    {
        //        _logger.Info("Getting Rate");
        //        return _mapper.Map<Rate, RateDTO>(_rateService.Get(id));
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.Error("Getting Rate {e}", e);
        //        return new RateDTO();
        //    }
        //}

        [HttpPost]
        public void InsertRate([FromBody] Rate rate)
        {
            try
            {
                _logger.Info("Inserting Rate");
                //_rateService.Insert(rate);
            }
            catch (Exception e)
            {
                _logger.Error("Inserting Rate {e}", e);
            }
        }

        [HttpPut]
        public void UpdateRate(int id, [FromBody] Rate rate)
        {
            try
            {
                _logger.Info("Updating Rate");
                //_rateService.Update(id, rate);
            }
            catch (Exception e)
            {
                _logger.Error("Updating Rate {e}", e);
            }
        }

        [HttpDelete]
        public void DeleteRate(int id)
        {
            try
            {
                _logger.Info("Deleting Rate");
                //_rateService.Delete(id);
            }
            catch (Exception e)
            {
                _logger.Error("Deleting Rate {e}", e);
            }
        }
    }
}