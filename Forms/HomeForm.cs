using LibraryApp.Services;

namespace LibraryApp.Forms;

/// <summary>Home screen: welcome message, four summary cards and quick navigation buttons.</summary>
public class HomeForm : ChildForm
{
    private readonly Label lblBooks = new(), lblMembers = new(), lblActive = new(), lblOverdue = new();

    public HomeForm()
    {
        var welcome = new Label
        {
            Text = "Welcome to the Library Management System",
            Font = new Font("Segoe UI", 18f, FontStyle.Bold),
            ForeColor = Ui.Primary,
            AutoSize = true,
            Location = new Point(30, 25)
        };
        var sub = new Label
        {
            Text = "Manage books, members and loans from one place.",
            ForeColor = Color.Gray,
            AutoSize = true,
            Location = new Point(33, 65)
        };

        Controls.Add(welcome);
        Controls.Add(sub);
        Controls.Add(Card("Books in catalogue", lblBooks, 33, 115));
        Controls.Add(Card("Registered members", lblMembers, 273, 115));
        Controls.Add(Card("Active loans", lblActive, 513, 115));
        Controls.Add(Card("Overdue loans", lblOverdue, 753, 115));

        Controls.Add(Ui.MakeLabel("Quick actions", 33, 270, bold: true));
        AddQuick("Manage books", 33, () => MainForm.GoTo("Books"));
        AddQuick("Manage members", 213, () => MainForm.GoTo("Members"));
        AddQuick("Issue / return", 393, () => MainForm.GoTo("Loans"));
        AddQuick("View reports", 573, () => MainForm.GoTo("Reports"));
    }

    private void AddQuick(string text, int x, Action action)
    {
        var b = Ui.MakeButton(text, x, 300, 165, primary: true);
        b.Height = 40;
        b.Click += (_, _) => action();
        Controls.Add(b);
    }

    private static Panel Card(string title, Label value, int x, int y)
    {
        var p = new Panel { Location = new Point(x, y), Size = new Size(220, 120), BackColor = Ui.Panel };
        p.Controls.Add(new Label
        {
            Text = title, ForeColor = Color.Gray, AutoSize = true, Location = new Point(15, 15)
        });
        value.Font = new Font("Segoe UI", 28f, FontStyle.Bold);
        value.ForeColor = Ui.Primary;
        value.AutoSize = true;
        value.Location = new Point(13, 45);
        p.Controls.Add(value);
        return p;
    }

    protected override void RefreshData()
    {
        lblBooks.Text = LibraryService.BookCount.ToString();
        lblMembers.Text = LibraryService.MemberCount.ToString();
        lblActive.Text = LibraryService.ActiveLoanCount.ToString();
        lblOverdue.Text = LibraryService.OverdueLoanCount.ToString();
        lblOverdue.ForeColor = LibraryService.OverdueLoanCount > 0 ? Ui.Danger : Ui.Primary;
    }
}
