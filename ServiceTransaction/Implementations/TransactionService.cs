using Data.Domain;
using Data.DataAccess;
using ServiceRate.Interfaces;
using ServiceTransaction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ServiceUtils.Implementations;

namespace ServiceTransaction.Implementations
{
    public class TransactionService : BaseService<TransactionItem>, ITransactionService
    {
        private const string _filePath = "Data/Transactions.txt";
        private const string _endPoint = "http://quiet-stone-2094.herokuapp.com/transactions.json";
        private readonly IRateService _rateService;
        private readonly ILogger _logger;
        private readonly ITransactionItemDao _transactionItemDao;

        public TransactionService(IRateService rateService, ILogger<TransactionService> logger, ITransactionItemDao transactionItemDao) : base(logger, transactionItemDao, _endPoint, _filePath)
        {
            _rateService = rateService;
            _logger = logger;
            _transactionItemDao = transactionItemDao;
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
                foreach (TransactionItem t in filteredTransactions)
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
