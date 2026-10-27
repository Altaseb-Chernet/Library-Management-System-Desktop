namespace LibraryApp.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public string Isbn { get; set; } = "";
    public string Category { get; set; } = "";
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
}

public class Member
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public DateTime JoinDate { get; set; }
    public bool IsActive { get; set; } = true;

    public string Code => $"M-{Id:000}";
}

public class Loan
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int Renewals { get; set; }
    public decimal Fine { get; set; }
    public bool FinePaid { get; set; }
}

public class AppUser
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string FullName { get; set; } = "";
    public string Role { get; set; } = "";
}

public record Result(bool Ok, string Message);
