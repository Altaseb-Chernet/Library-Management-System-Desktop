using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using System.Windows.Forms;

namespace LibraryManagementSystem.Forms;

public partial class IssueReturnForm : Form
{
    private readonly LibraryService libraryService;

    public IssueReturnForm() : this(new LibraryService())
    {
    }

    public IssueReturnForm(LibraryService service)
    {
        libraryService = service;
        InitializeComponent();
        RefreshChoices();
        RefreshLoans();
    }

    private void RefreshChoices()
    {
        memberComboBox.Items.Clear();
        memberComboBox.Items.AddRange(libraryService.Members.Select(x => $"{x.Id} - {x.Name}").ToArray());
        if (memberComboBox.Items.Count > 0)
            memberComboBox.SelectedIndex = 0;

        bookComboBox.Items.Clear();
        bookComboBox.Items.AddRange(libraryService.Books.Where(x => x.IsAvailable).Select(x => $"{x.Id} - {x.Title}").ToArray());
        if (bookComboBox.Items.Count > 0)
            bookComboBox.SelectedIndex = 0;
    }

    private void RefreshLoans()
    {
        loansGrid.Rows.Clear();
        foreach (var loan in libraryService.Loans)
        {
            var book = libraryService.Books.First(x => x.Id == loan.BookId);
            var member = libraryService.Members.First(x => x.Id == loan.MemberId);
            loansGrid.Rows.Add(loan.Id, book.Title, member.Name, loan.IssuedOn.ToShortDateString(), loan.IsReturned ? loan.ReturnedOn!.Value.ToShortDateString() : "Active");
        }
    }

    private void IssueButton_Click(object? sender, EventArgs e)
    {
        if (memberComboBox.SelectedIndex < 0 || bookComboBox.SelectedIndex < 0)
            return;

        var member = libraryService.Members[memberComboBox.SelectedIndex];
        var book = libraryService.Books.Where(x => x.IsAvailable).ElementAt(bookComboBox.SelectedIndex);
        libraryService.IssueBook(book, member);
        messageLabel.Text = "Book issued successfully.";
        RefreshChoices();
        RefreshLoans();
    }

    private void ReturnButton_Click(object? sender, EventArgs e)
    {
        if (loansGrid.CurrentRow is null || loansGrid.CurrentRow.Index >= libraryService.Loans.Count)
            return;

        var loan = libraryService.Loans[loansGrid.CurrentRow.Index];
        libraryService.ReturnBook(loan);
        messageLabel.Text = "Book returned successfully.";
        RefreshChoices();
        RefreshLoans();
    }
}
