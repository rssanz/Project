using DataEntities.Domain;
using System.Collections.Generic;
using ServiceTransaction.Interfaces;
using System;
using System.Web.Http;
using ServiceUtilsInterface.Interfaces;
using log4net;

namespace WebApi.Controllers
{
    public class TransactionController : ApiController
    {
        private readonly ILog _logger;
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService, ILog logger)
        {
            _transactionService = transactionService;
            _logger = logger;
        }

        [HttpGet]
        public List<Transaction> GetTransactions()
        {
            try
            {
                _logger.Info("Getting Transactions info");
                return _transactionService.List();
            }
            catch (Exception e)
            {
                _logger.Error($"Getting Transactions info {e}", e);
                return new List<Transaction>();
            }
        }

        [HttpGet]
        [Route("api/transactions/{code}/{currency}")]
        public List<string> GetTransactionsSku(string code, string currency)
        {
            try
            {
                _logger.Info($"Getting Sku {code} info");
                return _transactionService.CalculateSku(code, currency);
            }
            catch (Exception e)
            {
                _logger.Error($"Getting Transactions info {e}", e);
                return new List<string>();
            }
        }
    }
}