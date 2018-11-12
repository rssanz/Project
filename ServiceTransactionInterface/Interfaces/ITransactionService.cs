using Data.Domain;
using ServiceUtilsInterface.Interfaces;
using System.Collections.Generic;

namespace ServiceTransaction.Interfaces
{
    public interface ITransactionService : IBaseService<TransactionItem>
    {
        List<string> CalculateSku(string code, string currency);
    }
}
