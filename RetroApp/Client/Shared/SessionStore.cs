using RetroApp.Shared.Models;

namespace RetroApp.Client.Shared;

public class SessionStore
{
    public RetroSession? Session { get; set; }

    public void AddUser(SessionUser user) => Session?.SessionUsers.Add(user);
}
