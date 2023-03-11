using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroApp.Shared.Models;

public class SessionUser
{
    public string SessionUserId { get; set; } = String.Empty;
    public string DisplayName { get; set; } = String.Empty;
    public string ConnectionID { get; set; } = String.Empty;
}
