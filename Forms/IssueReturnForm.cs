using LibraryApp.Services;

namespace LibraryApp.Forms;

public class IssueReturnForm : ChildForm
{
    private sealed record Entry(int Id, string Text)
    {
        public override string ToString() => Text;
    }

    private readonly ComboBox cmbMember = new() { DropDownStyle = ComboBoxStyle.DropDownList, Location = new Point(15, 40), Width = 300 };
    private readonly ComboBox cmbBook = new() { DropDownStyle = ComboBoxStyle.DropDownList, Location = new Point(335, 40), Width = 380 };
    private readonly Label lblInfo = new() { Location = new Point(15, 75), AutoSize = true, ForeColor = Color.Gray };
    private readonly Button btnIssue = Ui.MakeButton("Issue book", 740, 36, 120, primary: true);

    private readonly ComboBox cmbFilter = new() { DropDownStyle = ComboBoxStyle.DropDownList, Location = new Point(70, 10), Width = 130 };
    private readonly Button btnReturn = Ui.MakeButton("Return", 230, 7, 100, primary: true);
    private readonly Button btnRenew = Ui.MakeButton("Renew", 338, 7, 100);
    private readonly Button btnFine = Ui.MakeButton("Collect fine", 446, 7, 120);

    private readonly ListView list = Ui.MakeList(
        ("Loan", 55), ("Member", 170), ("Book", 240), ("Issued", 95), ("Due", 95), ("Returned", 95), ("Status", 80), ("Fine (Birr)", 80));

    private bool refreshing;

    public IssueReturnForm()
    {
        var issuePanel = new Panel { Dock = DockStyle.Top, Height = 110, BackColor = Ui.Panel };
        issuePanel.Controls.Add(Ui.MakeLabel("Issue a book", 15, 8, bold: true));
        issuePanel.Controls.Add(Ui.MakeLabel("Member", 15, 22));
        issuePanel.Controls.Add(Ui.MakeLabel("Book (only available copies are listed)", 335, 22));
        issuePanel.Controls.AddRange(new Control[] { cmbMember, cmbBook, lblInfo, btnIssue });

        var filterPanel = new Panel { Dock = DockStyle.Top, Height = 48 };
        filterPanel.Controls.Add(Ui.MakeLabel("Show loans:", 8, 14));
        filterPanel.Controls.AddRange(new Control[] { cmbFilter, btnReturn, btnRenew, btnFine });

        cmbFilter.Items.AddRange(new object[] { "All", "Active", "Overdue", "Returned" });
        cmbFilter.SelectedIndex = 1;

        // list first (fill), then the two top panels (filter is added before issue so issue ends up above it)
        Controls.Add(list);
        Controls.Add(filterPanel);
        Controls.Add(issuePanel);

        cmbMember.SelectedIndexChanged += (_, _) => UpdateInfo();
        cmbBook.SelectedIndexChanged += (_, _) => UpdateInfo();
        cmbFilter.SelectedIndexChanged += (_, _) => { if (!refreshing) RefreshData(); };
        list.SelectedIndexChanged += (_, _) => UpdateButtons();
        btnIssue.Click += (_, _) => IssueBook();
        btnReturn.Click += (_, _) => ReturnBook();
        btnRenew.Click += (_, _) => RenewLoan();
        btnFine.Click += (_, _) => CollectFine();
        UpdateButtons();
    }

    protected override void RefreshData()
    {
        refreshing = true;
        int? memberId = (cmbMember.SelectedItem as Entry)?.Id;
        int? bookId = (cmbBook.SelectedItem as Entry)?.Id;
        int? loanId = Ui.SelectedId(list);

        cmbMember.Items.Clear();
        foreach (var m in LibraryService.ActiveMembers())
            cmbMember.Items.Add(new Entry(m.Id, $"{m.Name} ({m.Code})"));
        cmbBook.Items.Clear();
        foreach (var b in LibraryService.AvailableBooks())
            cmbBook.Items.Add(new Entry(b.Id, $"{b.Title} - {b.Author}"));
        SelectEntry(cmbMember, memberId);
        SelectEntry(cmbBook, bookId);

        list.BeginUpdate();
        list.Items.Clear();
        foreach (var l in LibraryService.GetLoans(cmbFilter.SelectedItem as string ?? "All"))
        {
            var member = LibraryService.GetMember(l.MemberId);
            var book = LibraryService.GetBook(l.BookId);
            decimal fine = LibraryService.FineOf(l);
            string status = LibraryService.StatusOf(l);
            var item = Ui.Row(l.Id, l.Id.ToString(), member?.Name ?? "?", book?.Title ?? "?",
                l.IssueDate.ToString("dd MMM yyyy"), l.DueDate.ToString("dd MMM yyyy"),
                l.ReturnDate?.ToString("dd MMM yyyy") ?? "-", status,
                fine > 0 ? fine.ToString("N2") + (l.FinePaid ? " (paid)" : "") : "-");
            if (status == "Overdue") item.ForeColor = Ui.Danger;
            else if (status == "Returned") item.ForeColor = Color.Gray;
            list.Items.Add(item);
            if (loanId == l.Id) item.Selected = true;
        }
        list.EndUpdate();
        refreshing = false;
        UpdateInfo();
        UpdateButtons();
        MainForm.SetStatus($"{list.Items.Count} loan(s) shown.");
    }

    private static void SelectEntry(ComboBox box, int? id)
    {
        if (id == null) return;
        foreach (var o in box.Items)
            if (o is Entry e && e.Id == id) { box.SelectedItem = o; return; }
    }

    private void UpdateInfo()
    {
        if (refreshing) return;
        var parts = new List<string>();
        if (cmbMember.SelectedItem is Entry m)
            parts.Add($"Member has {LibraryService.ActiveLoansOf(m.Id)} of {LibraryService.MaxLoansPerMember} loans.");
        if (cmbBook.SelectedItem is Entry b)
            parts.Add($"Available copies: {LibraryService.GetBook(b.Id)?.AvailableCopies}.");
        lblInfo.Text = string.Join("   ", parts);
    }

    private void UpdateButtons()
    {
        if (refreshing) return;
        var id = Ui.SelectedId(list);
        var loan = id == null ? null : LibraryService.GetLoans("All").FirstOrDefault(l => l.Id == id);
        string status = loan == null ? "" : LibraryService.StatusOf(loan);
        btnReturn.Enabled = loan != null && status != "Returned";
        btnRenew.Enabled = status == "Active";
        btnFine.Enabled = loan != null && status == "Returned" && loan.Fine > 0 && !loan.FinePaid;
    }

    private void IssueBook()
    {
        if (cmbMember.SelectedItem is not Entry m) { Report(new Models.Result(false, "Please select a member.")); return; }
        if (cmbBook.SelectedItem is not Entry b) { Report(new Models.Result(false, "Please select a book.")); return; }

        var r = LibraryService.Issue(m.Id, b.Id);
        Report(r);
        if (!r.Ok)
            MessageBox.Show(r.Message, "Cannot issue book", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void ReturnBook()
    {
        var id = Ui.SelectedId(list);
        if (id == null) return;
        if (!Ui.Confirm("Mark the selected book as returned?")) return;
        var (r, loan) = LibraryService.Return(id.Value);
        Report(r);
        if (r.Ok) Ui.Info(r.Message);
    }

    private void RenewLoan()
    {
        var id = Ui.SelectedId(list);
        if (id == null) return;
        var r = LibraryService.Renew(id.Value);
        Report(r);
        if (!r.Ok) MessageBox.Show(r.Message, "Cannot renew", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void CollectFine()
    {
        var id = Ui.SelectedId(list);
        if (id == null) return;
        if (!Ui.Confirm("Mark the fine for this loan as paid?")) return;
        Report(LibraryService.PayFine(id.Value));
    }
}
