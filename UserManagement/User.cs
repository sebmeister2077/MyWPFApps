using System;

namespace UserManagement;

public sealed class User
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public bool IsAdmin { get; set; }
}
