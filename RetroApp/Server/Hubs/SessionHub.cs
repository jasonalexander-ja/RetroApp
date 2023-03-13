using RetroApp.Server.Services;
using Microsoft.AspNetCore.SignalR;
using RetroApp.Server.Models;

namespace RetroApp.Server.Hubs;

public class SessionHub : Hub
{
    private DBService DBService { get; set; }
    public SessionHub(DBService _DBService)
    {
        DBService = _DBService;
    }

    public async Task JoinSession(string sessionId, string userName)
    {
        RetroSessionModel? session = await DBService.GetAsync(sessionId);
        if (session is null) 
        {
            await Clients.Client(Context.ConnectionId).SendAsync("NoSuchSession", sessionId);
            return;
        }
        if (session.SessionUsers.Any(u => u.DisplayName == userName))
        {
            await Clients.Client(Context.ConnectionId).SendAsync("UserAlreadyExists", userName);
            return;
        }
        var user = new SessionUserModel(userName, Context.ConnectionId);
        var updatedSession = await DBService.AddUserAsync(sessionId, session, user);

        await Clients.Group(sessionId).SendAsync("AddedUser", user.ToDTO());
        await Groups.AddToGroupAsync(Context.ConnectionId, sessionId);
        await Clients.Client(Context.ConnectionId).SendAsync("SessionJoined", updatedSession.ToDTO(), user.ToDTO());
    }
}
