namespace DataInterfaces.Interfaces
{
    public interface IGenericItemDao<T>
    {
        string Get(string endPoint, string filePath);
    }
}
