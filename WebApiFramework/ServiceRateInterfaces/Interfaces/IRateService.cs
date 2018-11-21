using System.Collections.Generic;
using ServiceUtilsInterface.Interfaces;
using DataEntities.Domain;

namespace ServiceRate.Interfaces
{
    public interface IRateService : IBaseService<Rate>
    {
        decimal Convert(List<Rate> rates, string c1, string c2, decimal amount);
    }
}
