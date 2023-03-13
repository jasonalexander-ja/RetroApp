using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RetroApp.Shared.Models;

namespace RetroApp.Server.Models;

public class QuestionModel
{
    [BsonId]
    public string QuestionId { get; set; } = String.Empty;
    public string QuestionName { get; set; } = String.Empty;
    public List<string> Answers { get; set; } = new List<string>();
    public string AnswerKey { get; set; } = String.Empty;
    public List<string> WinningUsers { get; set; } = new List<string>();

    public Question ToDTO()
    {
        return new Question()
        {
            QuestionId = QuestionId,
            QuestionName = QuestionName,
            Answers = Answers,
            WinningUsers = WinningUsers
        };
    }
}
