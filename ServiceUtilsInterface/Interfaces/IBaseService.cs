using System.Collections.Generic;

namespace ServiceUtilsInterface.Interfaces
{
    public interface IBaseService<T>
    {
        List<T> List();
    }
}
