using LibraryApp.Models;

namespace LibraryApp.Services;

/// <summary>
/// Phase 1: all data lives in memory (lists). No database yet.
/// In Phase 2 this class is replaced by calls to the REST API.
/// </summary>
public static class LibraryService
{
    // ---- Basic business rules -------------------------------------------
    public const int LoanDays = 14;
    public const int MaxLoansPerMember = 3;
    public const int MaxRenewals = 1;
    public const decimal FinePerDay = 2m;

    // ---- In-memory storage ----------------------------------------------
    private static readonly List<Book> books = new();
    private static readonly List<Member> members = new();
    private static readonly List<Loan> loans = new();
    private static readonly List<AppUser> users = new()
    {
        new AppUser { Username = "admin",     Password = "admin123", FullName = "System Administrator", Role = "Administrator" },
        new AppUser { Username = "librarian", Password = "lib123",   FullName = "Front Desk Librarian", Role = "Librarian" },
    };

    private static int nextBookId = 1, nextMemberId = 1, nextLoanId = 1;

    /// <summary>Raised after any change so open screens can refresh themselves.</summary>
    public static event Action? DataChanged;

    public static AppUser? CurrentUser { get; private set; }

    static LibraryService() => Seed();

    private static void Changed() => DataChanged?.Invoke();

    // ---- Authentication ---------------------------------------------------
    public static Result Login(string username, string password)
    {
        var user = users.FirstOrDefault(u =>
            u.Username.Equals(username.Trim(), StringComparison.OrdinalIgnoreCase) && u.Password == password);
        if (user == null) return new Result(false, "Wrong username or password.");
        CurrentUser = user;
        return new Result(true, $"Welcome, {user.FullName}.");
    }

    public static void Logout() => CurrentUser = null;

    // ---- Books ------------------------------------------------------------
    public static Book? GetBook(int id) => books.FirstOrDefault(b => b.Id == id);

    public static List<string> Categories() =>
        books.Select(b => b.Category).Distinct().OrderBy(c => c).ToList();

    public static List<Book> SearchBooks(string text, string? category)
    {
        text = (text ?? "").Trim();
        return books.Where(b =>
                (string.IsNullOrEmpty(category) || b.Category == category) &&
                (text.Length == 0 ||
                 b.Title.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                 b.Author.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                 b.Isbn.Contains(text, StringComparison.OrdinalIgnoreCase)))
            .OrderBy(b => b.Title).ToList();
    }

    public static List<Book> AvailableBooks() =>
        books.Where(b => b.AvailableCopies > 0).OrderBy(b => b.Title).ToList();

    public static int BookCount => books.Count;

    public static Result AddBook(string title, string author, string isbn, string category, int copies)
    {
        if (books.Any(b => b.Isbn == isbn.Trim()))
            return new Result(false, "A book with this ISBN already exists.");
        books.Add(new Book
        {
            Id = nextBookId++, Title = title.Trim(), Author = author.Trim(), Isbn = isbn.Trim(),
            Category = category.Trim(), TotalCopies = copies, AvailableCopies = copies
        });
        Changed();
        return new Result(true, "Book added successfully.");
    }

    public static Result UpdateBook(int id, string title, string author, string isbn, string category, int copies)
    {
        var book = GetBook(id);
        if (book == null) return new Result(false, "Book not found.");
        if (books.Any(b => b.Id != id && b.Isbn == isbn.Trim()))
            return new Result(false, "Another book already uses this ISBN.");

        int onLoan = book.TotalCopies - book.AvailableCopies;
        if (copies < onLoan)
            return new Result(false, $"{onLoan} copies are currently on loan, so copies cannot be less than {onLoan}.");

        book.Title = title.Trim(); book.Author = author.Trim(); book.Isbn = isbn.Trim();
        book.Category = category.Trim(); book.TotalCopies = copies; book.AvailableCopies = copies - onLoan;
        Changed();
        return new Result(true, "Book updated successfully.");
    }

    public static Result DeleteBook(int id)
    {
        var book = GetBook(id);
        if (book == null) return new Result(false, "Book not found.");
        if (loans.Any(l => l.BookId == id && l.ReturnDate == null))
            return new Result(false, "This book has active loans and cannot be deleted.");
        books.Remove(book);
        Changed();
        return new Result(true, "Book deleted.");
    }

    // ---- Members ----------------------------------------------------------
    public static Member? GetMember(int id) => members.FirstOrDefault(m => m.Id == id);

    public static int MemberCount => members.Count;

    public static List<Member> SearchMembers(string text)
    {
        text = (text ?? "").Trim();
        return members.Where(m => text.Length == 0 ||
                m.Name.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                m.Email.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                m.Phone.Contains(text) ||
                m.Code.Contains(text, StringComparison.OrdinalIgnoreCase))
            .OrderBy(m => m.Name).ToList();
    }

    public static List<Member> ActiveMembers() =>
        members.Where(m => m.IsActive).OrderBy(m => m.Name).ToList();

    public static Result AddMember(string name, string email, string phone)
    {
        if (members.Any(m => m.Email.Equals(email.Trim(), StringComparison.OrdinalIgnoreCase)))
            return new Result(false, "A member with this email already exists.");
        members.Add(new Member
        {
            Id = nextMemberId++, Name = name.Trim(), Email = email.Trim(), Phone = phone.Trim(),
            JoinDate = DateTime.Today, IsActive = true
        });
        Changed();
        return new Result(true, "Member registered successfully.");
    }

    public static Result UpdateMember(int id, string name, string email, string phone, bool active)
    {
        var m = GetMember(id);
        if (m == null) return new Result(false, "Member not found.");
        if (members.Any(x => x.Id != id && x.Email.Equals(email.Trim(), StringComparison.OrdinalIgnoreCase)))
            return new Result(false, "Another member already uses this email.");
        m.Name = name.Trim(); m.Email = email.Trim(); m.Phone = phone.Trim(); m.IsActive = active;
        Changed();
        return new Result(true, "Member updated successfully.");
    }

    public static Result DeleteMember(int id)
    {
        var m = GetMember(id);
        if (m == null) return new Result(false, "Member not found.");
        if (loans.Any(l => l.MemberId == id && (l.ReturnDate == null || (l.Fine > 0 && !l.FinePaid))))
            return new Result(false, "This member has active loans or unpaid fines and cannot be deleted.");
        members.Remove(m);
        Changed();
        return new Result(true, "Member deleted.");
    }

    // ---- Loans ------------------------------------------------------------
    public static bool IsOverdue(Loan l) => l.ReturnDate == null && l.DueDate.Date < DateTime.Today;

    public static string StatusOf(Loan l) =>
        l.ReturnDate != null ? "Returned" : IsOverdue(l) ? "Overdue" : "Active";

    /// <summary>Fine so far: for returned loans the stored fine, for overdue loans days late x rate.</summary>
    public static decimal FineOf(Loan l)
    {
        if (l.ReturnDate != null) return l.Fine;
        return IsOverdue(l) ? (DateTime.Today - l.DueDate.Date).Days * FinePerDay : 0m;
    }

    public static int ActiveLoanCount => loans.Count(l => l.ReturnDate == null);
    public static int OverdueLoanCount => loans.Count(IsOverdue);

    public static List<Loan> GetLoans(string filter) => loans.Where(l => filter switch
        {
            "Active"   => l.ReturnDate == null,
            "Overdue"  => IsOverdue(l),
            "Returned" => l.ReturnDate != null,
            _          => true
        })
        .OrderByDescending(l => l.IssueDate).ThenByDescending(l => l.Id).ToList();

    public static List<Loan> UnpaidFines() =>
        loans.Where(l => !l.FinePaid && FineOf(l) > 0).OrderByDescending(l => FineOf(l)).ToList();

    public static int ActiveLoansOf(int memberId) =>
        loans.Count(l => l.MemberId == memberId && l.ReturnDate == null);

    public static List<(Book Book, int Count)> MostBorrowed(int top = 10) =>
        loans.GroupBy(l => l.BookId)
             .Select(g => (Book: GetBook(g.Key), Count: g.Count()))
             .Where(x => x.Book != null)
             .Select(x => (x.Book!, x.Count))
             .OrderByDescending(x => x.Item2).Take(top).ToList();

    public static Result Issue(int memberId, int bookId)
    {
        var member = GetMember(memberId);
        var book = GetBook(bookId);
        if (member == null) return new Result(false, "Please select a member.");
        if (book == null) return new Result(false, "Please select a book.");
        if (!member.IsActive) return new Result(false, "This member account is inactive.");
        if (book.AvailableCopies <= 0) return new Result(false, "No copies of this book are available.");
        if (ActiveLoansOf(memberId) >= MaxLoansPerMember)
            return new Result(false, $"A member can borrow at most {MaxLoansPerMember} books at a time.");
        if (loans.Any(l => l.MemberId == memberId && IsOverdue(l)))
            return new Result(false, "This member has overdue books. Return them first.");
        if (loans.Any(l => l.MemberId == memberId && l.Fine > 0 && !l.FinePaid))
            return new Result(false, "This member has unpaid fines. Please collect them first.");

        loans.Add(new Loan
        {
            Id = nextLoanId++, BookId = bookId, MemberId = memberId,
            IssueDate = DateTime.Today, DueDate = DateTime.Today.AddDays(LoanDays)
        });
        book.AvailableCopies--;
        Changed();
        return new Result(true, $"'{book.Title}' issued to {member.Name}. Due {DateTime.Today.AddDays(LoanDays):dd MMM yyyy}.");
    }

    public static (Result Result, Loan? Loan) Return(int loanId)
    {
        var loan = loans.FirstOrDefault(l => l.Id == loanId);
        if (loan == null) return (new Result(false, "Loan not found."), null);
        if (loan.ReturnDate != null) return (new Result(false, "This book was already returned."), loan);

        loan.ReturnDate = DateTime.Today;
        int daysLate = Math.Max(0, (DateTime.Today - loan.DueDate.Date).Days);
        loan.Fine = daysLate * FinePerDay;
        loan.FinePaid = loan.Fine == 0;
        var book = GetBook(loan.BookId);
        if (book != null) book.AvailableCopies++;
        Changed();

        string msg = loan.Fine > 0
            ? $"Book returned {daysLate} day(s) late. Fine: {loan.Fine:N2} Birr."
            : "Book returned on time. No fine.";
        return (new Result(true, msg), loan);
    }

    public static Result Renew(int loanId)
    {
        var loan = loans.FirstOrDefault(l => l.Id == loanId);
        if (loan == null) return new Result(false, "Loan not found.");
        if (loan.ReturnDate != null) return new Result(false, "Returned books cannot be renewed.");
        if (IsOverdue(loan)) return new Result(false, "Overdue books cannot be renewed. Please return it.");
        if (loan.Renewals >= MaxRenewals) return new Result(false, "This loan was already renewed the maximum number of times.");
        loan.DueDate = loan.DueDate.AddDays(LoanDays);
        loan.Renewals++;
        Changed();
        return new Result(true, $"Loan renewed. New due date: {loan.DueDate:dd MMM yyyy}.");
    }

    public static Result PayFine(int loanId)
    {
        var loan = loans.FirstOrDefault(l => l.Id == loanId);
        if (loan == null) return new Result(false, "Loan not found.");
        if (loan.ReturnDate == null) return new Result(false, "Return the book first, then collect the fine.");
        if (loan.Fine <= 0 || loan.FinePaid) return new Result(false, "There is no unpaid fine on this loan.");
        loan.FinePaid = true;
        Changed();
        return new Result(true, $"Fine of {loan.Fine:N2} Birr marked as paid.");
    }

    // ---- Sample data so the screens are not empty at first run -------------
    private static void Seed()
    {
        AddBook("Introduction to Algorithms", "Thomas H. Cormen", "9780262046305", "Computer Science", 3);
        AddBook("Clean Code", "Robert C. Martin", "9780132350884", "Computer Science", 2);
        AddBook("C# in Depth", "Jon Skeet", "9781617294532", "Computer Science", 2);
        AddBook("Database System Concepts", "Abraham Silberschatz", "9780078022159", "Computer Science", 2);
        AddBook("Things Fall Apart", "Chinua Achebe", "9780385474542", "Literature", 4);
        AddBook("Fiker Eskemekabir", "Haddis Alemayehu", "9789994453019", "Literature", 2);
        AddBook("A Brief History of Time", "Stephen Hawking", "9780553380163", "Science", 2);
        AddBook("Sapiens", "Yuval Noah Harari", "9780062316097", "History", 3);

        AddMember("Abebe Kebede", "abebe@example.com", "0911000001");
        AddMember("Selam Tesfaye", "selam@example.com", "0911000002");
        AddMember("Daniel Mulugeta", "daniel@example.com", "0911000003");
        AddMember("Hana Bekele", "hana@example.com", "0911000004");

        // A normal loan, a loan that is already overdue, and a returned loan
        SeedLoan(1, 1, issuedDaysAgo: 3);
        SeedLoan(2, 5, issuedDaysAgo: 20);   // due 6 days ago -> overdue
        SeedLoan(3, 2, issuedDaysAgo: 40, returnedDaysAgo: 10); // returned late, fine unpaid
    }

    private static void SeedLoan(int memberId, int bookId, int issuedDaysAgo, int? returnedDaysAgo = null)
    {
        var loan = new Loan
        {
            Id = nextLoanId++, BookId = bookId, MemberId = memberId,
            IssueDate = DateTime.Today.AddDays(-issuedDaysAgo),
            DueDate = DateTime.Today.AddDays(-issuedDaysAgo + LoanDays)
        };
        if (returnedDaysAgo != null)
        {
            loan.ReturnDate = DateTime.Today.AddDays(-returnedDaysAgo.Value);
            int late = Math.Max(0, (loan.ReturnDate.Value - loan.DueDate).Days);
            loan.Fine = late * FinePerDay;
            loan.FinePaid = loan.Fine == 0;
        }
        else
        {
            var book = GetBook(bookId);
            if (book != null) book.AvailableCopies--;
        }
        loans.Add(loan);
    }
}
