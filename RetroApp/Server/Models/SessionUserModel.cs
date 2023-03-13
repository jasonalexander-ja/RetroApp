using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RetroApp.Shared.Models;

namespace RetroApp.Server.Models;

public class SessionUserModel
{
    public SessionUserModel(string userName, string connId)
    {
        DisplayName = userName;
        ConnectionId = connId;
        SessionUserId = Guid.NewGuid().ToString();
    }
    [BsonId]
    public string SessionUserId { get; set; }
    public string DisplayName { get; set; } = String.Empty;
    public string ConnectionId { get; set; } = String.Empty;

    public SessionUser ToDTO()
    {
        return new SessionUser()
        {
            SessionUserId = SessionUserId,
            DisplayName = DisplayName
        };
    }
}
