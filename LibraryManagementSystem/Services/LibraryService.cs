using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services;

public sealed class LibraryService
{
    private int nextBookId = 4;
    private int nextMemberId = 4;
    private int nextLoanId = 3;
    private int nextStaffId = 3;

    public List<Book> Books { get; } =
    [
        new Book { Id = 1, Title = "The Hobbit", Author = "J.R.R. Tolkien" },
        new Book { Id = 2, Title = "Clean Code", Author = "Robert C. Martin", IsAvailable = false },
        new Book { Id = 3, Title = "Pride and Prejudice", Author = "Jane Austen" }
    ];

    public List<Member> Members { get; } =
    [
        new Member { Id = 1, Name = "Amina Yusuf", Phone = "555-0101" },
        new Member { Id = 2, Name = "Daniel Smith", Phone = "555-0102" },
        new Member { Id = 3, Name = "Sara Ahmed", Phone = "555-0103" }
    ];

    public List<Loan> Loans { get; } =
    [
        new Loan { Id = 1, BookId = 2, MemberId = 1, IssuedOn = DateTime.Today.AddDays(-4) },
        new Loan { Id = 2, BookId = 3, MemberId = 3, IssuedOn = DateTime.Today.AddDays(-2), ReturnedOn = DateTime.Today.AddDays(-1) }
    ];

    public List<StaffMember> Staff { get; } =
    [
        new StaffMember { Id = 1, Username = "admin", Password = "admin123", Role = "Administrator" },
        new StaffMember { Id = 2, Username = "librarian", Password = "library123", Role = "Librarian" }
    ];

    public StaffMember? ValidateLogin(string username, string password) =>
        Staff.FirstOrDefault(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && x.Password == password);

    public Book AddBook(string title, string author)
    {
        var book = new Book { Id = nextBookId++, Title = title.Trim(), Author = author.Trim() };
        Books.Add(book);
        return book;
    }

    public void DeleteBook(Book book)
    {
        if (Loans.Any(x => x.BookId == book.Id && !x.IsReturned))
            throw new InvalidOperationException("A book on loan cannot be deleted.");
        Books.Remove(book);
    }

    public Member AddMember(string name, string phone)
    {
        var member = new Member { Id = nextMemberId++, Name = name.Trim(), Phone = phone.Trim() };
        Members.Add(member);
        return member;
    }

    public void DeleteMember(Member member)
    {
        if (Loans.Any(x => x.MemberId == member.Id && !x.IsReturned))
            throw new InvalidOperationException("A member with an active loan cannot be deleted.");
        Members.Remove(member);
    }

    public Loan IssueBook(Book book, Member member)
    {
        if (!book.IsAvailable)
            throw new InvalidOperationException("This book is already on loan.");

        book.IsAvailable = false;
        var loan = new Loan { Id = nextLoanId++, BookId = book.Id, MemberId = member.Id };
        Loans.Add(loan);
        return loan;
    }

    public void ReturnBook(Loan loan)
    {
        if (loan.IsReturned)
            return;

        loan.ReturnedOn = DateTime.Today;
        var book = Books.First(x => x.Id == loan.BookId);
        book.IsAvailable = true;
    }

    public StaffMember AddStaff(string username, string password, string role)
    {
        if (Staff.Any(x => x.Username.Equals(username.Trim(), StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException("That username already exists.");

        var staff = new StaffMember { Id = nextStaffId++, Username = username.Trim(), Password = password, Role = role };
        Staff.Add(staff);
        return staff;
    }

    public void DeleteStaff(StaffMember staff)
    {
        if (staff.Role == "Administrator" && Staff.Count(x => x.Role == "Administrator") == 1)
            throw new InvalidOperationException("The last administrator cannot be deleted.");
        Staff.Remove(staff);
    }
}
