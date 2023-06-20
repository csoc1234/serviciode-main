using APILogs.Domain.Entity;

namespace APILogs.Domain.Interface
{
    public interface IContextDomain
    {
        Task<Logs> Mongo(Logs logs, string application, string frequency);
    }
}
