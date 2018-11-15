using DataEntities.Domain;
using ServiceUtilsInterface.Interfaces;
using System.Collections.Generic;

namespace ServiceTransaction.Interfaces
{
    public interface ITransactionService : IBaseService<Transaction>
    {
        List<string> CalculateSku(string code, string currency);
    }
}
