using DataEntities.Domain;
using ServiceRate.Interfaces;
using ServiceTransaction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ServiceUtils.Implementations;
using Data_EF.UnitOfWork;

namespace ServiceTransaction.Implementations
{
    public class TransactionService : BaseService<Transaction>, ITransactionService
    {
        private readonly IRateService _rateService;
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(IRateService rateService, ILogger<TransactionService> logger, IUnitOfWork unitOfWork) : base(logger, unitOfWork)
        {
            _rateService = rateService;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public List<string> CalculateSku(string code, string currency)
        {
            _logger.LogInformation("TransactionService.CalculateSku {code}", code);

            var resultTransactions = new List<string>();

            try
            {
                var transactions = List();
                var filteredTransactions = transactions.Where(x => x.Sku == code).ToList();

                var rates = _rateService.List();

                decimal total = 0;
                foreach (var t in filteredTransactions)
                {
                    decimal convertedAmount = _rateService.Convert(rates, t.Currency, currency, t.Amount);
                    total += convertedAmount;
                    resultTransactions.Add(string.Format("{0} - {1} - {2}", t.Sku, convertedAmount, currency));
                }
                resultTransactions.Add(string.Format("TOTAL: {0} {1}", total, currency));
            }
            catch (Exception e)
            {
                _logger.LogError("TransactionService.CalculateSku: {e}", e);
            }

            return resultTransactions;
        }
    }
}
