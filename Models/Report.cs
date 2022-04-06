using AdminPortal.Interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace AdminPortal.Models;

[BsonIgnoreExtraElements]
[BsonCollection("reports")]
public class Report : Document
{
    public string JobId { get; set; } = null!;
    public string ReportType { get; set; } = default!;
    public string? formType { get; set; }
    public TeamMember teamMember { get; set; } = new TeamMember();
    public string? date { get; set; }
}

[BsonIgnoreExtraElements]
public class TeamMember
{
    public string? name {get; set;}
    public string? email {get; set;}
    [BsonElement("id")]
    public string? employee_id {get; set;}
    public string? role {get; set;}
}