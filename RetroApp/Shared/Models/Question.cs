using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroApp.Shared.Models;

public class Question
{
    public string QuestionId { get; set; } = String.Empty;
    public string QuestionName { get; set; } = String.Empty;
    public Dictionary<string, string> Answers { get; set; } = new Dictionary<string, string>();
    public List<string> WinningUsers { get; set; } = new List<string>();
}
