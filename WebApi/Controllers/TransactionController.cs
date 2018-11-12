﻿using Data.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ServiceTransaction.Interfaces;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<RateController> _logger;
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService, ILogger<RateController> logger)
        {
            _transactionService = transactionService;
            _logger = logger;
        }

        [HttpGet(Name = "GetTransactions")]
        public ActionResult<List<TransactionItem>> GetTransactions()
        {
            try
            {
                _logger.LogInformation("Getting Transactions info");
                return _transactionService.List();
            }
            catch (Exception e)
            {
                _logger.LogError("Getting Transactions info");
                return new List<TransactionItem>();
            }
        }

        [HttpGet("{code}/{currency}", Name = "GetTransactionsSku")]
        public ActionResult<List<string>> GetTransactionsSku(string code, string currency)
        {
            try
            {
                _logger.LogInformation("Getting Sku {code} info", code);
                return _transactionService.CalculateSku(code, currency);
            }
            catch (Exception e)
            {
                _logger.LogError("Getting Transactions info");
                return new List<string>();
            }
        }
    }
}