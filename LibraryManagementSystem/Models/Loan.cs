namespace LibraryManagementSystem.Models;

public sealed class Loan
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public DateTime IssuedOn { get; set; } = DateTime.Today;
    public DateTime? ReturnedOn { get; set; }
    public bool IsReturned => ReturnedOn.HasValue;
}
