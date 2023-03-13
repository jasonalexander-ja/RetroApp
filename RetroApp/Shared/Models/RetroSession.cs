namespace RetroApp.Shared.Models;

public class RetroSession
{
    public string Id { get; set; } = String.Empty;
    public string AdminUser { get; set; } = String.Empty;
    public List<Question> Questions { get; set; } = new List<Question>();
    public List<SessionUser> SessionUsers { get; set; } = new List<SessionUser>();
}
