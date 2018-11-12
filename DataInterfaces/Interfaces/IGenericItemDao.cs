namespace Data.DataAccess
{
    public interface IGenericItemDao<T>
    {
        string Get(string endPoint, string filePath);
    }
}
