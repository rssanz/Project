using DataEntities.Domain;
using System.Collections.Generic;

namespace ServiceUtilsInterface.Interfaces
{
    public interface IBaseService<T> where T : Entity
    {
        List<T> List();
        T Get(int id);
    }
}
