using LibraryManagementSystem.Services;
using System.Windows.Forms;

namespace LibraryManagementSystem.Forms;

public partial class ReportsForm : Form
{
    public ReportsForm() : this(new LibraryService())
    {
    }

    public ReportsForm(LibraryService service)
    {
        InitializeComponent();
        totalBooksLabel.Text = $"Total books: {service.Books.Count}";
        loansLabel.Text = $"Books currently on loan: {service.Loans.Count(x => !x.IsReturned)}";
        membersLabel.Text = $"Registered members: {service.Members.Count}";
        overdueLabel.Text = "Overdue books: 0";
    }
}
