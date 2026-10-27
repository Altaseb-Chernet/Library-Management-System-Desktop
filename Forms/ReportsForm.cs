using LibraryApp.Services;

namespace LibraryApp.Forms;

/// <summary>Simple reporting view: summary numbers plus three report tabs.</summary>
public class ReportsForm : ChildForm
{
    private readonly Label lblSummary = new() { Location = new Point(15, 14), AutoSize = true, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Ui.Primary };

    private readonly ListView overdue = Ui.MakeList(
        ("Loan", 55), ("Member", 190), ("Book", 280), ("Due date", 100), ("Days late", 80), ("Fine so far (Birr)", 130));
    private readonly ListView popular = Ui.MakeList(
        ("Rank", 55), ("Title", 300), ("Author", 200), ("Category", 130), ("Times borrowed", 120));
    private readonly ListView fines = Ui.MakeList(
        ("Loan", 55), ("Member", 190), ("Book", 280), ("Status", 90), ("Fine (Birr)", 100));

    public ReportsForm()
    {
        var top = new Panel { Dock = DockStyle.Top, Height = 48, BackColor = Ui.Panel };
        top.Controls.Add(lblSummary);

        var tabs = new TabControl { Dock = DockStyle.Fill };
        tabs.TabPages.Add(PageOf("Overdue loans", overdue));
        tabs.TabPages.Add(PageOf("Most borrowed books", popular));
        tabs.TabPages.Add(PageOf("Unpaid fines", fines));

        Controls.Add(tabs);
        Controls.Add(top);
    }

    private static TabPage PageOf(string title, ListView lv)
    {
        var page = new TabPage(title) { BackColor = Color.White };
        page.Controls.Add(lv);
        return page;
    }

    protected override void RefreshData()
    {
        lblSummary.Text =
            $"Books: {LibraryService.BookCount}     Members: {LibraryService.MemberCount}     " +
            $"Active loans: {LibraryService.ActiveLoanCount}     Overdue: {LibraryService.OverdueLoanCount}";

        overdue.Items.Clear();
        foreach (var l in LibraryService.GetLoans("Overdue"))
        {
            int late = (DateTime.Today - l.DueDate.Date).Days;
            var item = Ui.Row(l.Id, l.Id.ToString(), LibraryService.GetMember(l.MemberId)?.Name ?? "?",
                LibraryService.GetBook(l.BookId)?.Title ?? "?", l.DueDate.ToString("dd MMM yyyy"),
                late.ToString(), LibraryService.FineOf(l).ToString("N2"));
            item.ForeColor = Ui.Danger;
            overdue.Items.Add(item);
        }

        popular.Items.Clear();
        int rank = 1;
        foreach (var (book, count) in LibraryService.MostBorrowed())
            popular.Items.Add(Ui.Row(book.Id, (rank++).ToString(), book.Title, book.Author, book.Category, count.ToString()));

        fines.Items.Clear();
        foreach (var l in LibraryService.UnpaidFines())
            fines.Items.Add(Ui.Row(l.Id, l.Id.ToString(), LibraryService.GetMember(l.MemberId)?.Name ?? "?",
                LibraryService.GetBook(l.BookId)?.Title ?? "?", LibraryService.StatusOf(l),
                LibraryService.FineOf(l).ToString("N2")));

        MainForm.SetStatus("Reports updated.");
    }
}
