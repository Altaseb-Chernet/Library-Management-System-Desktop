namespace LibraryManagementSystem.Models;

public sealed class StaffMember
{
    public int Id { get; set; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string Role { get; set; } = "Librarian";
}
