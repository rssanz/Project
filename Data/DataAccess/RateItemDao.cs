using Data.Domain;
using Microsoft.Extensions.Logging;
using ServiceUtils.Interfaces;

namespace Data.DataAccess
{
    public class RateItemDao : GenericItemDao<RateItem>, IRateItemDao
    {
        public RateItemDao(ILogger<RateItem> logger, IRequestService requestService, IFileService fileService) : base(logger, requestService, fileService)
        {
        }
    }
}
