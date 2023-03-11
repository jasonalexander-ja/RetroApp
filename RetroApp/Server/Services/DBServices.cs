using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RetroApp.Server.Models;

namespace RetroApp.Server.Services;

public class DBService
{
    private readonly IMongoCollection<RetroSessionModel> Collection;
    public DBService(IOptions<DatabaseSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

        Collection = mongoDatabase.GetCollection<RetroSessionModel>(settings.Value.CollectionName);
    }

    public async Task<RetroSessionModel?> GetAsync(string id) => 
        await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<bool> ExistsAsync(string id) =>
        await Collection.Find(x => x.Id == id).AnyAsync();

    public async Task<RetroSessionModel> AddUserAsync(string sessionId, RetroSessionModel model, SessionUserModel user) 
    { 
        model.SessionUsers.Add(user);
        await Collection.ReplaceOneAsync(x => x.Id == sessionId, model);
        return model;
    }

    public async Task UpdateSessionAsync(string sessionId, RetroSessionModel model) =>
        await Collection.ReplaceOneAsync(x => x.Id == sessionId, model);
}
