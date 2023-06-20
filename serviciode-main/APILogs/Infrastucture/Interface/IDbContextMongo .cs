using APILogs.Domain.Entity;

namespace APILogs.Infrastucture.Interface
{
    public interface IDbContextMongo
    {
        Task<Logs> CreateAsync(Logs logs, string collectionName);
    }
}
