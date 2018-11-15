using Data.Domain;
using DataInterfaces.Interfaces;
using Microsoft.Extensions.Logging;
using ServiceUtils.Interfaces;

namespace Data.DataAccess
{
    public class TransactionItemDao : GenericItemDao<TransactionItem>, ITransactionItemDao
    {
        public TransactionItemDao(ILogger<TransactionItem> logger, IRequestService requestService, IFileService fileService) : base(logger, requestService, fileService)
        {
        }
    }
}
