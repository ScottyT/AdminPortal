using AdminPortal.Interfaces;
using MongoDB.Driver;

namespace AdminPortal;
public class MongoRepo : IMongoRepo
{
    readonly MongoClient _client;
    readonly string _databaseName;
    public MongoRepo(string connectionString, string databaseName)
    {
        _client = new MongoClient(connectionString);
        _databaseName = databaseName;
    }

    public IMongoDatabase GetDatabase()
    {
        return _client.GetDatabase(_databaseName);
    }
}