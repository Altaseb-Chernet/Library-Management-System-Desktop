using LibraryManagementSystem.Services;
using System.Windows.Forms;

namespace LibraryManagementSystem.Forms;

public partial class HomeForm : Form
{
    public HomeForm() : this(new LibraryService())
    {
    }

    public HomeForm(LibraryService service)
    {
        InitializeComponent();
        booksSummaryLabel.Text = $"Books\n{service.Books.Count}";
        membersSummaryLabel.Text = $"Members\n{service.Members.Count}";
        loansSummaryLabel.Text = $"On loan\n{service.Loans.Count(x => !x.IsReturned)}";
    }
}
