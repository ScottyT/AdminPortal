using System.Linq.Expressions;
using AdminPortal.Interfaces;
using AdminPortal.Models;
using MongoDB.Driver;

namespace AdminPortal;

public class MongoService<TDocument, TForeign> : IMongoService<TDocument, TForeign>
    where TDocument : IDocument, new()
{
    readonly IMongoCollection<TDocument> _collection;
    private readonly IMongoDatabase _database;
    public MongoService(IMongoRepo database)
    {
        //var database = new MongoClient(connectionString).GetDatabase(databaseName);
        _database = database.GetDatabase();
        _collection = _database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
    }
    private protected string GetCollectionName(Type documentType)
    {
        return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
            typeof(BsonCollectionAttribute),
            true
        ).FirstOrDefault()).CollectionName;
    }

    public IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<TDocument, bool>> filterExpression, Expression<Func<TDocument, TProjected>> projectionExpression)
    {
        return _collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
    }

    public IQueryable<TDocument> GetAll()
    {
        return _collection.AsQueryable();
    }
}