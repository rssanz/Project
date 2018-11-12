using Data.Domain;
using System.Collections.Generic;
using ServiceUtilsInterface.Interfaces;

namespace ServiceRate.Interfaces
{
    public interface IRateService : IBaseService<RateItem>
    {
        decimal Convert(List<RateItem> rates, string c1, string c2, decimal amount);
    }
}
