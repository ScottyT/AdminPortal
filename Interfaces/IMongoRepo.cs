using MongoDB.Driver;

namespace AdminPortal.Interfaces;
public interface IMongoRepo
{
    IMongoDatabase GetDatabase();
}