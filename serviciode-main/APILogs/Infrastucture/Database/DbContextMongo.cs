using APILogs.Domain.Entity;
using APILogs.Infrastucture.Interface;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APILogs.Infrastucture.Database
{
    public class DbContextMongo : IDbContextMongo
    {
        private readonly IMongoDatabase _database;
        private static IMongoCollection<Logs> _logCollecion;

        public DbContextMongo(IOptions<MongoDbSettings> mongoDbSettings)
        {
            MongoClient client = new MongoClient(mongoDbSettings.Value.ConnectionURI);
            _database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
        }

        public async Task<Logs> CreateAsync(Logs logs, string collectionName)
        {
            _logCollecion = _database.GetCollection<Logs>(collectionName);
            await _logCollecion.InsertOneAsync(logs);
            return logs;
        }
    }
}
