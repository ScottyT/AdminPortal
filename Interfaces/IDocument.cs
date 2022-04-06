using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdminPortal.Interfaces;
public interface IDocument
{
    string? Id {get; set;}
}
public class Document : IDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class BsonCollectionAttribute : Attribute
{
    public string CollectionName { get; }

    public BsonCollectionAttribute(string collectionName)
    {
        CollectionName = collectionName;
    }
}