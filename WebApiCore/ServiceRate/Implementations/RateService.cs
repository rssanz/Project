using System;
using System.Collections.Generic;
using System.Linq;
using Data_EF.UnitOfWork;
using DataEntities.Domain;
using Microsoft.Extensions.Logging;
using ServiceRate.Interfaces;
using ServiceUtils.Implementations;

namespace ServiceRate.Implementations
{
    public class RateService: BaseService<Rate>, IRateService
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        public RateService(ILogger<RateService> logger, IUnitOfWork unitOfWork) : base(logger, unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public decimal Convert(List<Rate> rates, string c1, string c2, decimal amount)
        {
            decimal result = -1;
            var selectedRates = rates.Where(x => x.From == c1 && x.To == c2).ToList();
            var posiblePaths = rates.Where(x => x.From == c1).ToList();
            if (c1 == c2)
                return Math.Round(amount, 2);
            else if (selectedRates.Count > 0)
                return Math.Round(Decimal.Multiply(amount, (decimal)selectedRates.First().Ratio), 2);
            else 
            {
                foreach (var rate in posiblePaths)
                {
                    var filteredRates = rates.Where(x => x.From != c1).ToList();
                    return Convert(filteredRates, rate.To, c2, Decimal.Multiply(amount, (decimal)rate.Ratio));
                }
            }
            return result;
        }
    }
}
