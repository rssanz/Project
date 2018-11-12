using System;
using System.Collections.Generic;
using System.Linq;
using Data.DataAccess;
using Data.Domain;
using Microsoft.Extensions.Logging;
using ServiceRate.Interfaces;
using ServiceUtils.Implementations;

namespace ServiceRate.Implementations
{
    public class RateService: BaseService<RateItem>, IRateService
    {
        private const string _filePath = "Data/Rates.txt";
        private const string _endPoint = "http://quiet-stone-2094.herokuapp.com/rates.json";
        private readonly ILogger _logger;
        private readonly IRateItemDao _rateItemDao;

        public RateService(ILogger<RateService> logger, IRateItemDao rateItemDao) : base(logger, rateItemDao, _endPoint, _filePath)
        {
            _logger = logger;
            _rateItemDao = rateItemDao;
        }

        public decimal Convert(List<RateItem> rates, string c1, string c2, decimal amount)
        {
            decimal result = -1;
            var selectedRates = rates.Where(x => x.From == c1 && x.To == c2).ToList();
            var posiblePaths = rates.Where(x => x.From == c1).ToList();
            if (c1 == c2)
                return Math.Round(amount, 2);
            else if (selectedRates.Count > 0)
                return Math.Round(Decimal.Multiply(amount, (decimal)selectedRates.First().Rate), 2);
            else 
            {
                foreach (RateItem rate in posiblePaths)
                {
                    var filteredRates = rates.Where(x => x.From != c1).ToList();
                    return Convert(filteredRates, rate.To, c2, Decimal.Multiply(amount, (decimal)rate.Rate));
                }
            }
            return result;
        }
    }
}
