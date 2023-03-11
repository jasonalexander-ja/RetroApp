using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RetroApp.Shared.Models;

namespace RetroApp.Server.Models;

public class RetroSessionModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string PassCode { get; set; } = string.Empty;
    public List<QuestionModel> Questions { get; set; } = new List<QuestionModel>();
    public List<SessionUserModel> SessionUsers { get; set; } = new List<SessionUserModel>();

    public RetroSession ToDTO()
    {
        return new RetroSession()
        {
            Id = Id ?? String.Empty,
            Questions = Questions.Select(q => q.ToDTO()).ToList(),
            SessionUsers = SessionUsers.Select(q => q.ToDTO()).ToList(),
        };
    }
}
